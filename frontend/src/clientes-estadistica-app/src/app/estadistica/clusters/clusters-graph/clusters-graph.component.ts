import { Component, OnInit, ViewChild } from '@angular/core';
import { ClustersDataService } from 'src/app/servicios/clusters-data.service';

import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexYAxis,
  ApexXAxis
} from 'ng-apexcharts';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  yaxis: ApexYAxis;
  colors?: string[]; // Usa un array de strings para los colores
};

@Component({
  selector: 'app-clusters-graph',
  templateUrl: './clusters-graph.component.html',
  styleUrls: ['./clusters-graph.component.css'],
})
export class ClustersGraphComponent implements OnInit {
  @ViewChild('chart') chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  constructor(private dataService: ClustersDataService) {
    this.chartOptions = {
      series: [],
      chart: {
        height: 350,
        type: 'scatter',
        zoom: {
          enabled: true,
          type: 'xy',
        },
      },
      xaxis: {
        tickAmount: 10,
        labels: {
          formatter: function (val) {
            return parseFloat(val).toFixed(1);
          },
        },
      },
      yaxis: {
        tickAmount: 7,
      },
      colors: [] // Definiremos los colores en updateChartData
    };
  }

  ngOnInit() {
    this.dataService.selectedDataCluster$.subscribe((data) => {
      this.dataService.selectedLabel$.subscribe((labels) => {
        this.updateChartData(data, labels);
      });
    });
  }

  updateChartData(data: any[], labels: number[]) {
    // Mapa de colores basado en etiquetas
    const colorMap = {
      1: '#FF0000', // Rojo
      2: '#0000FF', // Azul
      3: '#00FF00', // Verde
      4: '#800080', // Morado
      5: '#FFA500'  // Naranja
    };

    // Agrupar datos por etiqueta
    const groupedData = data.reduce((acc, point, index) => {
      const label = labels[index];
      if (!acc[label]) {
        acc[label] = [];
      }
      acc[label].push(point);
      return acc;
    }, {} as Record<number, { x: number; y: number }[]>);

    // Crear series para cada grupo de datos
    const seriesData = Object.keys(groupedData).map(label => ({
      name: `Group ${label}`,
      data: groupedData[parseInt(label)]
    }));

    // Extraer colores de los datos
    const colors = Object.keys(groupedData).map(label => colorMap[parseInt(label)] || '#000000');

    this.chartOptions = {
      series: seriesData,
      chart: {
        height: 350,
        type: 'scatter',
        zoom: {
          enabled: true,
          type: 'xy',
        },
      },
      xaxis: {
        tickAmount: 10,
        labels: {
          formatter: function (val) {
            return parseFloat(val).toFixed(1);
          },
        },
      },
      yaxis: {
        tickAmount: 7,
        labels: {
          formatter: function (val) {
            return val.toFixed(2);
          },
        },
      },
      colors: colors // Aplicar los colores a las series
    };
  }
}
