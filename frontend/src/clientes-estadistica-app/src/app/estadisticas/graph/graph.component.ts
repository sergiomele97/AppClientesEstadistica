import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';

import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexTooltip,
  ApexStroke,
  ApexTitleSubtitle
} from "ng-apexcharts";
import { Subscription } from 'rxjs';
import { ICliente } from 'src/app/interfaces/cliente';
import { ClienteEstService } from 'src/app/servicios/cliente-est.service';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  stroke: ApexStroke;
  tooltip: ApexTooltip;
  dataLabels: ApexDataLabels;
  title: ApexTitleSubtitle;
};

@Component({
  selector: 'app-graph',
  templateUrl: './graph.component.html',
  styleUrls: ['./graph.component.css']
})

export class GraphComponent implements OnInit, OnDestroy {

  @ViewChild("chart") chart: ChartComponent;
  public chartOptions: Partial<ChartOptions>;
  
  public dataType: string = 'sexo'; // Valor por defecto

  clientes: ICliente[] = [];
  subscription: Subscription;

  constructor(
    private clienteService: ClienteEstService
  ) {}

  ngOnInit(): void {
    // Obtener los clientes
    this.subscription = this.clienteService.getClientes().subscribe({
      next: (clientes) => {
        this.clientes = clientes;
        this.updateChart(); // Actualizar el gráfico después de obtener los datos
      },
      error: (err) => {
        console.error('Error al obtener los clientes: ', err);
      },
    });
  }

  // Agrupa los datos según el tipo de dato seleccionado (sexo, edad, trabajo)
  private agruparDatos(): { categories: string[], series: number[] } {
    const resultado: Record<string, number> = {};

    this.clientes.forEach(cliente => {
      const clave = cliente[this.dataType as keyof ICliente]?.toString() || 'Desconocido';
      if (resultado[clave]) {
        resultado[clave] += 1;
      } else {
        resultado[clave] = 1;
      }
    });

    const categories = Object.keys(resultado);
    const series = Object.values(resultado);

    return { categories, series };
  }

  updateChart() {
    const { categories, series } = this.agruparDatos();

    this.chartOptions = {
      series: [
        {
          name: this.dataType === 'sexo' ? 'Sexo' : this.dataType === 'edad' ? 'Edad' : 'Trabajo',
          data: series
        }
      ],
      chart: {
        height: 350,
        type: "bar"
      },
      dataLabels: {
        enabled: false
      },
      title: {
        text: this.dataType === 'sexo' ? 'Número de Clientes por Sexo' : this.dataType === 'edad' ? 'Número de Clientes por Edad' : 'Número de Clientes por Trabajo',
        align: "center"
      },
      stroke: {
        curve: "smooth"
      },
      xaxis: {
        categories: categories, // Las categorías para el eje X
        title: {
          text: this.dataType === 'sexo' ? 'Sexo' : this.dataType === 'edad' ? 'Edad' : 'Trabajo'
        }
      },
      tooltip: {
        x: {
          format: "dd/MM/yy" // Puedes ajustar el formato si es necesario
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
    // Cancelar la suscripción cuando el componente se destruya
    this.subscription.unsubscribe();
  }
}
