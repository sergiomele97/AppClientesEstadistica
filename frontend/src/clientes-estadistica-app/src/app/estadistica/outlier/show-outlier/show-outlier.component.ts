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
import { ICliente } from 'src/app/interfaces/cliente';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { FormaterFechaPipe } from 'src/app/pipes/formaterFecha.pipe';
import { SignalrService } from 'src/app/servicios/signalr.service';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  dataLabels: ApexDataLabels;
  plotOptions: ApexPlotOptions;
  yaxis: ApexYAxis;
  xaxis: ApexXAxis;
  fill: ApexFill;
  title: ApexTitleSubtitle;
  colors: string[];
};

@Component({
  selector: 'app-show-outlier',
  templateUrl: './show-outlier.component.html',
  styleUrls: ['./show-outlier.component.css'],
})
export class ShowOutlierComponent implements OnInit, OnDestroy {
  @ViewChild('chart') chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  cliente: ICliente;
  transacciones: ITransaccion[];
  idTransaccion: number;
  successMessage: string;
  errorMessage: string;
  subscription: Subscription = new Subscription();

  constructor(
    private transaccionService: TransaccionService,
    private route: ActivatedRoute,
    private formaterFechaPipe: FormaterFechaPipe,
    private signalrService: SignalrService,
  ) {}

  ngOnInit(): void {
    const clienteId = Number(this.route.snapshot.paramMap.get('id'));

    this.subscription.add(
      this.transaccionService.ultimasTransacciones(clienteId).subscribe({
        next: (transaccion) => {
          this.transacciones = transaccion;
          this.actualizarGrafico();
        },
        error: (err) => {
          console.error('Error al obtener las transacciones:', err);
        },
      })
    );
  }

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
            'Error al resolver el outlier. Por favor, intentelo de nuevo.';
          this.successMessage = null;
          this.hideMessagesAfterDelay();
          console.error('Error: ', err);
        },
      })
    );
  }

  actualizarTransacciones(): void {
    const clienteId = Number(this.route.snapshot.paramMap.get('id'));

    this.subscription.add(
      this.transaccionService.ultimasTransacciones(clienteId).subscribe({
        next: (datos) => {
          this.transacciones = datos;
          this.actualizarGrafico();
        },
        error: (err) => {
          console.error('Error al actualizar las transacciones:', err);
        },
      })
    );
  }

  hideMessagesAfterDelay(): void {
    setTimeout(() => {
      this.successMessage = null;
      this.errorMessage = null;
    }, 3000);
  }

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
            // Utiliza una función para aplicar colores dinámicos
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
        labels: {
          show: false,
          formatter: function (val) {
            return val + '€';
          },
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

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
