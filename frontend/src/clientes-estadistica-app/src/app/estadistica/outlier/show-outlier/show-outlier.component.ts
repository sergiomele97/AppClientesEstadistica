import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {
  ApexAxisChartSeries,
  ApexChart,
  ChartComponent,
  ApexDataLabels,
  ApexPlotOptions,
  ApexYAxis,
  ApexTitleSubtitle,
  ApexXAxis,
  ApexFill,
} from 'ng-apexcharts';
import { Subscription } from 'rxjs';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { FormaterFechaPipe } from 'src/app/pipes/formaterFecha.pipe';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

/**
 * Define las opciones de configuración para el gráfico.
 */
export type ChartOptions = {
  series: ApexAxisChartSeries; // Serie de datos a mostrar en el gráfico
  chart: ApexChart; // Configuración del tipo de gráfico
  dataLabels: ApexDataLabels; // Configuración de las etiquetas de datos
  plotOptions: ApexPlotOptions; // Configuración de las opciones de trazado
  yaxis: ApexYAxis; // Configuración del eje Y
  xaxis: ApexXAxis; // Configuración del eje X
  fill: ApexFill; // Configuración de relleno del gráfico
  title: ApexTitleSubtitle; // Configuración del título del gráfico
  colors: string[]; // Colores para las series del gráfico
};

@Component({
  selector: 'app-show-outlier',
  templateUrl: './show-outlier.component.html',
  styleUrls: ['./show-outlier.component.css'],
})
export class ShowOutlierComponent implements OnInit, OnDestroy {
  @ViewChild('chart') chart: ChartComponent; // Referencia al componente del gráfico
  public chartOptions: Partial<ChartOptions>; // Opciones de configuración del gráfico

  transacciones: ITransaccion[]; // Lista de transacciones a mostrar
  idTransaccion: number; // ID de la transacción actual
  successMessage: string; // Mensaje de éxito
  errorMessage: string; // Mensaje de error
  subscription: Subscription = new Subscription(); // Manejo de suscripciones

  /**
   * Crea una instancia del componente `ShowOutlierComponent`.
   * @param transaccionService - Servicio para operaciones con transacciones
   * @param route - Servicio para obtener parámetros de la ruta activa
   * @param formaterFechaPipe - Pipe para formatear fechas
   */
  constructor(
    private transaccionService: TransaccionService,
    private route: ActivatedRoute,
    private formaterFechaPipe: FormaterFechaPipe
  ) {}

  /**
   * Inicializa el componente cargando las transacciones y configurando el gráfico.
   */
  ngOnInit(): void {
    const clienteId = Number(this.route.snapshot.paramMap.get('id'));

    this.subscription.add(
      this.transaccionService.ultimasTransacciones(clienteId).subscribe({
        next: (transacciones) => {
          this.transacciones = transacciones;
          this.actualizarGrafico();
        },
        error: (err) => {
          console.error('Error al obtener las transacciones:', err);
        },
      })
    );
  }

  /**
   * Elimina un outlier y actualiza la lista de transacciones.
   * @param idTransaccion - ID de la transacción a eliminar
   */
  borrarOutlier(idTransaccion: number): void {
    this.subscription.add(
      this.transaccionService.borrarOutlier(idTransaccion).subscribe({
        next: (response) => {
          this.successMessage = 'Outlier resuelto correctamente.';
          this.errorMessage = null;
          this.actualizarTransacciones();
          this.hideMessagesAfterDelay();
        },
        error: (err) => {
          this.errorMessage =
            'Error al resolver el outlier. Por favor, intente de nuevo.';
          this.successMessage = null;
          this.hideMessagesAfterDelay();
          console.error('Error: ', err);
        },
      })
    );
  }

  /**
   * Actualiza la lista de transacciones y el gráfico correspondiente.
   */
  actualizarTransacciones(): void {
    const clienteId = Number(this.route.snapshot.paramMap.get('id'));

    this.subscription.add(
      this.transaccionService.ultimasTransacciones(clienteId).subscribe({
        next: (transacciones) => {
          this.transacciones = transacciones;
          this.actualizarGrafico();
        },
        error: (err) => {
          console.error('Error al actualizar las transacciones:', err);
        },
      })
    );
  }

  /**
   * Oculta los mensajes de éxito o error después de un breve retraso.
   */
  hideMessagesAfterDelay(): void {
    setTimeout(() => {
      this.successMessage = null;
      this.errorMessage = null;
    }, 3000);
  }

  /**
   * Actualiza las opciones del gráfico con los datos de las transacciones.
   */
  actualizarGrafico(): void {
    if (!this.transacciones || this.transacciones.length === 0) {
      return;
    }

    // Transforma los datos para el gráfico
    const fechas = this.transacciones.map((t) =>
      this.formaterFechaPipe.transform(t.fecha)
    );
    const importeEnviado = this.transacciones.map((t) => t.importeEnviado);

    // Configura las opciones del gráfico
    this.chartOptions = {
      series: [
        {
          name: 'Dinero enviado',
          data: importeEnviado,
        },
      ],
      chart: {
        height: 350,
        type: 'bar',
      },
      plotOptions: {
        bar: {
          dataLabels: {
            position: 'top',
          },
          colors: {
            ranges: this.transacciones.map((t) => ({
              from: t.importeEnviado,
              to: t.importeEnviado,
              color: t.isOutlier ? '#FF4560' : '#008FFB', // Rojo para outliers, azul para otros
            })),
          },
        },
      },
      dataLabels: {
        enabled: true,
        offsetY: -20,
        style: {
          fontSize: '12px',
          colors: ['#304758'],
        },
      },
      xaxis: {
        categories: fechas,
        position: 'top',
        labels: {
          offsetY: -18,
        },
        axisBorder: {
          show: false,
        },
        axisTicks: {
          show: false,
        },
        crosshairs: {
          fill: {
            type: 'gradient',
            gradient: {
              colorFrom: '#D8E3F0',
              colorTo: '#BED1E6',
              stops: [0, 100],
              opacityFrom: 0.4,
              opacityTo: 0.5,
            },
          },
        },
        tooltip: {
          enabled: true,
          offsetY: -35,
        },
      },
      fill: {
        type: 'gradient',
        gradient: {
          shade: 'light',
          type: 'horizontal',
          shadeIntensity: 0.25,
          gradientToColors: undefined,
          inverseColors: true,
          opacityFrom: 1,
          opacityTo: 1,
          stops: [50, 0, 100, 100],
        },
      },
      yaxis: {
        axisBorder: {
          show: false,
        },
        axisTicks: {
          show: false,
        },
      },
      title: {
        text: 'Transacciones del Cliente',
        floating: false,
        offsetY: 325,
        align: 'center',
        style: {
          color: '#444',
        },
      },
    };
  }

  /**
   * Limpia las suscripciones al destruir el componente.
   */
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
