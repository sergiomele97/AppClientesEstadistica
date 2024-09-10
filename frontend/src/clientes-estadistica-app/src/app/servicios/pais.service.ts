import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPais } from '../interfaces/pais';
import { environment } from 'src/environments/environment';

/**
 * Servicio para manejar operaciones relacionadas con países.
 * @service
 */
@Injectable({
  providedIn: 'root',
})
export class PaisService {
  /**
   * Crea una instancia del servicio de países.
   * @param http - Instancia del cliente HTTP para realizar solicitudes.
   */
  constructor(private http: HttpClient) {}

  /**
   * URL base para las solicitudes relacionadas con estadísticas.
   * @private
   */
  private readonly url_estadistica = environment.apiEstadisticas;

  /**
   * Obtiene una lista de todos los países desde el backend.
   * @returns Observable de un array de objetos que implementan la interfaz IPais.
   */
  getPaises(): Observable<IPais[]> {
    return this.http.get<IPais[]>(`${this.url_estadistica}/getPaises`);
  }
}
