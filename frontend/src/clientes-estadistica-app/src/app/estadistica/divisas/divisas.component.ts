import { Component, ViewChild, OnInit } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { ChartComponent, ApexAxisChartSeries, ApexChart, ApexXAxis, ApexDataLabels, ApexTitleSubtitle, ApexStroke, ApexGrid, ApexFill, ApexMarkers, ApexYAxis } from "ng-apexcharts";
import { DivisaService } from 'src/app/servicios/divisa.service';
import { IDivisa } from 'src/app/interfaces/divisa';

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
  selector: 'app-divisas',
  templateUrl: './divisas.component.html',
  styleUrls: ['./divisas.component.css']
})
export class DivisasComponent implements OnInit {
  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  private apiUrl = 'http://localhost:5000/predict';
  private divisasData: IDivisa[] = []; // Datos de divisas obtenidos del backend
  
  constructor(private http: HttpClient, private divisaService: DivisaService) { }

  ngOnInit(): void {
    console.log(this.divisasData);
  }

  obtenerDatosDivisas(divisa: string) {
    this.divisaService.getDivisasData(divisa).subscribe({//obtenemos los datos de la divisa seleccionada
      next: (data) => {
        this.divisasData = data;
        console.log("los datos son: ", data);
        this.updateChart(); // Ahora actualiza el gráfico después de recibir los datos
      },
      error: (err) => {
        console.error('Error al obtener datos de divisas:', err);
      }
    });
  }

  updateChart() {//para graficar los datos
    console.log('Los datos de :', this.divisasData);
    if (this.divisasData.length === 0) {
      console.error('No data available:',this.divisasData);
      return;
    }

    // Ordenar por fecha y tomar los últimos 10 registros
    this.divisasData.sort((a, b) => (a.fecha ?? new Date()).getTime() - (b.fecha ?? new Date()).getTime());
    const recentData = this.divisasData.slice(-10);
    
    if (recentData.length === 0) {
      console.error('No data available:',this.divisasData);
      return;
    }

    const recentDates = recentData.map(d => (d.fecha ?? new Date()).toISOString().split('T')[0]);
    const recentValues = recentData.map(d => d.divisa);

    this.http.post(this.apiUrl, { data: recentValues })
      .subscribe((response: any) => {
        console.log('Received data:', response);
        const predictions = response.Prediction || [];
        const predictionData = predictions.length ? predictions : new Array(10).fill(0);

        const predictionDates = recentDates.map((date, index) => {
          const nextDate = new Date(date);
          nextDate.setDate(nextDate.getDate() + index + 1);
          return nextDate.toISOString().split('T')[0];
        });

        this.chartOptions = {
          series: [
            {
              name: 'Historical Data',
              data: recentValues.map((value, index) => [recentDates[index], value]),
              color: '#0000FF',
            },
            {
              name: 'Predictions',
              data: predictionData.map((value, index) => [predictionDates[index], value]),
              color: '#FF0000',
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
            categories: [...recentDates, ...predictionDates]
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
    console.log('Se ha seleccionado en el Front:', selectedCurrency);
    this.obtenerDatosDivisas(selectedCurrency); // Actualiza el gráfico cuando se selecciona una nueva divisa
  }
}
