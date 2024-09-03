import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexTooltip,
  ApexStroke,
  ApexTitleSubtitle,
  ApexGrid,
} from 'ng-apexcharts';
import { Subscription } from 'rxjs';
import { ICliente } from 'src/app/interfaces/cliente';
import { ClienteService } from 'src/app/servicios/cliente.service';
import { GraficasService } from 'src/app/servicios/graficas.service';

export type ChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  stroke: ApexStroke;
  tooltip: ApexTooltip;
  dataLabels: ApexDataLabels;
  title: ApexTitleSubtitle;
  grid: ApexGrid;
};

@Component({
  selector: 'app-graph',
  templateUrl: './graph.component.html',
  styleUrls: ['./graph.component.css'],
})
export class GraphComponent implements OnInit, OnDestroy {
  @ViewChild('chart') chart: ChartComponent;
  visible: boolean = true;
  public chartOptions: Partial<ChartOptions>;
  public dataType: string = 'sexo'; // Valor por defecto
  isLoading: boolean = true; // AGREGADO: variable de estado para controlar el loader

  // Definición de categorías para cada tipo de agrupación
  private readonly ageCategories = [
    'Menor', // < 18
    'Joven', // 18-29
    'Adulto', // 30-44
    'Senior', // 45-59
    'Jubilado', // >= 60
  ];

  private readonly sexCategories = ['Masculino', 'Femenino', 'No especificado'];

  clientes: ICliente[] = [];
  subscription: Subscription;

  constructor(
    private graficasService: GraficasService,
    private clienteService: ClienteService
  ) {
    this.updateChart();
  }

  ngOnInit(): void {
    // Iniciar el estado de carga
    this.isLoading = true; // AGREGADO: Mostrar loader al iniciar la carga

    // Obtener los clientes
    this.subscription = this.clienteService.getClientes().subscribe({
      next: (clientes) => {
        this.clientes = clientes;
        this.updateChart(); // Actualizar el gráfico después de obtener los datos
        this.isLoading = false; // AGREGADO: Ocultar loader después de cargar los datos
      },
      error: (err) => {
        console.error('Error al obtener los clientes: ', err);
        this.isLoading = false; // AGREGADO: Ocultar loader si hay un error
      },
    });
  }

  // Función para clasificar las edades en tramos
  private clasificarEdad(edad: number): string {
    if (edad < 18) return 'Menor';
    if (edad < 30) return 'Joven';
    if (edad < 45) return 'Adulto';
    if (edad < 60) return 'Senior';
    return 'Jubilado';
  }

  private agruparDatos(): { categories: string[]; series: number[] } {
    let categories: string[] = [];
    let series: number[] = [];

    if (this.dataType === 'edad') {
      categories = this.ageCategories;
      const resultado: Record<string, number> = {};
      this.ageCategories.forEach((cat) => (resultado[cat] = 0));

      this.clientes.forEach((cliente) => {
        const clave = this.clasificarEdad(cliente.edad || 0);
        if (resultado.hasOwnProperty(clave)) {
          resultado[clave] += 1;
        }
      });

      series = categories.map((cat) => resultado[cat]);
    } else if (this.dataType === 'sexo') {
      categories = this.sexCategories;
      const resultado: Record<string, number> = {};
      this.sexCategories.forEach((cat) => (resultado[cat] = 0));

      this.clientes.forEach((cliente) => {
        const clave = cliente.sexo || 'No especificado';
        if (resultado.hasOwnProperty(clave)) {
          resultado[clave] += 1;
        }
      });

      series = categories.map((cat) => resultado[cat]);
    } else if (this.dataType === 'trabajo') {
      const resultado: Record<string, number> = {};
      this.clientes.forEach((cliente) => {
        const trabajo = cliente.trabajo || 'No especificado';
        if (!resultado.hasOwnProperty(trabajo)) {
          resultado[trabajo] = 0;
          categories.push(trabajo);
        }
        resultado[trabajo] += 1;
      });

      series = categories.map((cat) => resultado[cat]);
    }

    return { categories, series };
  }

  updateChart() {
    const { categories, series } = this.agruparDatos();

    this.chartOptions = {
      series: [
        {
          name:
            this.dataType === 'edad'
              ? 'Número de Clientes por Edad'
              : this.dataType === 'sexo'
              ? 'Número de Clientes por Sexo'
              : 'Número de Clientes por Trabajo',
          data: series,
        },
      ],
      chart: {
        height: 350,
        type: 'bar', // Cambiado a bar para una mejor visualización en categorías
      },
      dataLabels: {
        enabled: true,
      },
      stroke: {
        curve: 'smooth',
      },
      title: {
        text:
          this.dataType === 'edad'
            ? 'Número de Clientes por Tramos de Edad'
            : this.dataType === 'sexo'
            ? 'Número de Clientes por Sexo'
            : 'Número de Clientes por Trabajo',
        align: 'center',
      },
      grid: {
        row: {
          colors: ['#f3f3f3', 'transparent'], // Toma un array que se repetirá en columnas
          opacity: 0.5,
        },
      },
      xaxis: {
        categories: categories,
        title: {
          text:
            this.dataType === 'edad'
              ? 'Tramos de Edad'
              : this.dataType === 'sexo'
              ? 'Sexo'
              : 'Trabajo',
        },
      },
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

  // Cerrado grafica
  close(): void {
    this.graficasService.triggerScript(); // Comunicar a graficas
    this.visible = false;
  }
}
