import { Component, OnDestroy, OnInit, ViewChild } from "@angular/core";

import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexYAxis,
  ApexLegend,
  ApexFill,
  ApexGrid,
  ApexStroke,
  ApexTitleSubtitle
} from "ng-apexcharts";
import { Subscription } from "rxjs";
import { ITransaccion } from "src/app/interfaces/transaccion";
import { TransaccionService } from "src/app/servicios/transaccion.service";

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  dataLabels: ApexDataLabels;
  yaxis: ApexYAxis;
  grid: ApexGrid;
  stroke: ApexStroke;
  title: ApexTitleSubtitle;
  legend: ApexLegend;
  colors?: string[]; // Añadir esta línea para incluir colores
  tooltip?: any; // Agregar propiedad tooltip
};


@Component({
  selector: 'app-spaghetti',
  templateUrl: './spaghetti.component.html',
  styleUrls: ['./spaghetti.component.css']
})

export class SpaghettiComponent implements OnInit, OnDestroy {

  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  subscription: Subscription;
  transacciones: ITransaccion[] = [];

  constructor(private transaccionesService: TransaccionService) {}


  ngOnInit(): void {
    this.subscription = this.transaccionesService.getTransacciones().subscribe({
      next: (transacciones) => {
        this.updateChart(transacciones);
      },
      error: (err) => {
        console.error('Error al obtener la lista de transacciones', err);
      },
    });
  }

  updateChart(transacciones) {
    // Agrupar transacciones por cliente y mes
    const transaccionesPorMes = this.agruparTransaccionesPorMes(transacciones);
  
    // Calcular la media de transacciones por mes
    const totalClientes = Object.keys(transaccionesPorMes).length;
    const meses = Array.from(
      new Set(Object.values(transaccionesPorMes).flatMap(clienteData => Object.keys(clienteData)))
    ).sort((a, b) => {
      const [mesA, anioA] = a.split('-').map(Number);
      const [mesB, anioB] = b.split('-').map(Number);
      return anioA !== anioB ? anioA - anioB : mesA - mesB;
    });
  
    const mediaPorMes: number[] = new Array(meses.length).fill(0);
  
    Object.values(transaccionesPorMes).forEach((mesData) => {
      meses.forEach((mes, index) => {
        mediaPorMes[index] += mesData[mes] || 0;
      });
    });
  
    // Dividir cada valor entre el número de clientes para obtener la media
    mediaPorMes.forEach((total, index) => {
      mediaPorMes[index] = total / totalClientes;
    });
  
    // Preparar los datos para el gráfico
    const seriesData = Object.keys(transaccionesPorMes).map((clienteId) => ({
      name: `Cliente ${clienteId}`,
      data: meses.map(mes => transaccionesPorMes[clienteId][mes] || 0),
    }));
  
    // Agregar la serie para la media de transacciones
    seriesData.push({
      name: 'Media de Transacciones',
      data: mediaPorMes,
    });
  
    // Configurar las opciones del gráfico
    this.chartOptions = {
      series: seriesData,
      chart: {
        type: 'line',
        height: 350,
        animations: {
          enabled: false // Desactivar animaciones para una carga más rápida
        }
      },
      colors: [...Array(seriesData.length - 1).fill('#008FFB'), '#FF4560'], // Colores para las series (media en un color diferente)
      stroke: {
        curve: 'smooth',
        width: seriesData.map((_, index) => index === seriesData.length - 1 ? 5 : 1) // Configura el ancho de las líneas: más gruesa para la última serie (media)
      },
      xaxis: {
        categories: meses,
        title: {
          text: 'Mes',
        },
      },
      yaxis: {
        title: {
          text: 'Número de Transacciones',
        },
        labels: {
          formatter: (value: number) => Math.floor(value).toString() // Redondea los valores a enteros y los convierte a string
        }
      },
      dataLabels: {
        enabled: false,
      },
      title: {
        text: 'Transacciones por Mes y Media',
        align: 'center',
      },
      legend: {
        position: 'top',
        horizontalAlign: 'left',
        show: false, // Ocultar leyenda
      },
      tooltip: {
        enabled: false // Desactivar tooltips
      },
      grid: {
        row: {
          colors: ['#f3f3f3', 'transparent'], // Alterna los colores de las filas
          opacity: 0.5,
        },
      },
    };
  }
  
  
  // Función para obtener el mes y año a partir de una fecha
private obtenerMesYAnio(fecha: Date): string {
  const mes = fecha.getMonth() + 1; // Los meses en JavaScript van de 0 a 11
  const anio = fecha.getFullYear();
  return `${mes < 10 ? '0' : ''}${mes}-${anio}`; // Formato MM-YYYY
}

// Función para agrupar las transacciones por cliente y mes
private agruparTransaccionesPorMes(transacciones: ITransaccion[]): Record<string, Record<string, number>> {
  const transaccionesPorClienteYMes: Record<string, Record<string, number>> = {};

  transacciones.forEach((transaccion) => {
    const clienteId = transaccion.clienteOrigenId;
    const fechaTransaccion = new Date(transaccion.fecha);
    const mesAnio = this.obtenerMesYAnio(fechaTransaccion);

    if (!transaccionesPorClienteYMes[clienteId]) {
      transaccionesPorClienteYMes[clienteId] = {};
    }

    if (!transaccionesPorClienteYMes[clienteId][mesAnio]) {
      transaccionesPorClienteYMes[clienteId][mesAnio] = 0;
    }

    transaccionesPorClienteYMes[clienteId][mesAnio]++;
  });

  return transaccionesPorClienteYMes;
}

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}