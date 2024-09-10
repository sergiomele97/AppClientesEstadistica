import { Component, OnInit, ViewChild } from '@angular/core';
import { ClustersDataService } from 'src/app/servicios/clusters-data.service';
import { combineLatest } from 'rxjs';

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
  colors?: string[];
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
        labels: {
          formatter: function (val) {
            return val.toFixed(2);
          },
        },
      },
      colors: []
    };
  }

  ngOnInit() {
    combineLatest([this.dataService.selectedDataCluster$, this.dataService.selectedLabel$])
      .subscribe(([data, labels]) => {
        this.updateChartData(data, labels);
      });
  }
 
  updateChartData(data: any[], labels: number[]) {
    console.log('Datos recibidos:', data);
    console.log('Etiquetas recibidas:', labels);
  
    const colorMap = {
      1: '#FF0000',
      2: '#0000FF',
      3: '#00FF00',
      4: '#800080',
      5: '#FFA500'
    };
  
    const groupedData = data.reduce((acc, point, index) => {
      const label = labels[index];
      if (!acc[label]) {
        acc[label] = [];
      }
      acc[label].push(point);
      return acc;
    }, {} as Record<number, { x: number; y: number }[]>);
  
    const seriesData = Object.keys(groupedData).map(label => ({
      name: `Group ${label}`,
      data: groupedData[parseInt(label)]
    }));
  
    const colors = Object.keys(groupedData).map(label => colorMap[parseInt(label)] || '#000000');
  
    console.log('Datos agrupados para series:', seriesData);
    console.log('Colores:', colors);
  
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
        title: {
          text: "Edad"
        }
      },
      yaxis: {
        tickAmount: 7,
        labels: {
          formatter: function (val) {
            return val.toFixed(2);
          },
        },
        title: {
          text: "Balance"
        }
      },
      colors: colors
    };
  }
  

  updateChart() {
    // Aquí deberías actualizar los datos en base a las nuevas variables seleccionadas
    this.dataService.selectedDataCluster$.subscribe((data) => {
      this.dataService.selectedLabel$.subscribe((labels) => {
        this.updateChartData(data, labels);
      });
    });
  }
}
