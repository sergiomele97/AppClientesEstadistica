import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ICliente } from '../interfaces/cliente';
import { IClienteConBalance } from '../interfaces/clienteConBalance';

@Injectable({
  providedIn: 'root'
})
export class ClienteEstService {

  constructor(private http: HttpClient) {}

  private readonly url_estadistica = environment.apiEstadisticas;

  getClientes(): Observable<ICliente[]> {
    return this.http.get<ICliente[]>(`${this.url_estadistica}/getclientes`);
  }

  getCliente(clienteId: number): Observable<ICliente> {
    return this.http.get<ICliente>(`${this.url_estadistica}/getcliente/${clienteId}`)
  }

  getClientesConBalance(): Observable<IClienteConBalance[]> {
    return this.http.get<IClienteConBalance[]>(`${this.url_estadistica}/clientesconbalance`);
  }

}
