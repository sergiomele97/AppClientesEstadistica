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

  private readonly url_prueba = 'https://localhost:7144/api/clientes';

  getTransacciones(): Observable<ITransaccion[]> {
    return this.http.get<ITransaccion[]>(`${this.url_estadistica}/getTransaccion`);
  }
  
}
