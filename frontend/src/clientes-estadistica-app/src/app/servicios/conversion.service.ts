import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
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
   * URL base para las solicitudes relacionadas con conversiones.
   * @private
   */
  private readonly urlEstadistica = environment.apiEstadisticas;

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
    return this.http
      .get<IConversion[]>(`${this.urlEstadistica}/getConversiones`)
      .pipe(
        catchError(this.handleError) // Manejo de errores
      );
  }

  /**
   * Maneja errores de las solicitudes HTTP.
   * @param error - El error de la solicitud HTTP.
   * @returns {Observable<never>} - Observable que emite un error.
   */
  private handleError(error: any): Observable<never> {
    console.error('Ocurrió un error:', error);
    return throwError(
      () => new Error('Error al obtener las conversiones. Inténtelo más tarde.')
    );
  }
}
