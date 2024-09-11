import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexYAxis,
  ApexLegend,
  ApexGrid,
  ApexStroke,
  ApexTitleSubtitle,
} from 'ng-apexcharts';
import { Subscription } from 'rxjs';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  dataLabels: ApexDataLabels;
  yaxis: ApexYAxis;
  grid: ApexGrid;
  stroke: ApexStroke;
  title: ApexTitleSubtitle;
  legend: ApexLegend;
  colors?: string[];
  tooltip?: any;
};

@Component({
  selector: 'app-spaghetti',
  templateUrl: './spaghetti.component.html',
  styleUrls: ['./spaghetti.component.css'],
})
export class SpaghettiComponent implements OnInit, OnDestroy {
  @ViewChild('chart') chart: ChartComponent;
  public chartOptions: Partial<ChartOptions> = {};
  private subscription: Subscription = new Subscription();
  transacciones: ITransaccion[] = [];
  isLoading: boolean = true;

  constructor(private transaccionesService: TransaccionService) {}

  ngOnInit(): void {
    this.isLoading = true; // Mostrar loader al iniciar la carga
    this.subscription.add(
      this.transaccionesService.getTransacciones().subscribe({
        next: (transacciones) => {
          this.transacciones = transacciones;
          this.updateChart();
          this.isLoading = false; // Ocultar loader después de cargar los datos
        },
        error: (err) => {
          console.error('Error al obtener la lista de transacciones', err);
          this.isLoading = false; // Ocultar loader si hay un error
        },
      })
    );
  }

  /**
   * Actualiza el gráfico con los datos de transacciones.
   */
  private updateChart() {
    const transaccionesPorMes = this.agruparTransaccionesPorMes(
      this.transacciones
    );

    // Calcular la media de transacciones por mes
    const meses = this.obtenerMesesOrdenados(transaccionesPorMes);

    const mediaPorMes: number[] = meses.map(
      (mes) =>
        Object.values(transaccionesPorMes).reduce(
          (total, clienteData) => total + (clienteData[mes] || 0),
          0
        ) / Object.keys(transaccionesPorMes).length
    );

    const seriesData = this.crearSeriesData(
      transaccionesPorMes,
      meses,
      mediaPorMes
    );

    this.chartOptions = {
      series: seriesData,
      chart: {
        type: 'line',
        height: 350,
        animations: {
          enabled: false, // Desactivar animaciones para una carga más rápida
        },
      },
      colors: [...Array(seriesData.length - 1).fill('#008FFB'), '#FF4560'], // Colores para las series
      stroke: {
        curve: 'smooth',
        width: seriesData.map((_, index) =>
          index === seriesData.length - 1 ? 5 : 1
        ), // Ancho de las líneas
      },
      xaxis: {
        categories: meses,
        title: {
          text: 'Mes',
        },
      },
      yaxis: {
        title: {
          text: 'Número de Transacciones',
        },
        labels: {
          formatter: (value: number) => Math.floor(value).toString(), // Redondear valores
        },
      },
      dataLabels: {
        enabled: false,
      },
      title: {
        text: 'Transacciones por Mes y Media',
        align: 'center',
      },
      legend: {
        position: 'top',
        horizontalAlign: 'left',
        show: false, // Ocultar leyenda
      },
      tooltip: {
        enabled: true,
        shared: false,
        custom: ({ series, seriesIndex, dataPointIndex, w }) => {
          const mediaSeriesIndex = series.length - 1;
          const mediaValue = series[mediaSeriesIndex][dataPointIndex];

          return `
            <div>
              <strong>Media de Transacciones</strong><br>
              Mes: ${w.config.xaxis.categories[dataPointIndex]}<br>
              Valor: ${mediaValue}
            </div>
          `;
        },
      },
      grid: {
        row: {
          colors: ['#f3f3f3', 'transparent'], // Alternar colores de filas
          opacity: 0.5,
        },
      },
    };
  }

  /**
   * Obtiene un array de meses ordenados a partir de las transacciones.
   * @param transaccionesPorMes - Transacciones agrupadas por mes.
   * @returns Un array de meses ordenados.
   */
  private obtenerMesesOrdenados(
    transaccionesPorMes: Record<string, Record<string, number>>
  ): string[] {
    const meses = Array.from(
      new Set(
        Object.values(transaccionesPorMes).flatMap((clienteData) =>
          Object.keys(clienteData)
        )
      )
    ).sort((a, b) => {
      const [mesA, anioA] = a.split('-').map(Number);
      const [mesB, anioB] = b.split('-').map(Number);
      return anioA !== anioB ? anioA - anioB : mesA - mesB;
    });

    return meses;
  }

  /**
   * Crea los datos de series para el gráfico.
   * @param transaccionesPorMes - Transacciones agrupadas por mes.
   * @param meses - Array de meses ordenados.
   * @param mediaPorMes - Array de medias por mes.
   * @returns Datos de series para el gráfico.
   */
  private crearSeriesData(
    transaccionesPorMes: Record<string, Record<string, number>>,
    meses: string[],
    mediaPorMes: number[]
  ): ApexAxisChartSeries {
    const seriesData = Object.keys(transaccionesPorMes).map((clienteId) => ({
      name: `Cliente ${clienteId}`,
      data: meses.map((mes) => transaccionesPorMes[clienteId][mes] || 0),
    }));

    seriesData.push({
      name: 'Media de Transacciones',
      data: mediaPorMes,
    });

    return seriesData;
  }

  /**
   * Agrupa las transacciones por cliente y mes.
   * @param transacciones Lista de transacciones.
   * @returns Un objeto que mapea ID de cliente a un objeto que mapea mes a número de transacciones.
   */
  private agruparTransaccionesPorMes(
    transacciones: ITransaccion[]
  ): Record<string, Record<string, number>> {
    return transacciones.reduce((acc, transaccion) => {
      const clienteId = transaccion.clienteOrigenId;
      const mesAnio = this.obtenerMesYAnio(new Date(transaccion.fecha));

      if (!acc[clienteId]) {
        acc[clienteId] = {};
      }

      if (!acc[clienteId][mesAnio]) {
        acc[clienteId][mesAnio] = 0;
      }

      acc[clienteId][mesAnio]++;
      return acc;
    }, {} as Record<string, Record<string, number>>);
  }

  /**
   * Obtiene el mes y año a partir de una fecha.
   * @param fecha Fecha de la transacción.
   * @returns Mes y año en formato MM-YYYY.
   */
  private obtenerMesYAnio(fecha: Date): string {
    const mes = fecha.getMonth() + 1;
    const anio = fecha.getFullYear();
    return `${mes < 10 ? '0' : ''}${mes}-${anio}`;
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe(); // Cancelar suscripción
  }
}
