import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IUsuario } from '../interfaces/usuario';
import { Observable } from 'rxjs';

/**
 * Servicio para manejar operaciones relacionadas con usuarios.
 * Proporciona métodos para obtener usuarios, registrar un nuevo usuario e iniciar sesión.
 * @service
 */
@Injectable({
  providedIn: 'root',
})
export class UsuarioService {
  /**
   * Crea una instancia del servicio de usuarios.
   * @param http - Cliente HTTP para hacer peticiones a la API.
   */
  constructor(private http: HttpClient) {}

  /**
   * URL base para las solicitudes a la API de usuarios.
   * @private
   */
  private readonly apiUrl = environment.apiUsuarios;

  /**
   * Obtiene la lista de usuarios.
   * @returns Un observable que emite una lista de usuarios.
   */
  getUsers(): Observable<IUsuario[]> {
    return this.http.get<IUsuario[]>(`${this.apiUrl}/getUsers`);
  }

  /**
   * Registra un nuevo usuario.
   * @param usuario - Objeto que contiene los datos del usuario a registrar.
   * @returns Un observable que emite la respuesta del servidor.
   */
  registro(usuario: IUsuario): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/register`, usuario);
  }

  /**
   * Inicia sesión de un usuario.
   * @param email - Correo electrónico del usuario.
   * @param password - Contraseña del usuario.
   * @returns Un observable que emite la respuesta del servidor.
   */
  login(email: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/login`, { email, password });
  }
}
