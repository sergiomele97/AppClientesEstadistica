import { Component, ViewChild } from "@angular/core";
import { HttpClient } from '@angular/common/http';
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

  private fechas = {
    euros: [ "2000-01-01", "2000-01-02", "2000-01-03", "2000-01-04", "2000-01-05", "2000-01-06", "2000-01-07", "2000-01-08", "2000-01-09", "2000-01-10", "2000-01-11", "2000-01-12", "2000-01-13", "2000-01-14", "2000-01-15", "2000-01-16", "2000-01-17", "2000-01-18"],
    dolares: [ "2000-01-01", "2000-01-02", "2000-01-03", "2000-01-04", "2000-01-05", "2000-01-06", "2000-01-07", "2000-01-08", "2000-01-09", "2000-01-10", "2000-01-11", "2000-01-12", "2000-01-13", "2000-01-14", "2000-01-15", "2000-01-16", "2000-01-17", "2000-01-18"],
    libras: [ "2000-01-01", "2000-01-02", "2000-01-03", "2000-01-04", "2000-01-05", "2000-01-06", "2000-01-07", "2000-01-08", "2000-01-09", "2000-01-10", "2000-01-11", "2000-01-12", "2000-01-13", "2000-01-14", "2000-01-15", "2000-01-16", "2000-01-17", "2000-01-18"]
  }

  constructor(private http: HttpClient) {
    this.updateChart('euros');
  }

  updateChart(currency: string) {
    console.log('Requesting data for:', currency);

    this.http.post('http://localhost:5000/predict', { series: this.data[currency] })
      .subscribe((response: any) => {
        console.log('Received data:', response);
        const predictions = response.Prediction || [];
        const predictionData = predictions.length ? predictions : new Array(10).fill(0);

        const historicalData = this.data[currency];
        const historicalDates = this.fechas[currency];
        const predictionDates = ["2000-01-19", "2000-01-20", "2000-01-21", "2000-01-22", "2000-01-23", "2000-01-24", "2000-01-25", "2000-01-26", "2000-01-27", "2000-01-28"];

        this.chartOptions = {
          series: [
            {
              name: 'Historical Data',
              data: historicalData.map((value, index) => [historicalDates[index], value]),
              color: '#0000FF',  // Azul para los datos históricos
            },
            {
              name: 'Predictions',
              data: predictionData.map((value, index) => [predictionDates[index], value]),
              color: '#FF0000',  // Rojo para las predicciones
            }
          ],
          chart: {
            height: 350,
            type: 'line'
          },
          stroke: {
            width: [3, 3],
            curve: 'smooth'
          },
          xaxis: {
            type: 'datetime',
            categories: [...historicalDates, ...predictionDates]  // Asegura que las fechas correspondan a los datos
          },
          title: {
            text: 'Evolución del Valor de la Divisa',
            align: 'left',
            style: {
              fontSize: '16px',
              color: '#666'
            }
          },
          fill: {
            type: 'gradient',
            gradient: {
              shade: 'dark',
              gradientToColors: ['#FDD835'],
              shadeIntensity: 1,
              type: 'horizontal',
              opacityFrom: 1,
              opacityTo: 1,
              stops: [0, 100, 100, 100]
            }
          },
          markers: {
            size: 4,
            colors: ['#FFA41B'],
            strokeColors: '#fff',
            strokeWidth: 2,
            hover: {
              size: 7
            }
          },
          yaxis: {
            min: -10,
            max: 40,
            title: {
              text: 'Valor'
            }
          }
        };
      }, (error) => {
        console.error('Error fetching data:', error);
      });
  }


  onCurrencyChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const selectedCurrency = selectElement.value;
    this.updateChart(selectedCurrency);
  }
}
