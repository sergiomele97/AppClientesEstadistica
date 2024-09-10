import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IConversion } from '../interfaces/conversion';
import { environment } from 'src/environments/environment';

/**
 * Servicio para manejar las operaciones relacionadas con las conversiones.
 * @service
 */
@Injectable({
  providedIn: 'root',
})
export class ConversionService {
  /**
   * URL base para las solicitudes relacionadas con estadísticas de conversiones.
   * @private
   */
  private readonly url_estadistica = environment.apiEstadisticas;

  /**
   * Crea una instancia del servicio de conversiones.
   * @param {HttpClient} http - Servicio para realizar solicitudes HTTP.
   */
  constructor(private http: HttpClient) {}

  /**
   * Obtiene una lista de conversiones desde el servidor.
   * @returns {Observable<IConversion[]>} - Observable que emite una lista de conversiones.
   */
  getConversiones(): Observable<IConversion[]> {
    return this.http.get<IConversion[]>(
      `${this.url_estadistica}/getConversiones`
    );
  }
}
