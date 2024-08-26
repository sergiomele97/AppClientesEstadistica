import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subscription } from 'rxjs';
import { ChartComponent, ApexAxisChartSeries, ApexChart, ApexXAxis, ApexDataLabels, ApexTitleSubtitle, ApexStroke, ApexGrid, ApexFill, ApexMarkers, ApexYAxis } from 'ng-apexcharts';
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
export class DivisasComponent implements OnInit, OnDestroy {

  constructor(
    private http: HttpClient, 
    private divisaService: DivisaService
  ) {}

  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions> = {};
  
  private apiUrl = 'http://127.0.0.1:5000/predict';
  private divisasData: IDivisa[] = [];
  private subscription!: Subscription;
  
  ngOnInit(): void {
    this.subscription = this.divisaService.getDivisasData().subscribe({
      next: (data) => {
        this.divisasData = data;
        console.log("Datos de divisas recibidos:", data);
      },
      error: (err) => {
        console.error('Error al obtener datos de divisas:', err);
      }
    });
  }

  updateChart(currency: string): void {
    // Verifica que los datos estén disponibles
    if (!this.divisasData || this.divisasData.length === 0) {
      console.error('No hay datos de divisas disponibles.');
      return;
    }

    console.log('Requesting data for:', currency);

    // Filtra los datos por la moneda seleccionada
    const filteredData = this.divisasData.filter(d => d.nombre === currency);
    if (filteredData.length === 0) {
      console.error('No hay datos disponibles para la moneda:', currency);
      return;
    }

    // Ordena los datos por fecha y toma los 10 más recientes
    filteredData.sort((a, b) => (a.fecha ?? new Date()).getTime() - (b.fecha ?? new Date()).getTime());
    const recentData = filteredData.slice(-10);
    
    if (recentData.length === 0) {
      console.error('No hay datos recientes disponibles para la moneda:', currency);
      return;
    }

    const recentDates = recentData.map(d => (d.fecha ?? new Date()).toISOString().split('T')[0]);
    const recentValues = recentData.map(d => d.divisa);

    // Enviar los datos al backend y actualizar el gráfico
    this.http.post(this.apiUrl, { data: recentValues })
      .subscribe({
        next: (response: any) => {
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
                name: 'Datos Históricos',
                data: recentValues.map((value, index) => [recentDates[index], value]),
                color: '#0000FF',
              },
              {
                name: 'Predicciones',
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
              min: Math.min(...recentValues) - 10,
              max: Math.max(...recentValues) + 10,
              title: {
                text: 'Valor'
              }
            }
          };
        },
        error: (error) => {
          console.error('Error al obtener los datos:', error);
        }
      });
  }

  onCurrencyChange(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    const selectedCurrency = selectElement.value;
    console.log('Moneda seleccionada:', selectedCurrency);
    this.updateChart(selectedCurrency);
  }

  ngOnDestroy(): void {
    // Desuscribirse para prevenir fugas de memoria
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
