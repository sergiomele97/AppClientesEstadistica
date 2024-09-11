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
   * URL base para las solicitudes relacionadas con estadísticas de países.
   * @private
   */
  private readonly urlEstadistica = environment.apiEstadisticas;

  /**
   * Crea una instancia del servicio de países.
   * @param http - Servicio para realizar solicitudes HTTP.
   */
  constructor(private http: HttpClient) {}

  /**
   * Obtiene una lista de todos los países desde el backend.
   * @returns Observable que emite un array de objetos que implementan la interfaz IPais.
   */
  getPaises(): Observable<IPais[]> {
    return this.http.get<IPais[]>(`${this.urlEstadistica}/getPaises`);
  }
}
