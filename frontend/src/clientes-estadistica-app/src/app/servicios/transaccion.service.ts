import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';

import { ITransaccion } from '../interfaces/transaccion';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})

export class TransaccionService {

  constructor( private http: HttpClient ) {}

  private readonly url_estadistica = environment.apiEstadisticas;

  getTransacciones(): Observable<ITransaccion[]> {
    return this.http.get<ITransaccion[]>(`${this.url_estadistica}/getTransacciones`).pipe(
      map(transacciones => 
        transacciones.map(transaccion => ({
          ...transaccion,
          importeEnviado: this.formatearDecimal( transaccion.importeEnviado),
          importeRecibido: this.formatearDecimal(transaccion.importeRecibido )
        }))
      )
    );
  }

  obtenerOutlier(): Observable<ITransaccion[]> {
    return this.http.get<ITransaccion[]>(`${this.url_estadistica}/outliers`).pipe(
      map(transacciones => 
        transacciones.map(transaccion => ({
          ...transaccion,
          importeEnviado: this.formatearDecimal( transaccion.importeEnviado),
          importeRecibido: this.formatearDecimal(transaccion.importeRecibido )
        }))
      )
    );
  }

  outliersVistos():Observable<ITransaccion[]> {
    return this.http.get<ITransaccion[]>(`${this.url_estadistica}/outliers-vistos`).pipe(
      map(transacciones => 
        transacciones.map(transaccion => ({
          ...transaccion,
          importeEnviado: this.formatearDecimal( transaccion.importeEnviado),
          importeRecibido: this.formatearDecimal(transaccion.importeRecibido )
        }))
      )
    );
  }
  
  ultimasTransacciones(clienteId: number): Observable<ITransaccion[]> {
    return this.http.get<ITransaccion[]>(`${this.url_estadistica}/ultimas-transacciones/${clienteId}`).pipe(
      map(transacciones => 
        transacciones.map(transaccion => ({
          ...transaccion,
          importeEnviado: this.formatearDecimal( transaccion.importeEnviado),
          importeRecibido: this.formatearDecimal(transaccion.importeRecibido )
        }))
      )
    );
  }

  borrarOutlier(idTransaccion: number): Observable<string> {
    return this.http.put<string>(`${this.url_estadistica}/resolucionOutlier/${idTransaccion}`, {}, { responseType: 'text' as 'json' });
}

  formatearDecimal(value: number | null): number {
    if (value === null || value === undefined) {
      return 0;
    }
    return parseFloat(value.toFixed(2));
  }
  
}
