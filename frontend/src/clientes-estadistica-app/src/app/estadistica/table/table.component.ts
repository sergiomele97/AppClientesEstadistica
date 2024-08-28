import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ICliente } from 'src/app/interfaces/cliente'; // Interfaz para el objeto Cliente
import { ITransaccion } from 'src/app/interfaces/transaccion'; // Interfaz para el objeto Transacción
import { TransaccionService } from 'src/app/servicios/transaccion.service'; // Servicio para obtener las transacciones

@Component({
  selector: 'app-table', // Selector del componente
  templateUrl: './table.component.html', // Ruta al archivo de plantilla HTML del componente
  styleUrls: ['./table.component.css'], // Ruta al archivo de estilos CSS del componente
})
export class TableComponent implements OnInit, OnDestroy {
  constructor(private transaccionesService: TransaccionService) {}

  subscription!: Subscription; // Suscripción para manejar el flujo de datos de transacciones
  transacciones: ITransaccion[] = []; // Arreglo para almacenar todas las transacciones obtenidas
  transaccionesFilter: ITransaccion[] = []; // Arreglo para almacenar las transacciones filtradas
  currentPage: number = 1; // Página actual para la paginación

  private _filterTransaccion: string = ''; // Variable privada para almacenar el filtro de transacciones por cliente
  startDate: string = ''; // Variable para almacenar la fecha de inicio del filtro por fechas
  endDate: string = ''; // Variable para almacenar la fecha de fin del filtro por fechas

  // Variables para manejar el tooltip
  hoveredCliente: ICliente | null = null; // Cliente sobre el cual se muestra el tooltip
  tooltipPosition: { top: string; left: string } = { top: '0px', left: '0px' }; // Posición del tooltip en la pantalla
  private tooltipTimeoutId: any; // ID del temporizador para controlar la aparición del tooltip

  // Getter para obtener el valor actual del filtro de transacción
  get filterTransaccion(): string {
    return this._filterTransaccion;
  }

  // Setter para aplicar un nuevo filtro de transacción
  set filterTransaccion(value: string) {
    this._filterTransaccion = value; // Actualiza el valor del filtro
    this.currentPage = 1; // Reinicia la página actual al aplicar un nuevo filtro
    this.transaccionesFilter = this.filterTransacciones(this._filterTransaccion, this.startDate, this.endDate); // Aplica el filtro a las transacciones
  }

  // Método del ciclo de vida que se ejecuta al inicializar el componente
  ngOnInit(): void {
    // Suscripción para obtener las transacciones desde el servicio
    this.subscription = this.transaccionesService.getTransacciones().subscribe({
      next: (transacciones) => {
        this.transacciones = transacciones; // Guarda las transacciones obtenidas
        this.transaccionesFilter = this.filterTransacciones(this._filterTransaccion, this.startDate, this.endDate); // Filtra las transacciones según el filtro actual
        console.log(transacciones); // Muestra las transacciones en la consola para depuración
      },
      error: (error) => console.error('Error fetching transactions:', error), // Manejo de errores al obtener las transacciones
    });
  }

  // Método del ciclo de vida que se ejecuta al destruir el componente
  ngOnDestroy(): void {
    this.subscription.unsubscribe(); // Cancela la suscripción para evitar fugas de memoria
  }

  // Método para filtrar las transacciones por el ID de cliente
  filterByCliente(filter: string): ITransaccion[] {
    if (!filter) {
      return this.transacciones; // Si no hay filtro, retorna todas las transacciones
    }

    const filterNum = parseInt(filter, 10); // Convierte el filtro a número
    if (!isNaN(filterNum)) {
      return this.transacciones.filter(
        (transaccion: ITransaccion) =>
          transaccion.clienteOrigenId === filterNum ||
          transaccion.clienteDestinoId === filterNum
      ); // Retorna las transacciones cuyo cliente de origen o destino coincida con el filtro
    }

    return this.transacciones; // Si el filtro no es un número válido, retorna todas las transacciones
  }

  // Método para filtrar las transacciones por fechas
  filterByFecha(startDate: string, endDate: string): ITransaccion[] {
    let filteredTransacciones = this.transacciones;

    if (startDate) {
      const start = new Date(startDate).getTime(); // Convierte la fecha de inicio a timestamp
      filteredTransacciones = filteredTransacciones.filter(
        (transaccion: ITransaccion) =>
          new Date(transaccion.fecha).getTime() >= start // Filtra transacciones a partir de la fecha de inicio
      );
    }

    if (endDate) {
      const end = new Date(endDate).getTime(); // Convierte la fecha de fin a timestamp
      filteredTransacciones = filteredTransacciones.filter(
        (transaccion: ITransaccion) =>
          new Date(transaccion.fecha).getTime() <= end // Filtra transacciones hasta la fecha de fin
      );
    }

    return filteredTransacciones; // Retorna las transacciones dentro del rango de fechas especificado
  }

  // Método para combinar los filtros de cliente y fecha
  filterTransacciones(filter: string, startDate: string, endDate: string): ITransaccion[] {
    // Primero filtramos por cliente
    let filteredByCliente = this.filterByCliente(filter);
    
    // Luego filtramos por fecha usando el resultado anterior
    let filteredByFecha = this.filterByFecha(startDate, endDate);

    // Retornamos la intersección de ambos filtros
    return filteredByCliente.filter(transaccion => filteredByFecha.includes(transaccion));
  }

  // Variables para el ordenamiento de columnas
  columnOrder: string = ''; // Columna por la cual se está ordenando
  directionOrder: boolean = true; // Dirección del ordenamiento, true para ascendente, false para descendente

  // Método para ordenar las transacciones por una columna específica
  order(column: string): void {
    if (this.columnOrder === column) {
      this.directionOrder = !this.directionOrder; // Cambia la dirección del orden si se vuelve a hacer click en la misma columna
    } else {
      this.columnOrder = column; // Establece la columna por la cual se va a ordenar
      this.directionOrder = true; // Reinicia la dirección del orden a ascendente
    }

    this.transaccionesFilter.sort((a, b) => {
      let valorA, valorB;

      // Determina los valores a comparar en función de la columna seleccionada
      switch (column) {
        case 'transaccionId':
          valorA = a.transaccionId;
          valorB = b.transaccionId;
          break;
        case 'clienteOrigenId':
          valorA = a.clienteOrigenId;
          valorB = b.clienteOrigenId;
          break;
        case 'clienteDestinoId':
          valorA = a.clienteDestinoId;
          valorB = b.clienteDestinoId;
          break;
        case 'importeEnviado':
          valorA = a.importeEnviado;
          valorB = b.importeEnviado;
          break;
        case 'importeRecibido':
          valorA = a.importeRecibido;
          valorB = b.importeRecibido;
          break;
        case 'fecha':
          valorA = new Date(a.fecha).getTime();
          valorB = new Date(b.fecha).getTime();
          break;
      }

      // Compara los valores obtenidos para la ordenación
      let comparacion = 0;
      if (valorA > valorB) {
        comparacion = 1;
      } else if (valorA < valorB) {
        comparacion = -1;
      }

      // Retorna el resultado de la comparación, ajustando por la dirección de ordenamiento
      return this.directionOrder ? comparacion : -comparacion;
    });
  }

  // Método para mostrar un tooltip con información del cliente al pasar el ratón por encima
  showTooltip(cliente: ICliente, event: MouseEvent): void {
    this.tooltipTimeoutId = setTimeout(() => {
      this.hoveredCliente = cliente; // Establece el cliente sobre el cual se mostrará el tooltip
      const mouseX = event.clientX; // Obtiene la posición X del ratón
      const mouseY = event.clientY; // Obtiene la posición Y del ratón

      const tooltipWidth = 200; // Ancho del tooltip
      const tooltipHeight = 100; // Alto del tooltip

      let tooltipX = mouseX + 15; // Posición X inicial del tooltip
      let tooltipY = mouseY + 15; // Posición Y inicial del tooltip

      const viewportWidth = window.innerWidth; // Ancho de la ventana
      const viewportHeight = window.innerHeight; // Alto de la ventana

      // Ajusta la posición del tooltip si se sale de los límites de la ventana
      if (tooltipX + tooltipWidth > viewportWidth) {
        tooltipX = mouseX - tooltipWidth - 15;
      }

      if (tooltipY + tooltipHeight > viewportHeight) {
        tooltipY = mouseY - tooltipHeight - 15;
      }

      // Establece la posición final del tooltip
      this.tooltipPosition = {
        top: `${tooltipY}px`,
        left: `${tooltipX}px`,
      };
    }, 500); // Retraso de 500 ms antes de mostrar el tooltip
  }

  // Método para ocultar el tooltip al retirar el ratón
  hideTooltip(): void {
    if (this.tooltipTimeoutId) {
      clearTimeout(this.tooltipTimeoutId); // Cancela el temporizador si el ratón sale antes de que aparezca el tooltip
    }
    this.hoveredCliente = null; // Oculta el tooltip estableciendo el cliente a null
  }
}
