import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ICliente } from '../interfaces/cliente';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClienteEstService {

  constructor(private http: HttpClient) {}

  private readonly url_estadistica = environment.apiUrl;

  private readonly url_prueba = 'https://localhost:7144/api/usuarios';

  getClientes(): Observable<ICliente[]> {
    return this.http.get<ICliente[]>(`${this.url_estadistica}/getclientes`);
  }

  getCliente(clienteId: number): Observable<ICliente> {
    return this.http.get<ICliente>(`${this.url_estadistica}/getclientes/${clienteId}`)
  }

}
