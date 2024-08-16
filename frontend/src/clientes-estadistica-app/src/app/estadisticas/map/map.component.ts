import { Component, OnDestroy, OnInit } from '@angular/core';
import Highcharts from 'highcharts/highmaps';
import worldMap from '@highcharts/map-collection/custom/world.geo.json';
import { ClienteEstService } from 'src/app/servicios/cliente-est.service';
import { ICliente } from 'src/app/interfaces/cliente';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
})
export class MapComponent implements OnInit, OnDestroy {
  Highcharts: typeof Highcharts = Highcharts;
  chartConstructor = 'mapChart';
  bubbleData: { code3: string; z: number }[] = [];
  chartOptions: Highcharts.Options;

  constructor(private clienteService: ClienteEstService) {}

  ngOnInit(): void {
    this.clienteService.getClientes().subscribe((clientes: ICliente[]) => {
      const clientesPorPais: { [key: string]: number } = {};

      // Contar clientes por país
      clientes.forEach((cliente) => {
        const iso3 = cliente.pais.iso3;
        if (clientesPorPais[iso3]) {
          clientesPorPais[iso3]++;
        } else {
          clientesPorPais[iso3] = 1;
        }
      });

      // Convertir los datos a la estructura requerida por bubbleData
      this.bubbleData = Object.keys(clientesPorPais).map((iso3) => ({
        code3: iso3,
        z: clientesPorPais[iso3],
      }));

      // Inicializar las opciones del gráfico
      this.initializeChartOptions();

      // Asegurarse de que el contenedor esté disponible y renderizar el gráfico
      setTimeout(() => {
        Highcharts.mapChart('container', this.chartOptions);
      }, 0); // Usar un retraso para garantizar que el DOM esté listo
    });
  }

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

  ngOnDestroy(): void {}
}
