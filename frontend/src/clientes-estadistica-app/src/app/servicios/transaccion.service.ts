import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ITransaccion } from '../interfaces/transaccion';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class TransaccionService {

  constructor(private http: HttpClient) {}

  private readonly url_estadistica = environment.apiUrl;

  getTransacciones(): Observable<ITransaccion[]> {
    return this.http.get<ITransaccion[]>(`${this.url_estadistica}/getTransacciones`);
  }
  
  formatTransacciones(transacciones: ITransaccion[]): any[] {
    return transacciones.map(transaccion => ({
      ...transaccion,
      importeRecibido: new Intl.NumberFormat('es-ES', { style: 'currency' }).format(transaccion.importeRecibido), // Formato de moneda
      importeEnviado: new Intl.NumberFormat('es-ES', { style: 'currency' }).format(transaccion.importeEnviado), // Formato de moneda
      fecha: new Date(transaccion.fecha).toLocaleDateString('es-ES', { day: '2-digit', month: '2-digit', year: 'numeric' }) // Formato de fecha
    }));
  }
}
