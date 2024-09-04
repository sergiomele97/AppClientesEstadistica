// src/app/components/clusters/clusters.component.ts
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { ClienteConBalance } from 'src/app/models/cliente-con-balance.model';
import { ClienteService } from 'src/app/servicios/cliente.service';
import { ClustersDataService } from 'src/app/servicios/clusters-data.service';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-clusters',
  templateUrl: './clusters.component.html',
  styleUrls: ['./clusters.component.css'],
})
export class ClustersComponent implements OnInit, OnDestroy {
  constructor(
    private dataService: ClustersDataService,
    private http: HttpClient,
    private clienteService: ClienteService,
  ) {}

  public isLoading = false;  // Nueva variable para controlar la visibilidad del loader

  private apiUrl = environment.apiClusters;
  private datos: any[] = [];
  public daviesBouldinIndex: number | null = null;
  subscription!: Subscription;
  routeSubscription!: Subscription;
  clientesBalance: ClienteConBalance[] = [];
  tableData: any[] = [];
  filteredTableData: any[] = [];
  filterText: string = '';

  ngOnInit(): void {
    console.log("Iniciando ngOnInit");
  
    // Llamar al servicio para obtener los datos de ClienteConBalance
    this.clienteService.getClientesConBalance().subscribe(
      (data) => {
        console.log("Datos recibidos: ", data);
        if (data.length === 0) {
          console.warn("El array recibido está vacío.");
        } else {
          this.clientesBalance = data;
          this.procesarDatosClientes();
        }
      },
      (error) => {
        console.error('Error al obtener los datos de clientes', error);
      }
    );
  }

  private procesarDatosClientes(): void {
    // Recorrer todos los clientes y extraer los datos necesarios junto con el balance calculado
    this.datos = this.clientesBalance.map(cliente => {
      const sexo = cliente.sexo === 'Masculino' ? 0 : 1;
      return [cliente.clienteId, cliente.edad, sexo, cliente.pais, cliente.balance, cliente.numeroGastos, cliente.numeroIngresos];
    });
    console.log("Datos procesados para enviar al backend:", this.datos);
  }

  private async enviarDatosBackend(datos: any[], nCluster: number): Promise<void> {
    try {
      console.log("Enviando datos al backend Python:", datos, "Número de clusters:", nCluster);
      const datos_cluster = datos.map(individuo => [individuo[1],individuo[2], individuo[4],individuo[5],individuo[6]]); 
      //console.log("Datos cluster:", datos_cluster);
      const response = await this.http.post<any>(this.apiUrl, { data: datos_cluster, nCluster: nCluster }).toPromise();
      console.log("Respuesta del backend Python:", response);

      const etiqueta = response.etiqueta || [];
      this.daviesBouldinIndex = response.db || 0;
      this.dataService.setLabel(etiqueta);

      const datosReducidos = datos.map(individuo => [individuo[1], individuo[4]]); // solo se muestran dos variables
      this.dataService.setSelectedDataCluster(datosReducidos); // mandamos los datos cortados a la global para visualizar en cluster
      datos = datos.map(individuo => [
        individuo[0], // clienteId
        individuo[1], // edad
        individuo[2] === 0 ? "Masculino" : "Femenino", // sexo
        individuo[3], // pais
        individuo[4], // balance
        individuo[5], // numeroGastos
        individuo[6]  // numeroIngresos
      ]);
      this.dataService.setSelectedDataTable(datos); // mandamos los datos completos a la global para visualizar en la tabla

      // Combinar los datos con las etiquetas
      this.tableData = datos.map((dato, index) => [...dato, etiqueta[index]]);
      this.filteredTableData = this.tableData;
      console.log("Datos combinados con etiquetas:", this.tableData);

    } catch (error) {
      console.error("Error al enviar datos al backend Python:", error);
      throw new Error('Error al enviar datos al python');
    }
  }

  async onSelectionCluster(event: Event) {
    this.isLoading = true; // Mostrar el loader al iniciar la solicitud

    const selectElement = event.target as HTMLSelectElement;
    const numerosSelect = selectElement.value;
    const nCluster = parseInt(numerosSelect, 10);
    this.dataService.setSelectednCluster(nCluster);
    console.log(this.datos)
    // Llamar a enviarDatosBackend con los datos procesados y el número de clusters
    await this.enviarDatosBackend(this.datos, nCluster);

    this.isLoading = false; // Ocultar loader al acabar
  }

  onFilterChange(): void {
    this.filteredTableData = this.tableData.filter(row => row[5].toString().includes(this.filterText));
  }

  sortData(columnIndex: number): void {
    this.filteredTableData.sort((a, b) => a[columnIndex] > b[columnIndex] ? 1 : -1);
  }

  ngOnDestroy(): void {
    // Cancelar las suscripciones cuando el componente se destruya
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
    if (this.routeSubscription) {
      this.routeSubscription.unsubscribe();
    }
  }
}
