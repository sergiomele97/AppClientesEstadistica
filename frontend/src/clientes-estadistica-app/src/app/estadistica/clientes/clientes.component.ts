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
import { ClienteEstService } from 'src/app/servicios/cliente-est.service';
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
  isLoading: boolean = true; // AGREGADO: variable de estado para el loader

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private clienteService: ClienteEstService,
    private transaccionService: TransaccionService,
    private currencyPipe: CustomCurrencyPipe
  ) {}

  cliente: ICliente | undefined;
  clientes: ICliente[] = [];
  transacciones: ITransaccion[];
  subscription!: Subscription;
  routeSubscription!: Subscription;
  balance: number = 0;

  ngOnInit(): void {
    this.isLoading = true; // AGREGADO: Mostrar loader al iniciar la carga

    // Obtener la lista de clientes
    this.subscription = this.clienteService.getClientes().subscribe({
      next: (clientes) => {
        this.clientes = clientes;
        this.isLoading = false; // AGREGADO: Ocultar loader después de cargar los datos
      },
      error: (err) => {
        console.error('Error al obtener la lista de clientes:', err);
        this.isLoading = false; // AGREGADO: Ocultar loader después de cargar los datos
      },
    });

    // Obtener el ID del cliente desde la ruta actual
    const clienteId = Number(this.route.snapshot.paramMap.get('id'));

    // Llamar a getCliente con el ID del cliente
    this.subscription = this.clienteService.getCliente(clienteId).subscribe({
      next: (cliente) => {
        // Asignar el cliente obtenido a la propiedad del componente
        this.cliente = cliente;

        // Obtener las transacciones relacionadas con el cliente
        this.subscription = this.transaccionService
          .getTransacciones()
          .subscribe({
            next: (transacciones) => {
              // Filtrar las transacciones relacionadas con el cliente
              this.transacciones = transacciones.filter(
                (t) =>
                  t.clienteOrigenId === clienteId ||
                  t.clienteDestinoId === clienteId
              );

              // Calcular el balance
              this.balance = this.calcularBalance(
                this.transacciones,
                clienteId
              );

              // Actualizar gráfico
              this.actualizarGrafico(this.transacciones);
            },
            error: (err) => {
              console.error('Error al obtener las transacciones:', err);
            },
          });
      },
      error: (err) => {
        console.error('Error al obtener el cliente:', err);
      },
    });

    // Suscribirse a los cambios de la ruta
    this.routeSubscription = this.route.paramMap.subscribe((params) => {
      const clienteId = Number(params.get('id'));
      this.loadCliente(clienteId);
    });
  }

  loadCliente(clienteId: number): void {
    // Llamar a getCliente con el ID del cliente
    this.subscription = this.clienteService.getCliente(clienteId).subscribe({
      next: (cliente) => {
        // Asignar el cliente obtenido a la propiedad del componente
        this.cliente = cliente;

        // Obtener las transacciones relacionadas con el cliente
        this.subscription = this.transaccionService
          .getTransacciones()
          .subscribe({
            next: (transacciones) => {
              // Filtrar las transacciones relacionadas con el cliente
              const transaccionesFiltradas = transacciones.filter(
                (t) =>
                  t.clienteOrigenId === clienteId ||
                  t.clienteDestinoId === clienteId
              );

              // Calcular el balance
              this.balance = this.calcularBalance(
                transaccionesFiltradas,
                clienteId
              );

              // Actualizar gráfico con las transacciones filtradas
              this.actualizarGrafico(transaccionesFiltradas);
            },
            error: (err) => {
              console.error('Error al obtener las transacciones:', err);
            },
          });
      },
      error: (err) => {
        console.error('Error al obtener el cliente:', err);
      },
    });
  }

  onSelectCliente(event: Event): void {
    const selectElement = event.target as HTMLSelectElement; // Asegurarte de que es un HTMLSelectElement
    const clienteId = Number(selectElement.value);
    this.router.navigate(['/estadistica/clientes', clienteId]);
  }

  private calcularBalance(transacciones: ITransaccion[], clienteId: number) {
    const ingresos = transacciones
      .filter((transaccion) => transaccion.clienteDestinoId === clienteId)
      .reduce(
        (total, transaccion) => total + (transaccion.importeRecibido || 0),
        0
      );
    const gastos = transacciones
      .filter((transaccion) => transaccion.clienteOrigenId === clienteId)
      .reduce(
        (total, transaccion) => total + (transaccion.importeRecibido || 0),
        0
      );
    return ingresos - gastos;
  }

  private actualizarGrafico(transacciones: ITransaccion[]): void {
    if (!transacciones || transacciones.length === 0) return;

    // Función para agrupar transacciones por mes y año
    const agruparPorMes = (
      transacciones: ITransaccion[],
      esIngreso: boolean
    ) => {
      const resultado: Record<string, number> = {};

      transacciones.forEach((transaccion) => {
        const fecha = new Date(transaccion.fecha || '');
        const mesAnio = `${fecha.getMonth() + 1}-${fecha.getFullYear()}`; // Formato MM-YYYY
        const cantidad = esIngreso
          ? transaccion.importeRecibido || 0
          : transaccion.importeEnviado || 0;

        if (resultado[mesAnio]) {
          resultado[mesAnio] += cantidad;
        } else {
          resultado[mesAnio] = cantidad;
        }
      });

      return resultado;
    };

    // Filtrar transacciones de ingreso y pérdida
    const transaccionesIngreso = transacciones.filter(
      (t) => t.clienteDestinoId === this.cliente?.clienteId
    );
    const transaccionesPerdida = transacciones.filter(
      (t) => t.clienteOrigenId === this.cliente?.clienteId
    );

    // Obtener transacciones de ingreso y pérdida agrupadas por mes y año
    const ingresosPorMes = agruparPorMes(transaccionesIngreso, true);
    const perdidasPorMes = agruparPorMes(transaccionesPerdida, false);

    // Obtener todos los meses únicos
    let meses = Array.from(
      new Set([...Object.keys(ingresosPorMes), ...Object.keys(perdidasPorMes)])
    );

    // Ordenar los meses en orden cronológico
    meses = meses.sort((a, b) => {
      const [mesA, anioA] = a.split('-').map(Number);
      const [mesB, anioB] = b.split('-').map(Number);
      const fechaA = new Date(anioA, mesA - 1);
      const fechaB = new Date(anioB, mesB - 1);
      return fechaA.getTime() - fechaB.getTime();
    });

    // Crear datos para el gráfico
    const dataIngresos = meses.map((mes) => ingresosPorMes[mes] || 0);
    const dataPerdidas = meses.map((mes) => perdidasPorMes[mes] || 0);

    this.chartOptions = {
      series: [
        {
          name: 'Ingresos',
          data: dataIngresos,
        },
        {
          name: 'Pérdidas',
          data: dataPerdidas,
        },
      ],
      chart: {
        type: 'bar',
        height: 350,
      },
      plotOptions: {
        bar: {
          dataLabels: {
            position: 'top',
          },
        },
      },
      dataLabels: {
        enabled: true,
        formatter: (val) => {
          // Ensure the value is a number and format it to 2 decimal places
          const formattedValue = typeof val === 'number' ? val.toFixed(2) : val;
          return `${formattedValue}`;
        },
        style: {
          fontSize: '12px',
          colors: ['#304758'],
        },
      },
      
      xaxis: {
        categories: meses,
        position: 'bottom',
        labels: {
          offsetY: 0,
          rotate: -45, // Rotar las etiquetas del mes si son muchas
          style: {
            fontSize: '12px',
          },
        },
        title: {
          text: 'Mes y Año',
        },
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
        title: {
          text: 'Montos (Ingresos y Pérdidas)',
        },
      },
      title: {
        text: 'Ingresos y Pérdidas del Cliente por Mes',
        align: 'center',
      },
    };
  }

  ngOnDestroy(): void {
    // Cancelar la suscripción cuando el componente se destruya
    this.subscription.unsubscribe();
  }
}
