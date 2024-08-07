import { Component, ViewChild } from "@angular/core";

import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexTitleSubtitle,
  ApexStroke,
  ApexGrid,
  ApexFill,
  ApexMarkers,
  ApexYAxis
} from "ng-apexcharts";

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  dataLabels: ApexDataLabels;
  grid: ApexGrid;
  fill: ApexFill;
  markers: ApexMarkers;
  yaxis: ApexYAxis;
  stroke: ApexStroke;
  title: ApexTitleSubtitle;
};

@Component({
  selector: 'app-divise-prediction',
  templateUrl: './divise-prediction.component.html',
  styleUrls: ['./divise-prediction.component.css']
})
export class DivisePredictionComponent {

  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  private data = {
    euros: [4, 3, 10, 9, 29, 19, 22, 9, 12, 7, 19, 5, 13, 9, 17, 2, 7, 5],
    dolares: [5, 2, 15, 14, 20, 25, 20, 10, 14, 8, 22, 6, 16, 11, 19, 4, 9, 7],
    libras: [6, 3, 13, 12, 18, 22, 17, 8, 10, 6, 25, 7, 14, 10, 20, 3, 8, 6]
  };

  constructor() {
    this.updateChart('euros');
  }

  updateChart(currency: string) {
    this.chartOptions = {
      series: [
        {
          name: currency,
          data: this.data[currency]
        }
      ],
      chart: {
        height: 350,
        type: "line"
      },
      stroke: {
        width: 7,
        curve: "smooth"
      },
      xaxis: {
        type: "datetime",
        categories: [
          "1/11/2000",
          "2/11/2000",
          "3/11/2000",
          "4/11/2000",
          "5/11/2000",
          "6/11/2000",
          "7/11/2000",
          "8/11/2000",
          "9/11/2000",
          "10/11/2000",
          "11/11/2000",
          "12/11/2000",
          "1/11/2001",
          "2/11/2001",
          "3/11/2001",
          "4/11/2001",
          "5/11/2001",
          "6/11/2001"
        ]
      },
      title: {
        text: "Evolución del Valor de la Divisa",
        align: "left",
        style: {
          fontSize: "16px",
          color: "#666"
        }
      },
      fill: {
        type: "gradient",
        gradient: {
          shade: "dark",
          gradientToColors: ["#FDD835"],
          shadeIntensity: 1,
          type: "horizontal",
          opacityFrom: 1,
          opacityTo: 1,
          stops: [0, 100, 100, 100]
        }
      },
      markers: {
        size: 4,
        colors: ["#FFA41B"],
        strokeColors: "#fff",
        strokeWidth: 2,
        hover: {
          size: 7
        }
      },
      yaxis: {
        min: -10,
        max: 40,
        title: {
          text: "Valor"
        }
      }
    };
  }

  onCurrencyChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const selectedCurrency = selectElement.value;
    this.updateChart(selectedCurrency);
  }
}
