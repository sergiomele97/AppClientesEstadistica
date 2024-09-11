// src/app/components/clusters/clusters.component.ts

import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { ClienteConBalance } from 'src/app/models/cliente-con-balance.model';
import { ClienteService } from 'src/app/servicios/cliente.service';
import { ClustersDataService } from 'src/app/servicios/clusters-data.service';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

/**
 * Componente para gestionar clusters de clientes y visualización.
 */
@Component({
  selector: 'app-clusters',
  templateUrl: './clusters.component.html',
  styleUrls: ['./clusters.component.css'],
})
export class ClustersComponent implements OnInit, OnDestroy {
  public isLoading = false; // Estado de carga

  private apiUrl = environment.apiClusters;
  private datos: any[] = [];
  public daviesBouldinIndex: number | null = null;
  private subscription!: Subscription;
  private routeSubscription!: Subscription;
  public clientesBalance: ClienteConBalance[] = [];
  public tableData: any[] = [];
  public filteredTableData: any[] = [];
  public filterText: string = '';

  /**
   * Constructor del componente.
   * @param dataService Servicio de datos para clusters.
   * @param http Cliente HTTP.
   * @param clienteService Servicio de clientes.
   */
  constructor(
    private dataService: ClustersDataService,
    private http: HttpClient,
    private clienteService: ClienteService
  ) {}

  /**
   * Inicializa el componente.
   */
  ngOnInit(): void {
    this.clienteService.getClientesConBalance().subscribe(
      (data) => {
        if (data.length === 0) {
          console.warn('El array recibido está vacío.');
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

  /**
   * Procesa los datos de clientes para el análisis de clusters.
   */
  private procesarDatosClientes(): void {
    this.datos = this.clientesBalance.map((cliente) => {
      const sexo = cliente.sexo === 'Masculino' ? 0 : 1;
      return [
        cliente.clienteId,
        cliente.edad,
        sexo,
        cliente.pais,
        cliente.balance,
        cliente.numeroGastos,
        cliente.numeroIngresos,
      ];
    });
  }

  /**
   * Envía datos al backend y actualiza los datos del componente.
   * @param datos Datos a enviar.
   * @param nCluster Número de clusters.
   */
  private async enviarDatosBackend(
    datos: any[],
    nCluster: number
  ): Promise<void> {
    try {
      const datos_cluster = datos.map((individuo) => [
        individuo[1],
        individuo[2],
        individuo[4],
        individuo[5],
        individuo[6],
      ]);
      const response = await this.http
        .post<any>(this.apiUrl, { data: datos_cluster, nCluster: nCluster })
        .toPromise();

      const etiqueta = response.etiqueta || [];
      this.daviesBouldinIndex = response.db || 0;
      this.dataService.setLabel(etiqueta);

      const datosReducidos = datos.map((individuo) => [
        individuo[1],
        individuo[4],
      ]);
      this.dataService.setSelectedDataCluster(datosReducidos);

      datos = datos.map((individuo) => [
        individuo[0], // clienteId
        individuo[1], // edad
        individuo[2] === 0 ? 'Masculino' : 'Femenino', // sexo
        individuo[3], // pais
        individuo[4], // balance
        individuo[5], // numeroGastos
        individuo[6], // numeroIngresos
      ]);
      this.dataService.setSelectedDataTable(datos);

      this.tableData = datos.map((dato, index) => [...dato, etiqueta[index]]);
      this.filteredTableData = this.tableData;
    } catch (error) {
      console.error('Error al enviar datos al backend Python:', error);
      throw new Error('Error al enviar datos al python');
    }
  }

  /**
   * Maneja la selección de un cluster.
   * @param event Evento de selección.
   */
  async onSelectionCluster(event: Event) {
    this.isLoading = true;

    const selectElement = event.target as HTMLSelectElement;
    const numerosSelect = selectElement.value;
    const nCluster = parseInt(numerosSelect, 10);
    this.dataService.setSelectednCluster(nCluster);

    await this.enviarDatosBackend(this.datos, nCluster);

    this.isLoading = false;
  }

  /**
   * Filtra los datos de la tabla según el texto de filtro.
   */
  onFilterChange(): void {
    this.filteredTableData = this.tableData.filter((row) =>
      row[5].toString().includes(this.filterText)
    );
  }

  /**
   * Ordena los datos de la tabla por una columna específica.
   * @param columnIndex Índice de la columna para ordenar.
   */
  sortData(columnIndex: number): void {
    this.filteredTableData.sort((a, b) =>
      a[columnIndex] > b[columnIndex] ? 1 : -1
    );
  }

  /**
   * Limpia las suscripciones cuando el componente se destruye.
   */
  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
    if (this.routeSubscription) {
      this.routeSubscription.unsubscribe();
    }
  }
}
