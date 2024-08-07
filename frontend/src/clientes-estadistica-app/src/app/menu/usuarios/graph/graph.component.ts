import { Component, ViewChild } from '@angular/core';

import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexTooltip,
  ApexStroke,
  ApexTitleSubtitle
} from "ng-apexcharts";

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  stroke: ApexStroke;
  tooltip: ApexTooltip;
  dataLabels: ApexDataLabels;
  title: ApexTitleSubtitle;
};

@Component({
  selector: 'app-graph',
  templateUrl: './graph.component.html',
  styleUrls: ['./graph.component.css']
})
export class GraphComponent {

  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  public dataType: string = 'sex';
  private data = {
    sex: {
      series: [
        {
          name: "male",
          data: [31, 40, 28, 51, 42, 109, 100]
        },
        {
          name: "female",
          data: [11, 32, 45, 32, 34, 52, 41]
        }
      ],
      title: "Accesses by Sex"
    },
    age: {
      series: [
        {
          name: "<30",
          data: [20, 30, 25, 40, 33, 80, 70]
        },
        {
          name: "30-50",
          data: [15, 22, 34, 29, 20, 60, 50]
        },
        {
          name: ">50",
          data: [5, 10, 8, 12, 15, 20, 30]
        }
      ],
      title: "Accesses by Age"
    },
    job: {
      series: [
        {
          name: "administrativo",
          data: [20, 30, 25, 35, 40, 50, 60]
        },
        {
          name: "sanitario",
          data: [10, 15, 20, 25, 30, 40, 50]
        },
        {
          name: "economista",
          data: [5, 10, 15, 20, 25, 30, 35]
        },
        {
          name: "informatico",
          data: [30, 40, 35, 45, 50, 60, 70]
        }
      ],
      title: "Accesses by Job"
    }
  };

  constructor() {
    this.updateChart();
  }

  updateChart() {
    const selectedData = this.data[this.dataType];
    this.chartOptions = {
      series: selectedData.series,
      chart: {
        height: 350,
        type: "area"
      },
      dataLabels: {
        enabled: false
      },
      title: {
        text: selectedData.title,
        align: "center"
      },
      stroke: {
        curve: "smooth"
      },
      xaxis: {
        type: "datetime",
        categories: [
          "2018-09-19T00:00:00.000Z",
          "2018-09-19T01:30:00.000Z",
          "2018-09-19T02:30:00.000Z",
          "2018-09-19T03:30:00.000Z",
          "2018-09-19T04:30:00.000Z",
          "2018-09-19T05:30:00.000Z",
          "2018-09-19T06:30:00.000Z"
        ]
      },
      tooltip: {
        x: {
          format: "dd/MM/yy HH:mm"
        }
      }
    };
  }

  onSelectionChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.dataType = selectElement.value;
    this.updateChart();
  }

  public generateData(baseval, count, yrange) {
    var i = 0;
    var series = [];
    while (i < count) {
      var x = Math.floor(Math.random() * (750 - 1 + 1)) + 1;
      var y =
        Math.floor(Math.random() * (yrange.max - yrange.min + 1)) + yrange.min;
      var z = Math.floor(Math.random() * (75 - 15 + 1)) + 15;

      series.push([x, y, z]);
      baseval += 86400000;
      i++;
    }
    return series;
  }
}
