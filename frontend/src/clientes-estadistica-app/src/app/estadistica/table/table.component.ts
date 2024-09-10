import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ITransaccionVita } from 'src/app/interfaces/transaccionVista'; // Interfaz para el objeto Transacción
import { TransaccionServiceProcedure } from 'src/app/servicios/transaccion-procedure.service'; // Servicio actualizado

/**
 * Componente para mostrar y gestionar una tabla de transacciones.
 * Permite filtrar, ordenar y mostrar detalles de transacciones.
 */
@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent implements OnInit, OnDestroy {
  private subscription!: Subscription;
  transaccionesFilter: ITransaccionVita[] = []; // Lista de transacciones filtradas
  currentPage: number = 1; // Página actual

  _filterTransaccion: string = ''; // Filtro de transacciones
  startDate: string = ''; // Fecha de inicio para el filtro
  endDate: string = ''; // Fecha de fin para el filtro

  hoveredCliente: {
    nombre: string;
    clienteId: number;
    telefono: string;
    correo: string;
  } | null = null; // Información del cliente en el tooltip

  tooltipPosition: { top: string; left: string } = { top: '0px', left: '0px' }; // Posición del tooltip
  private tooltipTimeoutId: any; // ID para el temporizador del tooltip

  columnOrder: string = 'transaccionId'; // Columna por la que se ordena
  directionOrder: boolean = true; // Dirección del orden (ascendente o descendente)

  /**
   * Crea una instancia del componente `TableComponent`.
   * @param transaccionesServiceProcedure - Servicio para gestionar transacciones
   */
  constructor(
    private transaccionesServiceProcedure: TransaccionServiceProcedure
  ) {}

  /**
   * Inicializa el componente cargando las transacciones filtradas.
   */
  ngOnInit(): void {
    this.fetchFilteredTransacciones();
  }

  /**
   * Limpia los recursos utilizados por el componente al destruirlo.
   */
  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  /**
   * Obtiene las transacciones filtradas y actualiza la lista.
   */
  fetchFilteredTransacciones(): void {
    this.subscription = this.transaccionesServiceProcedure
      .getFilteredTransacciones(
        this._filterTransaccion,
        this.startDate,
        this.endDate
      )
      .subscribe((data) => {
        this.transaccionesFilter = data;
        this.order('transaccionId'); // Ordena por defecto después de obtener los datos
      });
  }

  /**
   * Actualiza la lista de transacciones cuando el filtro cambia.
   */
  onFilterChange(): void {
    this.fetchFilteredTransacciones();
  }

  /**
   * Ordena las transacciones por la columna especificada.
   * @param column - Nombre de la columna por la que ordenar
   */
  order(column: string): void {
    if (this.columnOrder === column) {
      this.directionOrder = !this.directionOrder;
    } else {
      this.columnOrder = column;
      this.directionOrder = true;
    }

    this.transaccionesFilter.sort((a, b) => {
      let valorA: any, valorB: any;

      switch (column) {
        case 'transaccionId':
          valorA = a.transaccionId;
          valorB = b.transaccionId;
          break;
        case 'clienteOrigenNombre':
          valorA = a.clienteOrigenNombre;
          valorB = b.clienteOrigenNombre;
          break;
        case 'clienteDestinoNombre':
          valorA = a.clienteDestinoNombre;
          valorB = b.clienteDestinoNombre;
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
        default:
          return 0;
      }

      const comparacion = valorA > valorB ? 1 : valorA < valorB ? -1 : 0;
      return this.directionOrder ? comparacion : -comparacion;
    });
  }

  /**
   * Muestra el tooltip con la información del cliente.
   * @param transaccion - Transacción para obtener la información del cliente
   * @param event - Evento del mouse para calcular la posición del tooltip
   * @param esOrigen - Indica si el cliente es el origen o destino
   */
  showTooltip(
    transaccion: ITransaccionVita,
    event: MouseEvent,
    esOrigen: boolean
  ): void {
    this.hoveredCliente = esOrigen
      ? {
          nombre: transaccion.clienteOrigenNombre,
          clienteId: transaccion.clienteOrigenId,
          telefono: transaccion.clienteOrigenTelefono,
          correo: transaccion.clienteOrigenCorreo,
        }
      : {
          nombre: transaccion.clienteDestinoNombre,
          clienteId: transaccion.clienteDestinoId,
          telefono: transaccion.clienteDestinoTelefono,
          correo: transaccion.clienteDestinoCorreo,
        };

    const mouseX = event.clientX;
    const mouseY = event.clientY;

    const tooltipWidth = 200;
    const tooltipHeight = 100;

    let tooltipX = mouseX + 15;
    let tooltipY = mouseY + 15;

    const viewportWidth = window.innerWidth;
    const viewportHeight = window.innerHeight;

    if (tooltipX + tooltipWidth > viewportWidth) {
      tooltipX = mouseX - tooltipWidth - 15;
    }

    if (tooltipY + tooltipHeight > viewportHeight) {
      tooltipY = mouseY - tooltipHeight - 15;
    }

    this.tooltipPosition = {
      top: `${tooltipY}px`,
      left: `${tooltipX}px`,
    };
  }

  /**
   * Oculta el tooltip después de un breve retraso.
   */
  hideTooltip(): void {
    if (this.tooltipTimeoutId) {
      clearTimeout(this.tooltipTimeoutId);
    }
    this.hoveredCliente = null;
  }
}
