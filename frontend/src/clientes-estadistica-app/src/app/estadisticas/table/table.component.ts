import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent implements OnInit, OnDestroy {
  constructor(private transaccionesService: TransaccionService) {}

  ngOnInit(): void {
    this.subscription = this.transaccionesService.getTransacciones().subscribe({
      next: (transacciones) => {
        this.transaccionesFilter = this.filterTransaccionesByCliente(
          this.filterTransaccion
        );
      },
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  subscription!: Subscription;
  transacciones: ITransaccion[] = [];
  transaccionesFilter: ITransaccion[] = [];
  currentPage: number = 1; // Página actual

  _filterTransaccion: number;

  get filterTransaccion(): number {
    return this._filterTransaccion;
  }

  set filterTransaccion(value: number) {
    this._filterTransaccion = value;
    this.currentPage = 1;
    this.transaccionesFilter = this.filterTransaccionesByCliente(value);
  }

  filterTransaccionesByCliente(filter: number): ITransaccion[] {
    return this.transacciones.filter((transaccion: ITransaccion) =>
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
        case 'importeOrigen':
          valorA = a.importeRecibido;
          valorB = b.importeRecibido;
          break;
        case 'importeRecibido':
          valorA = a.importeRecibido;
          valorB = b.importeRecibido;
          break;
        case 'fecha':
          valorA = a.fecha;
          valorB = b.fecha;
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
}
