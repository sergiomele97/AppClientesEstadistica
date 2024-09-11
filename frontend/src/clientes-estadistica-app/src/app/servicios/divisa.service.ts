import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDivisa } from '../interfaces/divisa';
import { environment } from 'src/environments/environment';

/**
 * Servicio para manejar las operaciones relacionadas con las divisas.
 * @service
 */
@Injectable({
  providedIn: 'root',
})
export class DivisaService {
  /**
   * URL base para las solicitudes relacionadas con estadísticas de divisas.
   * @private
   */
  private readonly url_estadistica = environment.apiEstadisticas;

  /**
   * Crea una instancia del servicio de divisas.
   * @param {HttpClient} http - Servicio para realizar solicitudes HTTP.
   */
  constructor(private http: HttpClient) {}

  /**
   * Obtiene los datos de una divisa específica desde el servidor.
   * @param {string} nombre - Nombre de la divisa para la cual se desean obtener los datos.
   * @returns {Observable<IDivisa[]>} - Observable que emite una lista de objetos de divisa.
   */
  getDivisasData(nombre: string): Observable<IDivisa[]> {
    return this.http.get<IDivisa[]>(
      `${this.url_estadistica}/getdivisa/${nombre}`
    );
  }
}
