import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

import { IEnvio } from '../interfaces/envios';
import { environment } from 'src/environments/environment';

/**
 * Servicio para manejar las operaciones relacionadas con los envíos.
 * @service
 */
@Injectable({
  providedIn: 'root',
})
export class EnviosService {
  /**
   * URL base para las solicitudes relacionadas con estadísticas de envíos.
   * @private
   */
  private readonly url_estadistica = environment.apiEstadisticas;

  /**
   * URL base para las solicitudes de prueba.
   * @private
   */
  private readonly url_prueba = 'https://localhost:7144/api/usuarios';

  /**
   * Crea una instancia del servicio de envíos.
   * @param {HttpClient} http - Servicio para realizar solicitudes HTTP.
   */
  constructor(private http: HttpClient) {}

  /**
   * Obtiene una lista de envíos desde el servidor.
   * @returns {Observable<IEnvio[]>} - Observable que emite una lista de objetos de envío.
   */
  getEnvios(): Observable<IEnvio[]> {
    return this.http.get<IEnvio[]>(`${this.url_estadistica}/getEnvios`);
  }

  /**
   * Formatea una lista de envíos para su presentación en la interfaz de usuario.
   * @param {IEnvio[]} envios - Lista de objetos de envío a formatear.
   * @returns {any[]} - Lista de objetos de envío formateados con cantidad y fecha en formato adecuado.
   */
  formatEnvios(envios: IEnvio[]): any[] {
    return envios.map((envio) => ({
      ...envio,
      cantidad: new Intl.NumberFormat('es-ES', {
        style: 'currency',
        currency: envio.divisa,
      }).format(envio.cantidad), // Formato de cantidad con divisa
      fecha: new Date(envio.fecha).toLocaleDateString('es-ES', {
        day: '2-digit',
        month: '2-digit',
        year: 'numeric',
      }), // Formato de fecha
    }));
  }
}
