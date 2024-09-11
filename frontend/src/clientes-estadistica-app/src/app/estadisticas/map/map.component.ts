import { Component, OnDestroy, OnInit } from '@angular/core';
import Highcharts from 'highcharts/highmaps';
import worldMap from '@highcharts/map-collection/custom/world.geo.json';
import { ClienteService } from 'src/app/servicios/cliente.service';
import { ICliente } from 'src/app/interfaces/cliente';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
})
export class MapComponent implements OnInit, OnDestroy {
  Highcharts: typeof Highcharts = Highcharts;
  chartOptions: Highcharts.Options;
  bubbleData: { code3: string; z: number }[] = [];
  isLoading: boolean = true;
  private subscription: Subscription = new Subscription(); // Asegura la limpieza adecuada
  private chart: Highcharts.Chart | undefined;

  constructor(private clienteService: ClienteService) {}

  ngOnInit(): void {
    this.loadClientes();
  }

  /**
   * Carga los datos de clientes y configura el gráfico.
   */
  private loadClientes(): void {
    this.subscription.add(
      this.clienteService.getClientes().subscribe(
        (clientes: ICliente[]) => {
          this.processClientes(clientes);
          this.initializeChartOptions();
          this.isLoading = false;

          // Inicializar el gráfico después de la configuración de opciones
          this.createChart();
        },
        (error) => {
          console.error('Error al obtener los clientes:', error);
          this.isLoading = false;
        }
      )
    );
  }

  /**
   * Procesa los datos de clientes para contar y preparar la información para el gráfico.
   * @param clientes - Datos de clientes obtenidos del servicio.
   */
  private processClientes(clientes: ICliente[]): void {
    const clientesPorPais: { [key: string]: number } = {};

    // Contar clientes por país
    clientes.forEach((cliente) => {
      if (cliente.pais && cliente.pais.iso3) {
        clientesPorPais[cliente.pais.iso3] =
          (clientesPorPais[cliente.pais.iso3] || 0) + 1;
      }
    });

    // Preparar datos para el gráfico
    this.bubbleData = Object.keys(clientesPorPais).map((iso3) => ({
      code3: iso3,
      z: clientesPorPais[iso3],
    }));
  }

  /**
   * Configura las opciones del gráfico para la distribución de clientes por país.
   */
  private initializeChartOptions(): void {
    this.chartOptions = {
      chart: {
        borderWidth: 1,
        map: worldMap,
      },
      title: {
        text: 'Distribución de Clientes por País',
      },
      subtitle: {
        text: 'Número de clientes por país mostrado en burbujas',
      },
      legend: {
        enabled: false,
      },
      mapNavigation: {
        enabled: true,
        buttonOptions: {
          verticalAlign: 'bottom',
        },
      },
      series: [
        {
          type: 'map',
          name: 'Países',
          color: '#E0E0E0',
          enableMouseTracking: false,
          mapData: worldMap,
        },
        {
          type: 'mapbubble',
          name: 'Número de Clientes',
          joinBy: ['iso-a3', 'code3'],
          data: this.bubbleData,
          minSize: 10,
          maxSize: '10%',
          tooltip: {
            pointFormat: '{point.properties.name}: {point.z} clientes',
          },
        },
      ],
    };
  }

  /**
   * Crea el gráfico Highcharts con las opciones configuradas.
   */
  private createChart(): void {
    if (this.chartOptions) {
      this.chart = Highcharts.mapChart('container', this.chartOptions);
    }
  }

  /**
   * Limpia los recursos utilizados por el componente.
   */
  ngOnDestroy(): void {
    this.subscription.unsubscribe(); // Cancelar suscripción
    if (this.chart) {
      this.chart.destroy(); // Destruir gráfico al salir
    }
  }
}
