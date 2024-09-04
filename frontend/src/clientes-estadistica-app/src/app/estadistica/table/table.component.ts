import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ITransaccionVita } from 'src/app/interfaces/transaccionVista'; // Interfaz para el objeto Transacción
import { TransaccionServiceProcedure } from 'src/app/servicios/transaccion-procedure.service'; // Servicio actualizado

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent implements OnInit, OnDestroy {
  subscription!: Subscription;
  transaccionesFilter: ITransaccionVita[] = [];
  currentPage: number = 1;

  _filterTransaccion: string = '';
  startDate: string = '';
  endDate: string = '';

  hoveredCliente: {
    nombre: string;
    clienteId: number;
    telefono: string;
    correo: string;
  } | null = null;

  tooltipPosition: { top: string; left: string } = { top: '0px', left: '0px' };
  private tooltipTimeoutId: any;

  columnOrder: string = 'transaccionId';
  directionOrder: boolean = true;

  constructor(
    private transaccionesServiceProcedure: TransaccionServiceProcedure // Utilizar el nuevo servicio
  ) {}

  ngOnInit(): void {
    this.fetchFilteredTransacciones(); // Inicializar con datos filtrados
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

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

  onFilterChange(): void {
    this.fetchFilteredTransacciones();
  }

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

      let comparacion = 0;
      if (valorA > valorB) {
        comparacion = 1;
      } else if (valorA < valorB) {
        comparacion = -1;
      }

      return this.directionOrder ? comparacion : -comparacion;
    });
  }

  showTooltip(
    transaccion: ITransaccionVita,
    event: MouseEvent,
    esOrigen: boolean
  ): void {
    if (esOrigen) {
      this.hoveredCliente = {
        nombre: transaccion.clienteOrigenNombre,
        clienteId: transaccion.clienteOrigenId,
        telefono: transaccion.clienteOrigenTelefono,
        correo: transaccion.clienteOrigenCorreo,
      };
    } else {
      this.hoveredCliente = {
        nombre: transaccion.clienteDestinoNombre,
        clienteId: transaccion.clienteDestinoId,
        telefono: transaccion.clienteDestinoTelefono,
        correo: transaccion.clienteDestinoCorreo,
      };
    }

    // Calcula la posición del tooltip en función de la posición del mouse
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

    // Actualiza la posición del tooltip
    this.tooltipPosition = {
      top: `${tooltipY}px`,
      left: `${tooltipX}px`,
    };
  }

  hideTooltip(): void {
    if (this.tooltipTimeoutId) {
      clearTimeout(this.tooltipTimeoutId);
    }
    this.hoveredCliente = null;
  }
}
