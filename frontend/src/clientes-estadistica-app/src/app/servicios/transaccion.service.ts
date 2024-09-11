import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { ITransaccion } from '../interfaces/transaccion';
import { environment } from 'src/environments/environment';

/**
 * Servicio para manejar operaciones relacionadas con transacciones.
 * Proporciona métodos para obtener, formatear y eliminar transacciones y outliers.
 * @service
 */
@Injectable({
  providedIn: 'root',
})
export class TransaccionService {
  /**
   * URL base para las peticiones a la API de estadísticas.
   * @private
   */
  private readonly url_estadistica = environment.apiEstadisticas;

  /**
   * Crea una instancia del servicio para manejar transacciones.
   * @param http - Cliente HTTP para hacer peticiones a la API.
   */
  constructor(private http: HttpClient) {}

  /**
   * Obtiene todas las transacciones.
   * @returns Un observable que emite una lista de transacciones, con los importes formateados.
   */
  getTransacciones(): Observable<ITransaccion[]> {
    return this.http
      .get<ITransaccion[]>(`${this.url_estadistica}/getTransacciones`)
      .pipe(
        map((transacciones) =>
          transacciones.map((transaccion) => ({
            ...transaccion,
            importeEnviado: this.formatearDecimal(transaccion.importeEnviado),
            importeRecibido: this.formatearDecimal(transaccion.importeRecibido),
          }))
        )
      );
  }

  /**
   * Obtiene las transacciones clasificadas como outliers.
   * @returns Un observable que emite una lista de outliers, con los importes formateados.
   */
  obtenerOutlier(): Observable<ITransaccion[]> {
    return this.http
      .get<ITransaccion[]>(`${this.url_estadistica}/getOutliers`)
      .pipe(
        map((transacciones) =>
          transacciones.map((transaccion) => ({
            ...transaccion,
            importeEnviado: this.formatearDecimal(transaccion.importeEnviado),
            importeRecibido: this.formatearDecimal(transaccion.importeRecibido),
          }))
        )
      );
  }

  /**
   * Obtiene las transacciones que han sido vistas como outliers.
   * @returns Un observable que emite una lista de outliers vistos, con los importes formateados.
   */
  outliersVistos(): Observable<ITransaccion[]> {
    return this.http
      .get<ITransaccion[]>(`${this.url_estadistica}/outliers-vistos`)
      .pipe(
        map((transacciones) =>
          transacciones.map((transaccion) => ({
            ...transaccion,
            importeEnviado: this.formatearDecimal(transaccion.importeEnviado),
            importeRecibido: this.formatearDecimal(transaccion.importeRecibido),
          }))
        )
      );
  }

  /**
   * Obtiene las últimas transacciones de un cliente específico.
   * @param clienteId - ID del cliente para obtener las transacciones.
   * @returns Un observable que emite una lista de las últimas transacciones del cliente, con los importes formateados.
   */
  ultimasTransacciones(clienteId: number): Observable<ITransaccion[]> {
    return this.http
      .get<ITransaccion[]>(
        `${this.url_estadistica}/ultimas-transacciones/${clienteId}`
      )
      .pipe(
        map((transacciones) =>
          transacciones.map((transaccion) => ({
            ...transaccion,
            importeEnviado: this.formatearDecimal(transaccion.importeEnviado),
            importeRecibido: this.formatearDecimal(transaccion.importeRecibido),
          }))
        )
      );
  }

  /**
   * Marca una transacción como resuelta y la elimina de los outliers.
   * @param idTransaccion - ID de la transacción a eliminar.
   * @returns Un observable que emite la respuesta del servidor en formato texto.
   */
  borrarOutlier(idTransaccion: number): Observable<string> {
    return this.http.put<string>(
      `${this.url_estadistica}/resolucionOutlier/${idTransaccion}`,
      {},
      { responseType: 'text' as 'json' }
    );
  }

  /**
   * Formatea un valor numérico a dos decimales.
   * @param value - Valor a formatear. Si es null o undefined, se devuelve 0.
   * @returns El valor formateado a dos decimales.
   */
  private formatearDecimal(value: number | null): number {
    if (value === null || value === undefined) {
      return 0;
    }
    return parseFloat(value.toFixed(2));
  }
}
