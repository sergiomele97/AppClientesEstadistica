import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexTitleSubtitle,
  ApexStroke,
  ApexGrid,
} from 'ng-apexcharts';
import { Subscription } from 'rxjs';
import { IConversion } from 'src/app/interfaces/conversion';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { ConversionService } from 'src/app/servicios/conversion.service';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  dataLabels: ApexDataLabels;
  grid: ApexGrid;
  stroke: ApexStroke;
  title: ApexTitleSubtitle;
};

@Component({
  selector: 'app-volumetry',
  templateUrl: './volumetry.component.html',
  styleUrls: ['./volumetry.component.css'],
})
export class VolumetryComponent implements OnInit, OnDestroy {
  @ViewChild('chart') chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;
  public dataType: string = ''; // Cambiar valor inicial a 'transacciones'
  public isLoading: boolean = true; // AGREGADO: Estado de carga

  transacciones: ITransaccion[] = [];
  conversiones: IConversion[] = [];
  subscription: Subscription;

  constructor(
    private transaccionesService: TransaccionService,
    private conversionesService: ConversionService
  ) {}

  ngOnInit(): void {
    // Mostrar el loader al iniciar
    this.isLoading = true;

    // Obtener lista de transacciones y conversiones
    this.subscription = this.transaccionesService.getTransacciones().subscribe({
      next: (transacciones) => {
        this.transacciones = transacciones;
        this.updateChart(); // Actualizar gráfico con datos predeterminados
        this.isLoading = false; // Ocultar loader después de cargar los datos
      },
      error: (err) => {
        console.error('Error al obtener la lista de transacciones', err);
        this.isLoading = false; // Ocultar loader si hay un error
      },
    });

    this.subscription.add(
      this.conversionesService.getConversiones().subscribe({
        next: (conversiones) => {
          this.conversiones = conversiones;
          this.updateChart(); // Actualizar gráfico con datos predeterminados
          this.isLoading = false; // Ocultar loader después de cargar los datos
        },
        error: (err) => {
          console.error('Error al obtener la lista de conversiones', err);
          this.isLoading = false; // Ocultar loader si hay un error
        },
      })
    );
  }

  updateChart() {
    let data = [];

    if (this.dataType === 'transacciones') {
      data = this.transacciones;
    } else if (this.dataType === 'conversiones') {
      data = this.conversiones;
    } else {
      console.warn('Tipo de dato no reconocido:', this.dataType);
      return;
    }

    // Agrupar datos por mes y año
    const agruparPorMes = (data: any[]) => {
      const resultado: Record<string, number> = {};
      data.forEach((item) => {
        const fecha = new Date(item.fecha);
        const mesAnio = `${fecha.getMonth() + 1}-${fecha.getFullYear()}`; // Formato MM-YYYY
        const cantidad = 1; // Conteo por mes

        if (resultado[mesAnio]) {
          resultado[mesAnio] += cantidad;
        } else {
          resultado[mesAnio] = cantidad;
        }
      });
      return resultado;
    };

    const datosAgrupados = agruparPorMes(data);

    // Ordenar meses
    const meses = Object.keys(datosAgrupados).sort((a, b) => {
      const [mesA, anioA] = a.split('-').map(Number);
      const [mesB, anioB] = b.split('-').map(Number);
      const fechaA = new Date(anioA, mesA - 1);
      const fechaB = new Date(anioB, mesB - 1);
      return fechaA.getTime() - fechaB.getTime();
    });

    // Obtener conteo por mes en el orden de meses ordenados
    const conteoPorMes = meses.map((mes) => datosAgrupados[mes]);

    this.chartOptions = {
      series: [
        {
          name:
            this.dataType === 'transacciones'
              ? 'Transacciones'
              : 'Conversiones',
          data: conteoPorMes,
        },
      ],
      chart: {
        height: 350,
        type: 'line',
        zoom: {
          enabled: false,
        },
      },
      dataLabels: {
        enabled: true,
      },
      stroke: {
        curve: 'smooth',
      },
      title: {
        text:
          this.dataType === 'transacciones'
            ? 'Transacciones / Mes'
            : 'Conversiones / Mes',
        align: 'center',
      },
      grid: {
        row: {
          colors: ['#f3f3f3', 'transparent'], // Alterna colores de fila
          opacity: 0.5,
        },
      },
      xaxis: {
        categories: meses,
      },
    };
  }

  onSelectionChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    console.log('Selected Option:', selectElement.value);
    this.dataType = selectElement.value;
    this.updateChart();
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
