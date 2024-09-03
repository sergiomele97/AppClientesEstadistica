import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ITransaccionVita } from '../interfaces/transaccionVista';

@Injectable({
  providedIn: 'root',
})
export class TransaccionServiceProcedure {
  private apiUrl = 'https://localhost:7144/api/TransaccionesProceso';

  constructor(private http: HttpClient) {}

  getFilteredTransacciones(clienteId?: string, startDate?: string, endDate?: string): Observable<ITransaccionVita[]> {


    let params = new HttpParams();

    if (clienteId) {
      params = params.append('clienteId', clienteId);
    }

    if (startDate) {
      params = params.append('startDate', startDate);
    }

    if (endDate) {
      params = params.append('endDate', endDate);
    }

    return this.http.get<ITransaccionVita[]>(this.apiUrl, { params });
  }
}
