import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexTitleSubtitle,
  ApexStroke,
  ApexGrid
} from "ng-apexcharts";
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
  styleUrls: ['./volumetry.component.css']
})
export class 
VolumetryComponent implements OnInit, OnDestroy {

  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  public dataType: string = 'transacciones'; // Cambiar valor inicial a 'transacciones'

  constructor(
    private transaccionesService: TransaccionService,
    private conversionesService: ConversionService
  ) {}

  transacciones: ITransaccion[] = [];
  conversiones: IConversion[] = [];
  subscription: Subscription;

  ngOnInit(): void {
    // Obtener lista de transacciones y conversiones
    this.subscription = this.transaccionesService.getTransacciones().subscribe({
      next: (transacciones) => {
        this.transacciones = transacciones;
        this.updateChart(); // Update chart with default data
      },
      error: (err) => {
        console.error('Error al obtener la lista de transacciones', err);
      },
    });

    this.subscription.add(
      this.conversionesService.getConversiones().subscribe({
        next: (conversiones) => {
          this.conversiones = conversiones;
          this.updateChart(); // Update chart with default data
        },
        error: (err) => {
          console.error('Error al obtener la lista de conversiones', err);
        },
      })
    );
  }

  updateChart() {
    const data = this.dataType === 'transacciones' ? this.transacciones : this.conversiones;
  
    // Agrupar datos por mes y año
    const agruparPorMes = (data: any[]) => {
      const resultado: Record<string, number> = {};
      data.forEach(item => {
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
    const conteoPorMes = meses.map(mes => datosAgrupados[mes]);

    this.chartOptions = {
      series: [
        {
          name: this.dataType === 'transacciones' ? 'Transacciones' : 'Conversiones',
          data: conteoPorMes
        }
      ],
      chart: {
        height: 350,
        type: "line",
        zoom: {
          enabled: false
        }
      },
      dataLabels: {
        enabled: true
      },
      stroke: {
        curve: "smooth"
      },
      title: {
        text: this.dataType === 'transacciones' ? 'Número de Transacciones por Mes' : 'Número de Conversiones por Mes',
        align: "center"
      },
      grid: {
        row: {
          colors: ["#f3f3f3", "transparent"], // Alterna colores de fila
          opacity: 0.5
        }
      },
      xaxis: {
        categories: meses,
        title: {
          text: 'Mes y Año'
        }
      }
    };
  }

  onSelectionChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.dataType = selectElement.value;
    this.updateChart();
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
