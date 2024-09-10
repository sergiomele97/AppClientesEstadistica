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
  private subscription: Subscription;
  private chart: Highcharts.Chart;

  constructor(private clienteService: ClienteService) {}

  /**
   * Inicializa el componente y carga los datos de clientes para mostrar en el gráfico.
   */
  ngOnInit(): void {
    this.subscription = this.clienteService.getClientes().subscribe(
      (clientes: ICliente[]) => {
        const clientesPorPais: { [key: string]: number } = {};

        // Contar clientes por país
        clientes.forEach((cliente) => {
          clientesPorPais[cliente.pais.iso3] =
            (clientesPorPais[cliente.pais.iso3] || 0) + 1;
        });

        // Preparar datos para el gráfico
        this.bubbleData = Object.keys(clientesPorPais).map((iso3) => ({
          code3: iso3,
          z: clientesPorPais[iso3],
        }));

        // Inicializar opciones del gráfico
        this.initializeChartOptions();
        this.isLoading = false;

        // Crear el gráfico después de un breve retraso para asegurar que el contenedor esté listo
        setTimeout(() => {
          this.chart = Highcharts.mapChart('container', this.chartOptions);
        }, 0);
      },
      (error) => {
        console.error('Error al obtener los clientes:', error);
        this.isLoading = false;
      }
    );
  }

  /**
   * Configura las opciones del gráfico para la distribución de clientes por país.
   */
  initializeChartOptions() {
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
   * Limpia los recursos utilizados por el componente.
   */
  ngOnDestroy(): void {
    this.subscription.unsubscribe(); // Cancelar suscripción
    if (this.chart) {
      this.chart.destroy(); // Destruir gráfico al salir
    }
  }
}
