import { Component, ViewChild } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Subscription } from "rxjs";
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
import { ICliente } from "src/app/interfaces/cliente";
import { ITransaccion } from "src/app/interfaces/transaccion";
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
    private router: Router,  
    private clienteService: ClienteEstService) {}

  cliente: ICliente | undefined;
  clientes: ICliente[] = [];
  subscription!: Subscription;

  ngOnInit(): void {
    // Obtener la lista de clientes
    this.subscription = this.clienteService.getClientes().subscribe({
      next: (clientes) => {
        this.clientes = clientes;
      },
      error: (err) => {
        console.error('Error al obtener la lista de clientes:', err);
      }
    });

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
  
  onSelectCliente(event: Event): void {
    const selectElement = event.target as HTMLSelectElement; // Asegurarte de que es un HTMLSelectElement
    const clienteId = Number(selectElement.value);
    this.router.navigate(['/estadisticas/clientes', clienteId]);
  }
  

  private actualizarGrafico(): void {
    if (!this.cliente) return;
  
    // Función para agrupar transacciones por fecha
    const agruparPorFecha = (transacciones: ITransaccion[], esIngreso: boolean) => {
      const resultado: Record<string, number> = {};
  
      transacciones.forEach(transaccion => {
        const fecha = new Date(transaccion.fecha || '').toLocaleDateString('es-ES', { day: '2-digit', month: '2-digit', year: 'numeric' });
        const cantidad = esIngreso ? transaccion.importeRecibido || 0 : transaccion.importeEnviado || 0;
  
        if (resultado[fecha]) {
          resultado[fecha] += cantidad;
        } else {
          resultado[fecha] = cantidad;
        }
      });
  
      return resultado;
    };
  
    // Obtener transacciones de ingreso y pérdida agrupadas por fecha
    const ingresosPorFecha = agruparPorFecha(this.cliente.transaccionesDestino || [], true);
    const perdidasPorFecha = agruparPorFecha(this.cliente.transaccionesOrigen || [], false);
  
    // Obtener todas las fechas únicas
    const fechas = Array.from(new Set([...Object.keys(ingresosPorFecha), ...Object.keys(perdidasPorFecha)]));
  
    // Crear datos para el gráfico
    const dataIngresos = fechas.map(fecha => ingresosPorFecha[fecha] || 0);
    const dataPerdidas = fechas.map(fecha => perdidasPorFecha[fecha] || 0);
  
    this.chartOptions = {
      series: [
        {
          name: "Ingresos",
          data: dataIngresos
        },
        {
          name: "Pérdidas",
          data: dataPerdidas
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
        formatter: (val) => `${val}`, // Puedes agregar el símbolo de la moneda si es necesario
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
        }
      },
      yaxis: {
        labels: {
          show: true,
          formatter: (val) => `${val}` // Puedes formatear el valor si es necesario
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
