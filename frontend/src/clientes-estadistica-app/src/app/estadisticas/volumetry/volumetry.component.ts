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

export class VolumetryComponent implements OnInit, OnDestroy {

  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;

  public dataType: string = 'usuarios';

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
  
    // Agrupar datos por fecha
    const agruparPorFecha = (data: any[]) => {
      const resultado: Record<string, number> = {};
      data.forEach(item => {
        const fecha = new Date(item.fecha).toLocaleDateString('es-ES', { day: '2-digit', month: '2-digit', year: 'numeric' });
        const cantidad = 1; // Conteo por día
  
        if (resultado[fecha]) {
          resultado[fecha] += cantidad;
        } else {
          resultado[fecha] = cantidad;
        }
      });
      return resultado;
    };
  
    const datosAgrupados = agruparPorFecha(data);
  
    // Ordenar fechas
    const fechas = Object.keys(datosAgrupados).sort((a, b) => new Date(a).getTime() - new Date(b).getTime());
  
    // Obtener conteo por fecha en el orden de fechas ordenadas
    const conteoPorFecha = fechas.map(fecha => datosAgrupados[fecha]);

    this.chartOptions = {
      series: [
        {
          name: this.dataType === 'transacciones' ? 'Transacciones' : 'Conversiones',
          data: conteoPorFecha
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
        text: this.dataType === 'transacciones' ? 'Número de Transacciones por Día' : 'Número de Conversiones por Día',
        align: "center"
      },
      grid: {
        row: {
          colors: ["#f3f3f3", "transparent"], // Toma un array que se repetirá en columnas
          opacity: 0.5
        }
      },
      xaxis: {
        categories: fechas,
        title: {
          text: 'Fecha'
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
