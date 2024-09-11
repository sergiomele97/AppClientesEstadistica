import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ICliente } from '../interfaces/cliente';
import { ClienteConBalance } from '../models/cliente-con-balance.model';

/**
 * Servicio para manejar las operaciones relacionadas con clientes.
 * @service
 */
@Injectable({
  providedIn: 'root',
})
export class ClienteService {
  private readonly url_estadistica = environment.apiEstadisticas;
  private readonly url_balance = environment.apiBalance;

  /**
   * Crea una instancia del servicio de clientes.
   * @param {HttpClient} http - Servicio para realizar solicitudes HTTP.
   */
  constructor(private http: HttpClient) {}

  /**
   * Obtiene la lista de todos los clientes.
   * @returns {Observable<ICliente[]>} - Un observable que emite una lista de clientes.
   */
  getClientes(): Observable<ICliente[]> {
    return this.http.get<ICliente[]>(`${this.url_estadistica}/getclientes`);
  }

  /**
   * Obtiene un cliente específico por su identificador.
   * @param {number} clienteId - Identificador del cliente a obtener.
   * @returns {Observable<ICliente>} - Un observable que emite la información del cliente solicitado.
   */
  getCliente(clienteId: number): Observable<ICliente> {
    return this.http.get<ICliente>(
      `${this.url_estadistica}/getcliente/${clienteId}`
    );
  }

  /**
   * Obtiene la lista de clientes junto con su balance.
   * @returns {Observable<ClienteConBalance[]>} - Un observable que emite una lista de clientes con balance.
   */
  getClientesConBalance(): Observable<ClienteConBalance[]> {
    return this.http.get<ClienteConBalance[]>(this.url_balance);
  }
}
