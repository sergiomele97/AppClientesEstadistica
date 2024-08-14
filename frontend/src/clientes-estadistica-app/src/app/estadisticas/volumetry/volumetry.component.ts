import { Component, OnInit, ViewChild } from '@angular/core';

import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexTitleSubtitle,
  ApexStroke,
  ApexGrid
} from "ng-apexcharts";

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  dataLabels: ApexDataLabels;
  grid: ApexGrid;
  stroke: ApexStroke;
  title: ApexTitleSubtitle;
};

@Component({
  selector: 'app-volumetry',
  templateUrl: './volumetry.component.html',
  styleUrls: ['./volumetry.component.css']
})

export class VolumetryComponent {

  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  public dataType: string = 'usuarios';
  public data = {
    usuarios: [7, 10, 1, 13, 8, 45, 39],
    transacciones: [10, 41, 49, 62, 69, 91, 148]
  };

  constructor() {
    this.updateChart();
  }

  updateChart() {
    
    this.chartOptions = {
      series: [
        {
          name: this.dataType,
          data: this.data[this.dataType]
        }
      ],
      chart: {
        height: 350,
        type: "line",
        zoom: {
          enabled: false
        }
      },
      dataLabels: {
        enabled: true
      },
      stroke: {
        curve: "straight"
      },
      title: {
        text: "Number of Transactions Last Week",
        align: "center"
      },
      grid: {
        row: {
          colors: ["#f3f3f3", "transparent"], // takes an array which will be repeated on columns
          opacity: 0.5
        }
      },
      xaxis: {
        // Aquí habrá que hacer un select datetime
        categories: [
          "Monday",
          "Tuesday",
          "Wednesday",
          "Thursday",
          "Friday",
          "Saturday",
          "Sunday"
        ]
      }
    };
  }

  onSelectionChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.dataType = selectElement.value;
    this.updateChart();
  }
}
