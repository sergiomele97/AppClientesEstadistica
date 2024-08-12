import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
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
import { IEnvio } from 'src/app/interfaces/envios';
import { EnviosService } from 'src/app/servicios/envios.service';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  dataLabels: ApexDataLabels;
  plotOptions: ApexPlotOptions;
  yaxis: ApexYAxis;
  xaxis: ApexXAxis;
  fill: ApexFill;
  title: ApexTitleSubtitle;
};

@Component({
  selector: 'app-outliers-detail-graph',
  templateUrl: './outliers-detail-graph.component.html',
  styleUrls: ['./outliers-detail-graph.component.css'],
})
export class OutliersDetailGraphComponent implements OnInit, OnDestroy {

  @ViewChild('chart') chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  constructor(private envioService: EnviosService) {}

  ngOnInit(): void {
    this.subscription = this.envioService.getEnvios().subscribe({
      next: (envios) => {
        this.envios = this.envioService.formatEnvios(envios);
        this.actualizarGrafico();
      },
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  subscription!: Subscription;
  envios: IEnvio[] = [];
  enviosFilter: IEnvio[] = [];

  private actualizarGrafico(): void {
    const primerosEnvios = this.envios.slice(0, 5);

    const fechas = primerosEnvios.map((envio) => envio.fecha); // Formatear fecha si es necesario
    const cantidad = primerosEnvios.map((envio) => envio.cantidad);

    this.chartOptions = {
      series: [
        {
          name: 'Envio',
          data: cantidad,
        },
      ],
      chart: {
        height: 0,
        type: 'bar',
      },
      plotOptions: {
        bar: {
          dataLabels: {
            position: 'top', // top, center, bottom
          },
        },
      },
      dataLabels: {
        enabled: true,
        offsetY: 0,
        style: {
          fontSize: '12px',
          colors: ['#304758'],
        },
      },

      xaxis: {
        categories: fechas,
        position: 'bottom',
        labels: {
          offsetY: 0,
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
          offsetY: 0,
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
          stops: [20, 0, 100, 100],
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
          show: false
        },
      },
      title: {
        text: 'Tabla de envios de dinero',
        floating: false,
        offsetY: 0,
        align: 'center',
        style: {
          color: '#444',
        },
      },
    };
  }
}
