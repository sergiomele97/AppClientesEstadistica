import { Component, ViewChild } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import {
  ApexAxisChartSeries,
  ApexChart,
  ChartComponent,
  ApexDataLabels,
  ApexPlotOptions,
  ApexYAxis,
  ApexXAxis,
  ApexTitleSubtitle
} from "ng-apexcharts";
import { Subscription } from "rxjs";
import { ICliente } from "src/app/interfaces/cliente";
import { ClienteEstService } from "src/app/servicios/cliente-est.service";

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  dataLabels: ApexDataLabels;
  plotOptions: ApexPlotOptions;
  yaxis: ApexYAxis;
  xaxis: ApexXAxis;
  title: ApexTitleSubtitle;
};

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})

export class ClientesComponent  {
  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  constructor(
    private route: ActivatedRoute,
    private clienteService: ClienteEstService) {}

  cliente: ICliente | undefined;
  subscription!: Subscription;

  ngOnInit(): void {
    // Obtener el ID del cliente desde la ruta actual
    const clienteId = Number(this.route.snapshot.paramMap.get('id'));
    
    // Llamar a getCliente con el ID del cliente
    this.subscription = this.clienteService.getCliente(clienteId).subscribe({
      next: (cliente) => {
        // Asignar el cliente obtenido a la propiedad del componente
        this.cliente = cliente;
        // Actualizar gráfico
        this.actualizarGrafico();
      },
      error: (err) => {
        console.error('Error al obtener el cliente:', err);
      }
    });
  }

  private actualizarGrafico(): void {
    const ingresos = this.cliente.transaccionesDestino?.map(transaccion => ({
      fecha: new Date(transaccion.fecha).toLocaleDateString('es-ES', { day: '2-digit', month: '2-digit', year: 'numeric' }),
      cantidad: transaccion.cantidad
    }));
  
    const perdidas = this.cliente.transaccionesOrigen?.map(transaccion => ({
      fecha: new Date(transaccion.fecha).toLocaleDateString('es-ES', { day: '2-digit', month: '2-digit', year: 'numeric' }),
      cantidad: transaccion.cantidad
    }));
  
    this.chartOptions = {
      series: [
        {
          name: "Ingresos",
          data: ingresos?.map(trans => trans.cantidad) || []
        },
        {
          name: "Pérdidas",
          data: perdidas?.map(trans => trans.cantidad) || []
        }
      ],
      chart: {
        type: "bar",
        height: 350
      },
      plotOptions: {
        bar: {
          dataLabels: {
            position: "top"
          }
        }
      },
      dataLabels: {
        enabled: true,
        formatter: (val, opts) => `${val} ${this.cliente.transaccionesOrigen?.[opts.dataPointIndex]?.divisa || ''}`,
        style: {
          fontSize: "12px",
          colors: ["#304758"]
        }
      },
      xaxis: {
        categories: ingresos?.map(trans => trans.fecha) || perdidas?.map(trans => trans.fecha) || [],
        position: "bottom",
        labels: {
          offsetY: 0
        }
      },
      yaxis: {
        labels: {
          show: true,
          formatter: function (val) {
            return `${val}`;
          },
        }
      },
      title: {
        text: "Ingresos y Pérdidas del Cliente",
        align: "center"
      }
    };
  }
  
  ngOnDestroy(): void {
    // Cancelar la suscripción cuando el componente se destruya
    this.subscription.unsubscribe();
  }
}
