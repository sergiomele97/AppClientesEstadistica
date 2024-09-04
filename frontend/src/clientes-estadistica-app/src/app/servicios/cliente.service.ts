import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ICliente } from '../interfaces/cliente';
import { ClienteConBalance } from '../models/cliente-con-balance.model';

@Injectable({
  providedIn: 'root',
})
export class ClienteService {
  constructor(private http: HttpClient) {}

  private readonly url_estadistica = environment.apiEstadisticas;
  private readonly url_balance = environment.apiBalance;

  getClientes(): Observable<ICliente[]> {
    return this.http.get<ICliente[]>(`${this.url_estadistica}/getclientes`);
  }

  getCliente(clienteId: number): Observable<ICliente> {
    return this.http.get<ICliente>(
      `${this.url_estadistica}/getcliente/${clienteId}`
    );
  }

  getClientesConBalance(): Observable<ClienteConBalance[]> {
    return this.http.get<ClienteConBalance[]>(this.url_balance);
  }
}
