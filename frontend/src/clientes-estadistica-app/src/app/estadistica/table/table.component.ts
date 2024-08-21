import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ICliente } from 'src/app/interfaces/cliente';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent implements OnInit, OnDestroy {
  constructor(private transaccionesService: TransaccionService) {}

  subscription!: Subscription;
  transacciones: ITransaccion[] = [];
  transaccionesFilter: ITransaccion[] = [];
  currentPage: number = 1; // Página actual
  _filterTransaccion: number;

  // Variables para el tooltip
  hoveredCliente: ICliente | null = null;
  tooltipPosition: { top: string; left: string } = { top: '0px', left: '0px' };
  private tooltipTimeoutId: any;

  get filterTransaccion(): number {
    return this._filterTransaccion;
  }

  set filterTransaccion(value: number) {
    this._filterTransaccion = value;
    this.currentPage = 1;
    this.transaccionesFilter = this.filterTransaccionesByCliente(value);
  }

  ngOnInit(): void {
    this.subscription = this.transaccionesService.getTransacciones().subscribe({
      next: (transacciones) => {
        this.transacciones = transacciones;
        // this.transacciones = this.transaccionesService.formatTransacciones(this.transacciones)
        this.transaccionesFilter = this.filterTransaccionesByCliente(
          this.filterTransaccion
        );
        console.log(transacciones);
      },
      error: (error) => console.error('Error fetching transactions:', error),
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  filterTransaccionesByCliente(filter: number): ITransaccion[] {
    if (!filter) {
      return this.transacciones; // Si no hay filtro, retorna todas las transacciones
    }
    return this.transacciones.filter(
      (transaccion: ITransaccion) =>
        transaccion?.clienteOrigenId === filter ||
        transaccion?.clienteDestinoId === filter
    );
  }

  columnOrder: string = '';
  directionOrder: boolean = true;

  order(column: string): void {
    if (this.columnOrder === column) {
      this.directionOrder = !this.directionOrder;
    } else {
      this.columnOrder = column;
      this.directionOrder = true;
    }

    this.transaccionesFilter.sort((a, b) => {
      let valorA, valorB;

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

      let comparacion = 0;
      if (valorA > valorB) {
        comparacion = 1;
      } else if (valorA < valorB) {
        comparacion = -1;
      }

      return this.directionOrder ? comparacion : -comparacion;
    });
  }

  showTooltip(cliente: ICliente, event: MouseEvent): void {
    this.tooltipTimeoutId = setTimeout(() => {
      this.hoveredCliente = cliente;
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
    }, 500); // Retraso de 500 ms
  }

  hideTooltip(): void {
    if (this.tooltipTimeoutId) {
      clearTimeout(this.tooltipTimeoutId); // Cancelar el temporizador si el ratón sale antes de que aparezca el tooltip
    }
    this.hoveredCliente = null;
  }
}
