import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription, switchMap, forkJoin, of } from 'rxjs';
import {
  ApexAxisChartSeries,
  ApexChart,
  ChartComponent,
  ApexDataLabels,
  ApexPlotOptions,
  ApexYAxis,
  ApexXAxis,
  ApexTitleSubtitle,
} from 'ng-apexcharts';
import { ICliente } from 'src/app/interfaces/cliente';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { ClienteService } from 'src/app/servicios/cliente.service';
import { TransaccionService } from 'src/app/servicios/transaccion.service';
import { CustomCurrencyPipe } from 'src/app/pipes/customCurrency.pipe';

/**
 * Configuración del gráfico ApexCharts.
 */
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
  styleUrls: ['./clientes.component.css'],
})
export class ClientesComponent implements OnInit, OnDestroy {
  @ViewChild('chart') chart: ChartComponent; // Gráfico
  public chartOptions: Partial<ChartOptions>; // Opciones del gráfico
  isLoading: boolean = true; // Estado de carga

  /**
   * Constructor del componente.
   */
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private clienteService: ClienteService,
    private transaccionService: TransaccionService,
    private currencyPipe: CustomCurrencyPipe
  ) {}

  cliente: ICliente | undefined; // Cliente actual
  clientes: ICliente[] = []; // Lista de clientes
  transacciones: ITransaccion[] = []; // Transacciones del cliente
  private subscriptions: Subscription = new Subscription(); // Agrupación de suscripciones
  balance: number = 0; // Balance del cliente

  /**
   * Inicializa el componente y carga datos.
   */
  ngOnInit(): void {
    this.isLoading = true; // Mostrar carga

    // Obtener clientes
    this.subscriptions.add(
      this.clienteService.getClientes().subscribe({
        next: (clientes) => {
          this.clientes = clientes;
          this.isLoading = false; // Ocultar carga
        },
        error: (err) => {
          console.error('Error al obtener clientes:', err);
          this.isLoading = false;
        },
      })
    );

    // Escuchar cambios en la ruta
    this.subscriptions.add(
      this.route.paramMap
        .pipe(
          switchMap((params) => {
            const clienteId = Number(params.get('id'));
            return forkJoin({
              cliente: this.clienteService.getCliente(clienteId),
              transacciones: this.transaccionService.getTransacciones(),
            });
          })
        )
        .subscribe({
          next: ({ cliente, transacciones }) => {
            this.cliente = cliente;
            this.transacciones = transacciones.filter(
              (t) =>
                t.clienteOrigenId === this.cliente?.clienteId ||
                t.clienteDestinoId === this.cliente?.clienteId
            );
            this.balance = this.calcularBalance(
              this.transacciones,
              this.cliente?.clienteId || 0
            );
            this.actualizarGrafico(this.transacciones);
            this.isLoading = false;
          },
          error: (err) => {
            console.error('Error al obtener datos:', err);
            this.isLoading = false;
          },
        })
    );
  }

  /**
   * Maneja la selección de cliente.
   * @param event - Evento de selección.
   */
  onSelectCliente(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    const clienteId = Number(selectElement.value);
    this.router.navigate(['/estadistica/clientes', clienteId]);
  }

  /**
   * Calcula el balance del cliente.
   * @param transacciones - Lista de transacciones.
   * @param clienteId - ID del cliente.
   * @returns El balance calculado.
   */
  private calcularBalance(
    transacciones: ITransaccion[],
    clienteId: number
  ): number {
    const ingresos = transacciones
      .filter((t) => t.clienteDestinoId === clienteId)
      .reduce((total, t) => total + (t.importeRecibido || 0), 0);
    const gastos = transacciones
      .filter((t) => t.clienteOrigenId === clienteId)
      .reduce((total, t) => total + (t.importeEnviado || 0), 0);
    return ingresos - gastos;
  }

  /**
   * Actualiza el gráfico con las transacciones del cliente.
   * @param transacciones - Lista de transacciones.
   */
  private actualizarGrafico(transacciones: ITransaccion[]): void {
    if (!transacciones.length) return;

    const agruparPorMes = (
      transacciones: ITransaccion[],
      esIngreso: boolean
    ) => {
      const resultado: Record<string, number> = {};
      transacciones.forEach((t) => {
        const fecha = new Date(t.fecha || '');
        const mesAnio = `${fecha.getMonth() + 1}-${fecha.getFullYear()}`;
        const cantidad = esIngreso
          ? t.importeRecibido || 0
          : t.importeEnviado || 0;
        resultado[mesAnio] = (resultado[mesAnio] || 0) + cantidad;
      });
      return resultado;
    };

    const ingresosPorMes = agruparPorMes(
      transacciones.filter(
        (t) => t.clienteDestinoId === this.cliente?.clienteId
      ),
      true
    );
    const perdidasPorMes = agruparPorMes(
      transacciones.filter(
        (t) => t.clienteOrigenId === this.cliente?.clienteId
      ),
      false
    );

    const meses = Array.from(
      new Set([...Object.keys(ingresosPorMes), ...Object.keys(perdidasPorMes)])
    ).sort((a, b) => {
      const [mesA, anioA] = a.split('-').map(Number);
      const [mesB, anioB] = b.split('-').map(Number);
      return (
        new Date(anioA, mesA - 1).getTime() -
        new Date(anioB, mesB - 1).getTime()
      );
    });

    const dataIngresos = meses.map((mes) => ingresosPorMes[mes] || 0);
    const dataPerdidas = meses.map((mes) => perdidasPorMes[mes] || 0);

    this.chartOptions = {
      series: [
        { name: 'Ingresos', data: dataIngresos },
        { name: 'Pérdidas', data: dataPerdidas },
      ],
      chart: { type: 'bar', height: 350 },
      plotOptions: { bar: { dataLabels: { position: 'top' } } },
      dataLabels: {
        enabled: true,
        formatter: (val) => {
          const formattedValue = typeof val === 'number' ? val.toFixed(2) : val;
          return `${formattedValue}`;
        },
        style: { fontSize: '12px', colors: ['#304758'] },
      },
      xaxis: {
        categories: meses,
        labels: { rotate: -45, style: { fontSize: '12px' } },
        title: { text: 'Mes y Año' },
      },
      yaxis: {
        labels: {
          formatter: (val) =>
            this.currencyPipe.transform(
              val,
              this.cliente?.pais.divisa || 'USD'
            ),
        },
        title: { text: 'Montos (Ingresos y Pérdidas)' },
      },
      title: {
        text: 'Ingresos y Pérdidas del Cliente por Mes',
        align: 'center',
      },
    };
  }

  /**
   * Limpia las suscripciones al destruir el componente.
   */
  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }
}
