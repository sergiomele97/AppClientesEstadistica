import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
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
  @ViewChild('chart') chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;
  isLoading: boolean = true; // Estado de carga

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private clienteService: ClienteService,
    private transaccionService: TransaccionService,
    private currencyPipe: CustomCurrencyPipe
  ) {}

  cliente: ICliente | undefined;
  clientes: ICliente[] = [];
  transacciones: ITransaccion[] = [];
  subscription!: Subscription;
  routeSubscription!: Subscription;
  balance: number = 0;

  ngOnInit(): void {
    this.isLoading = true; // Mostrar loader

    // Obtener clientes
    this.subscription = this.clienteService.getClientes().subscribe({
      next: (clientes) => {
        this.clientes = clientes;
        this.isLoading = false; // Ocultar loader
      },
      error: (err) => {
        console.error('Error al obtener clientes:', err);
        this.isLoading = false; // Ocultar loader en caso de error
      },
    });

    // Obtener cliente y transacciones
    const clienteId = Number(this.route.snapshot.paramMap.get('id'));
    this.loadCliente(clienteId);

    // Suscribirse a cambios en la ruta
    this.routeSubscription = this.route.paramMap.subscribe((params) => {
      const clienteId = Number(params.get('id'));
      this.loadCliente(clienteId);
    });
  }

  loadCliente(clienteId: number): void {
    // Obtener cliente por ID
    this.subscription = this.clienteService.getCliente(clienteId).subscribe({
      next: (cliente) => {
        this.cliente = cliente;

        // Obtener transacciones del cliente
        this.subscription = this.transaccionService
          .getTransacciones()
          .subscribe({
            next: (transacciones) => {
              this.transacciones = transacciones.filter(
                (t) =>
                  t.clienteOrigenId === clienteId ||
                  t.clienteDestinoId === clienteId
              );
              this.balance = this.calcularBalance(
                this.transacciones,
                clienteId
              );
              this.actualizarGrafico(this.transacciones);
            },
            error: (err) => {
              console.error('Error al obtener transacciones:', err);
            },
          });
      },
      error: (err) => {
        console.error('Error al obtener cliente:', err);
      },
    });
  }

  onSelectCliente(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    const clienteId = Number(selectElement.value);
    this.router.navigate(['/estadistica/clientes', clienteId]);
  }

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

  private actualizarGrafico(transacciones: ITransaccion[]): void {
    if (!transacciones.length) return;

    // Agrupar transacciones por mes
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

    // Obtener meses únicos y ordenarlos
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

    // Crear datos para el gráfico
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
        position: 'bottom',
        labels: { offsetY: 0, rotate: -45, style: { fontSize: '12px' } },
        title: { text: 'Mes y Año' },
      },
      yaxis: {
        labels: {
          show: true,
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

  ngOnDestroy(): void {
    // Cancelar suscripciones
    this.subscription.unsubscribe();
    this.routeSubscription.unsubscribe();
  }
}
