import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../clases/usuario';
import { environment } from '../../environments/environment';

/**
 * Servicio para probar la conexión con la API y realizar operaciones relacionadas con los usuarios.
 * @service
 */
@Injectable({
  providedIn: 'root',
})
export class PruebaConexionService {
  /**
   * URL base para las solicitudes relacionadas con usuarios.
   * @private
   */
  private readonly url_estadistica = environment.apiUsuarios;

  /**
   * Crea una instancia del servicio para probar la conexión con la API.
   * @param http - Instancia del cliente HTTP para realizar solicitudes.
   */
  constructor(private http: HttpClient) {}

  /**
   * Obtiene un usuario por su ID desde la API.
   * Este método está destinado a fines de depuración en Azure.
   * @param id - ID del usuario a obtener.
   * @returns Observable del usuario con el ID proporcionado.
   */
  getUsuarioById(id: number): Observable<Usuario> {
    const url = `${this.url_estadistica}/${id}`;
    return this.http.get<Usuario>(url);
  }
}
