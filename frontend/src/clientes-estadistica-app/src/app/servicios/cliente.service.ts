import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../clases/cliente'; // Asegúrate de tener una clase Cliente
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  private readonly URL = "https://localhost:7107/api/cliente";

  constructor(private http: HttpClient) { }

  getClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(this.URL);
  }

  // Otros métodos relacionados con clientes
}
