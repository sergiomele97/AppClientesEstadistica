import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

import { IEnvio } from '../interfaces/envios';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class EnviosService {
  
  constructor(private http: HttpClient) {}

  private readonly url_estadistica = environment.apiUrl;

  private readonly url_prueba = 'https://localhost:7144/api/usuarios';

  getEnvios(): Observable<IEnvio[]> {
    return this.http.get<IEnvio[]>(`${this.url_estadistica}/getEnvios`);
  }

  formatEnvios(envios: IEnvio[]): any[] {
    return envios.map(envio => ({
      ...envio,
      cantidad: new Intl.NumberFormat('es-ES', { style: 'currency', currency: envio.divisa }).format(envio.cantidad), // Formato de cantidad con divisa
      fecha: new Date(envio.fecha).toLocaleDateString('es-ES', { day: '2-digit', month: '2-digit', year: 'numeric' }) // Formato de fecha
    }));
  }
  
  
}
