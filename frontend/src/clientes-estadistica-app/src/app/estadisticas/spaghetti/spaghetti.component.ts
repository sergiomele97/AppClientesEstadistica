import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexYAxis,
  ApexLegend,
  ApexFill,
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
  public chartOptions: Partial<ChartOptions>;
  private subscription: Subscription;
  transacciones: ITransaccion[] = [];
  isLoading: boolean = true;

  constructor(private transaccionesService: TransaccionService) {}

  /**
   * Inicializa el componente, carga las transacciones y actualiza el gráfico.
   */
  ngOnInit(): void {
    this.isLoading = true; // Mostrar loader al iniciar la carga

    this.subscription = this.transaccionesService.getTransacciones().subscribe({
      next: (transacciones) => {
        this.updateChart(transacciones);
        this.isLoading = false; // Ocultar loader después de cargar los datos
      },
      error: (err) => {
        console.error('Error al obtener la lista de transacciones', err);
        this.isLoading = false; // Ocultar loader si hay un error
      },
    });
  }

  /**
   * Actualiza el gráfico con los datos de transacciones.
   * @param transacciones Lista de transacciones a mostrar en el gráfico.
   */
  updateChart(transacciones: ITransaccion[]) {
    const transaccionesPorMes = this.agruparTransaccionesPorMes(transacciones);

    // Calcular la media de transacciones por mes
    const totalClientes = Object.keys(transaccionesPorMes).length;
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

    const mediaPorMes: number[] = new Array(meses.length).fill(0);

    Object.values(transaccionesPorMes).forEach((mesData) => {
      meses.forEach((mes, index) => {
        mediaPorMes[index] += mesData[mes] || 0;
      });
    });

    mediaPorMes.forEach((total, index) => {
      mediaPorMes[index] = total / totalClientes;
    });

    const seriesData = Object.keys(transaccionesPorMes).map((clienteId) => ({
      name: `Cliente ${clienteId}`,
      data: meses.map((mes) => transaccionesPorMes[clienteId][mes] || 0),
    }));

    seriesData.push({
      name: 'Media de Transacciones',
      data: mediaPorMes,
    });

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
   * Obtiene el mes y año a partir de una fecha.
   * @param fecha Fecha de la transacción.
   * @returns Mes y año en formato MM-YYYY.
   */
  private obtenerMesYAnio(fecha: Date): string {
    const mes = fecha.getMonth() + 1;
    const anio = fecha.getFullYear();
    return `${mes < 10 ? '0' : ''}${mes}-${anio}`;
  }

  /**
   * Agrupa las transacciones por cliente y mes.
   * @param transacciones Lista de transacciones.
   * @returns Un objeto que mapea ID de cliente a un objeto que mapea mes a número de transacciones.
   */
  private agruparTransaccionesPorMes(
    transacciones: ITransaccion[]
  ): Record<string, Record<string, number>> {
    const transaccionesPorClienteYMes: Record<
      string,
      Record<string, number>
    > = {};

    transacciones.forEach((transaccion) => {
      const clienteId = transaccion.clienteOrigenId;
      const fechaTransaccion = new Date(transaccion.fecha);
      const mesAnio = this.obtenerMesYAnio(fechaTransaccion);

      if (!transaccionesPorClienteYMes[clienteId]) {
        transaccionesPorClienteYMes[clienteId] = {};
      }

      if (!transaccionesPorClienteYMes[clienteId][mesAnio]) {
        transaccionesPorClienteYMes[clienteId][mesAnio] = 0;
      }

      transaccionesPorClienteYMes[clienteId][mesAnio]++;
    });

    return transaccionesPorClienteYMes;
  }

  /**
   * Limpia los recursos utilizados por el componente.
   */
  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
