// src/app/components/divisas/divisas.component.ts

import {
  Component,
  ViewChild,
  OnInit,
  OnDestroy,
  ChangeDetectorRef,
} from '@angular/core';
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
  ApexYAxis,
} from 'ng-apexcharts';
import { DivisaService } from 'src/app/servicios/divisa.service';
import { IDivisa } from 'src/app/interfaces/divisa';
import { environment } from 'src/environments/environment';
import { Subscription } from 'rxjs';

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

/**
 * Componente para mostrar un gráfico de evolución del valor de una divisa.
 */
@Component({
  selector: 'app-divisas',
  templateUrl: './divisas.component.html',
  styleUrls: ['./divisas.component.css'],
})
export class DivisasComponent implements OnInit, OnDestroy {
  @ViewChild('chart') chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;
  public isLoading = false; // Controla la visibilidad del loader
  private apiUrl = environment.apiPrediccion; // URL para la predicción de divisas
  private divisasData: IDivisa[] = []; // Datos de divisas obtenidos del backend
  private subscriptions: Subscription = new Subscription(); // Gestión de suscripciones
  public valorActual: number = 0; // Valor actual de la divisa
  public divisaSeleccionada: string = ''; // Divisa seleccionada

  /**
   * Constructor del componente.
   * @param http Cliente HTTP para solicitudes.
   * @param divisaService Servicio para obtener datos de divisas.
   * @param cdr Referencia para la detección de cambios.
   */
  constructor(
    private http: HttpClient,
    private divisaService: DivisaService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    // Inicialmente, no se realiza ninguna solicitud hasta que se seleccione una divisa
  }

  /**
   * Obtiene los datos de divisas para una divisa seleccionada.
   * @param divisa Divisa seleccionada.
   */
  obtenerDatosDivisas(divisa: string) {
    this.divisaSeleccionada = divisa;
    this.isLoading = true;

    // Cancelar cualquier suscripción anterior
    this.subscriptions.add(
      this.divisaService.getDivisasData(divisa).subscribe({
        next: (data) => {
          this.divisasData = data;
          this.updateChart(); // Actualizar el gráfico con los datos obtenidos
        },
        error: (err) => {
          console.error(
            'Error al obtener datos de divisas:',
            err.status,
            err.message,
            err
          );
          this.isLoading = false;
        },
        complete: () => {
          setTimeout(() => {
            this.isLoading = false;
          }, 1000);
        },
      })
    );
  }

  /**
   * Actualiza el gráfico con los datos recientes y las predicciones.
   */
  updateChart() {
    if (this.divisasData.length === 0) {
      console.error('No data available:', this.divisasData);
      return;
    }

    // Ordenar por fecha y tomar los últimos 10 registros
    const recentData = this.divisasData.slice(-10);
    const recentDates = recentData
      .map((d) => {
        const fecha = new Date(d.fecha);
        return !isNaN(fecha.getTime())
          ? fecha.toISOString().split('T')[0]
          : null;
      })
      .filter((date) => date !== null);

    const recentValues = recentData.map((d) => d.valor);
    this.valorActual = recentValues[recentValues.length - 1];

    this.http.post(this.apiUrl, { data: recentValues }).subscribe(
      (response: any) => {
        const predictions = response.Prediction || [];
        const interValConf = response.ConfidenceInterval || [];
        const predictionData = predictions.length
          ? predictions
          : new Array(10).fill(0);

        const lastDate = new Date(recentDates[recentDates.length - 1]);
        const predictionDates = predictionData.map((_, index) => {
          const nextDate = new Date(lastDate);
          nextDate.setDate(nextDate.getDate() + index + 1);
          return nextDate.toISOString().split('T')[0];
        });

        const lowerBounds = interValConf.map((interval) => interval[0]);
        const upperBounds = interValConf.map((interval) => interval[1]);

        const minimo = Math.min(
          ...recentValues,
          ...predictionData,
          ...lowerBounds,
          ...upperBounds
        );
        const maximo = Math.max(
          ...recentValues,
          ...predictionData,
          ...lowerBounds,
          ...upperBounds
        );
        const margen = (maximo - minimo) * 0.05;

        this.chartOptions = {
          series: [
            {
              name: 'Historical Data',
              data: recentValues.map((value, index) => [
                recentDates[index],
                value,
              ]),
              color: '#0000FF',
            },
            {
              name: 'Predictions',
              data: predictionData.map((value, index) => [
                predictionDates[index],
                value,
              ]),
              color: '#FF0000',
            },
            {
              name: 'CI Lower Bound',
              data: lowerBounds.map((value, index) => [
                predictionDates[index],
                value,
              ]),
              color: '#87CEEB',
            },
            {
              name: 'CI Upper Bound',
              data: upperBounds.map((value, index) => [
                predictionDates[index],
                value,
              ]),
              color: '#FF6347',
            },
          ],
          chart: {
            height: 350,
            type: 'line',
          },
          stroke: {
            width: [3, 3],
            curve: 'smooth',
          },
          xaxis: {
            type: 'datetime',
            categories: recentDates.concat(predictionDates),
          },
          title: {
            text: 'Evolución del Valor de la Divisa respecto al Dolar',
            align: 'left',
            style: {
              fontSize: '16px',
              color: '#666',
            },
          },
          fill: {
            type: 'solid',
            colors: ['#0000FF'],
          },
          markers: {
            size: 4,
            colors: ['#FFA41B'],
            strokeColors: '#fff',
            strokeWidth: 2,
            hover: {
              size: 7,
            },
          },
          yaxis: {
            min: minimo - margen,
            max: maximo + margen,
            title: {
              text: 'Valor relativo a USD',
            },
            labels: {
              formatter: (value) => value.toFixed(4),
            },
          },
        };

        this.cdr.detectChanges(); // Forzar la detección de cambios
      },
      (error) => {
        console.error('Error fetching data:', error);
        this.isLoading = false;
      }
    );
  }

  /**
   * Maneja el cambio de divisa en el selector.
   * @param event Evento del cambio en el selector.
   */
  onCurrencyChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    const selectedCurrency = selectElement.value;
    this.obtenerDatosDivisas(selectedCurrency);
  }

  ngOnDestroy(): void {
    // Cancelar todas las suscripciones al destruir el componente
    this.subscriptions.unsubscribe();
  }
}
