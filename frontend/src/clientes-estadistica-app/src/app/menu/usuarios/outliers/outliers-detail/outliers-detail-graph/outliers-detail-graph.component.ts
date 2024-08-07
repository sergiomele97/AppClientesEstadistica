import { Component, OnInit, ViewChild } from '@angular/core';
import {
  ApexAxisChartSeries,
  ApexChart,
  ChartComponent,
  ApexDataLabels,
  ApexPlotOptions,
  ApexYAxis,
  ApexTitleSubtitle,
  ApexXAxis,
  ApexFill
} from "ng-apexcharts";
import { UserService } from 'src/app/servicios/user.service';

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
  styleUrls: ['./outliers-detail-graph.component.css']
})

export class OutliersDetailGraphComponent implements OnInit {

  envios: any[];

  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  ngOnInit(): void {
      this.userService.getEnvios().subscribe( datos => {
        this.envios = datos;
        this.actualizarGrafico(); 
        console.log(datos);
      });
  }

  constructor(private userService: UserService) {}


  private actualizarGrafico(): void {

    const primerosEnvios = this.envios.slice(0, 5);

    const fechas = primerosEnvios.map(envio => envio.fecha); // Formatear fecha si es necesario
    const cantidad = primerosEnvios.map(envio => envio.cantidad);

    this.chartOptions = {
      series: [
        {
          name: "Envio",
          data: cantidad
        }
      ],
      chart: {
        height: 0,
        type: "bar"
      },
      plotOptions: {
        bar: {
          dataLabels: {
            position: "top" // top, center, bottom
          }
        }
      },
      dataLabels: {
        enabled: true,
        formatter: function(val) {
          return val + "€";
        },
        offsetY: 0,
        style: {
          fontSize: "12px",
          colors: ["#304758"]
        }
      },

      xaxis: {
        categories: fechas,
        position: "bottom",
        labels: {
          offsetY: 0
        },
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        crosshairs: {
          fill: {
            type: "gradient",
            gradient: {
              colorFrom: "#D8E3F0",
              colorTo: "#BED1E6",
              stops: [0, 100],
              opacityFrom: 0.4,
              opacityTo: 0.5
            }
          }
        },
        tooltip: {
          enabled: true,
          offsetY: 0
        }
      },
      fill: {
        type: "gradient",
        gradient: {
          shade: "light",
          type: "horizontal",
          shadeIntensity: 0.25,
          gradientToColors: undefined,
          inverseColors: true,
          opacityFrom: 1,
          opacityTo: 1,
          stops: [20, 0, 100, 100]
        }
      },
      yaxis: {
        axisBorder: {
          show: false
        },
        axisTicks: {
          show: false
        },
        labels: {
          show: false,
          formatter: function(val) {
            return val + "€";
          }
        }
      },
      title: {
        text: "Tabla de envios de dinero",
        floating: false,
        offsetY: 0,
        align: "center",
        style: {
          color: "#444"
        }
      }
    };
  }

}
