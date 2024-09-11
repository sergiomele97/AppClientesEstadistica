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
  isLoading: boolean = true; // Estado para controlar el loader

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
  private subscription: Subscription = new Subscription();

  constructor(
    private graficasService: GraficasService,
    private clienteService: ClienteService
  ) {}

  ngOnInit(): void {
    this.isLoading = true;

    // Obtener clientes y manejar la suscripción
    this.subscription.add(
      this.clienteService.getClientes().subscribe({
        next: (clientes) => {
          this.clientes = clientes;
          this.updateChart();
          this.isLoading = false;
        },
        error: (err) => {
          console.error('Error al obtener los clientes: ', err);
          this.isLoading = false;
        },
      })
    );
  }

  /**
   * Clasifica una edad en tramos definidos.
   * @param edad - La edad a clasificar.
   * @returns El tramo de edad correspondiente.
   */
  private clasificarEdad(edad: number): string {
    if (edad < 18) return 'Menor';
    if (edad < 30) return 'Joven';
    if (edad < 45) return 'Adulto';
    if (edad < 60) return 'Senior';
    return 'Jubilado';
  }

  /**
   * Agrupa los datos de clientes según el tipo de dato seleccionado.
   * @returns Un objeto con las categorías y series de datos.
   */
  private agruparDatos(): { categories: string[]; series: number[] } {
    let categories: string[] = [];
    let series: number[] = [];

    const resultado: Record<string, number> = {};

    if (this.dataType === 'edad') {
      categories = this.ageCategories;
      this.ageCategories.forEach((cat) => (resultado[cat] = 0));

      this.clientes.forEach((cliente) => {
        const clave = this.clasificarEdad(cliente.edad || 0);
        if (resultado[clave] !== undefined) {
          resultado[clave] += 1;
        }
      });

      series = categories.map((cat) => resultado[cat] || 0);
    } else if (this.dataType === 'sexo') {
      categories = this.sexCategories;
      this.sexCategories.forEach((cat) => (resultado[cat] = 0));

      this.clientes.forEach((cliente) => {
        const clave = cliente.sexo || 'No especificado';
        if (resultado[clave] !== undefined) {
          resultado[clave] += 1;
        }
      });

      series = categories.map((cat) => resultado[cat] || 0);
    } else if (this.dataType === 'trabajo') {
      this.clientes.forEach((cliente) => {
        const trabajo = cliente.trabajo || 'No especificado';
        if (!resultado[trabajo]) {
          resultado[trabajo] = 0;
          categories.push(trabajo);
        }
        resultado[trabajo] += 1;
      });

      series = categories.map((cat) => resultado[cat] || 0);
    }

    return { categories, series };
  }

  /**
   * Actualiza el gráfico con los datos agrupados según el tipo de dato seleccionado.
   */
  private updateChart() {
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
        type: 'bar',
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
          colors: ['#f3f3f3', 'transparent'],
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

  /**
   * Maneja el cambio en la selección del tipo de dato para el gráfico.
   * @param event - El evento de cambio de selección.
   */
  onSelectionChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.dataType = selectElement.value;
    this.updateChart();
  }

  /**
   * Cancela la suscripción cuando el componente se destruye.
   */
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  /**
   * Oculta el componente de gráfico.
   */
  close(): void {
    this.graficasService.triggerScript(); // Comunicar a graficas
    this.visible = false;
  }
}
