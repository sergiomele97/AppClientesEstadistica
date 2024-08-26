import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ICliente } from 'src/app/interfaces/cliente';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { ClienteEstService } from 'src/app/servicios/cliente-est.service';
import { TransaccionService } from 'src/app/servicios/transaccion.service';
import { ClustersDataService } from 'src/app/servicios/clusters-data.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-clusters',
  templateUrl: './clusters.component.html',
  styleUrls: ['./clusters.component.css'],
})
export class ClustersComponent implements OnInit, OnDestroy {

  constructor(
    private dataService: ClustersDataService, 
    private http: HttpClient,
    private clienteService: ClienteEstService,
    private transaccionService: TransaccionService
  ) {}

  private apiUrl = 'http://127.0.0.1:5000/cluster';
  private datos: any[] = [];
  public daviesBouldinIndex: number | null = null;
  cliente: ICliente | undefined;
  clientes: ICliente[] = [];
  transacciones: ITransaccion[] = [];
  subscription!: Subscription;
  routeSubscription!: Subscription;

  ngOnInit(): void {
    // Obtener la lista de clientes
    this.subscription = this.clienteService.getClientes().subscribe({
      next: (clientes) => {
        this.clientes = clientes;

        // Obtener las transacciones de todos los clientes
        this.subscription = this.transaccionService.getTransacciones().subscribe({
          next: (transacciones) => {
            this.transacciones = transacciones;

            // Procesar los datos de los clientes junto con sus balances calculados
            this.procesarDatosClientes();
          },
          error: (err) => {
            console.error('Error al obtener las transacciones:', err);
          }
        });
      },
      error: (err) => {
        console.error('Error al obtener la lista de clientes:', err);
      },
    });
  }

  private procesarDatosClientes(): void {
    // Recorrer todos los clientes y extraer los datos necesarios junto con el balance calculado
    this.datos = this.clientes.map(cliente => {
      const edad = cliente.edad;
      const sexo = cliente.sexo === 'Masculino' ? 0 : 1;  // Codificar sexo: 0 para mujeres, 1 para hombres
      const balance = this.calcularBalance(cliente.clienteId);
      const nGastos = this.numeroGastos(cliente.clienteId);
      const nIngresos = this.numeroIngresos(cliente.clienteId);
      const pais = cliente.pais
      
      // Imprimir los dos primeros valores (edad y sexo) en la consola
      console.log([edad, sexo]);

      return [edad, balance, sexo , nGastos, nIngresos];
    });
  }

  private calcularBalance(clienteId: number): number {
    const ingresos = this.transacciones
      .filter(transaccion => transaccion.clienteDestinoId === clienteId)
      .reduce((total, transaccion) => total + (transaccion.importeRecibido || 0), 0);
    const gastos = this.transacciones
      .filter(transaccion => transaccion.clienteOrigenId === clienteId)
      .reduce((total, transaccion) => total + (transaccion.importeEnviado || 0), 0);
    return ingresos - gastos;
  }

  private numeroGastos(clienteId: number): number {
    const gastos = this.transacciones
      .filter(transaccion => transaccion.clienteOrigenId === clienteId)
      .reduce((total) => total + 1, 0);
    return gastos;
  }
  private numeroIngresos(clienteId: number): number {
    const ingresos = this.transacciones
    .filter(transaccion => transaccion.clienteDestinoId === clienteId)
    .reduce((total) => total + 1, 0);
    return ingresos;
  }

  
  private async enviarDatosBackend(datos: any[], nCluster: number): Promise<void> {
    try {
      const response = await this.http.post<any>(this.apiUrl, { data: datos, nCluster: nCluster }).toPromise();
      const etiqueta = response.etiqueta || [];
      this.daviesBouldinIndex= response.db || 0;
      this.dataService.setLabel(etiqueta);
      
      const datosReducidos = datos.map(individuo => individuo.slice(0, 2)); // solo se muestran dos variables
      this.dataService.setSelectedDataCluster(datosReducidos);//mandamos los datos cortados a la global para visualizar en cluster
      this.dataService.setSelectedDataTable(datos);//mandamos los datos completos a la global para visualizar en la tabla

    } catch (error) {
    
      throw new Error('Error al enviar datos al python');
    }
  }

  async onSelectionCluster(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const numerosSelect = selectElement.value;
    const nCluster = parseInt(numerosSelect, 10);
    this.dataService.setSelectednCluster(nCluster);

    // Llamar a enviarDatosBackend con los datos procesados y el número de clusters
    await this.enviarDatosBackend(this.datos, nCluster);
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
