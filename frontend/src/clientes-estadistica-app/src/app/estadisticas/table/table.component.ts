import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IEnvio } from 'src/app/interfaces/envios';
import { EnviosService } from 'src/app/servicios/envios.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent implements OnInit, OnDestroy {
  
  constructor(private enviosService: EnviosService) {}

  ngOnInit(): void {
    this.subscription = this.enviosService.getEnvios().subscribe({
      next: (envios) => {
        this.envios = this.enviosService.formatEnvios(envios);
        this.enviosFilter = this.filterEnviosByDivisa(this.filterEnvio);
      },
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  subscription!: Subscription;
  envios: IEnvio[] = [];
  enviosFilter: IEnvio[] = [];
  currentPage: number = 1;  // Página actual

  _filterEnvio: string = '';

  get filterEnvio(): string {
    return this._filterEnvio;
  }

  set filterEnvio(value: string) {
    this._filterEnvio = value;
    
    this.enviosFilter = this.filterEnviosByDivisa(value)
  }

  filterEnviosByDivisa(filter: string): IEnvio[] {
    return this.envios.filter((envio: IEnvio) => 
      envio?.divisa?.toLowerCase().includes(filter.toLowerCase()));
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

    this.enviosFilter.sort((a, b) => {
      let valorA, valorB;

      switch (column) {
        case 'id':
          valorA = a.id;
          valorB = b.id;
          break;
        case 'cantidad':
          valorA = a.cantidad;
          valorB = b.cantidad;
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
