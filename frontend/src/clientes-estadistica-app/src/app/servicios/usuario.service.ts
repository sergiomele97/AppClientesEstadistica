import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IUsuario } from '../interfaces/usuario';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

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
   * URL base para las solicitudes a la API de usuarios.
   * @private
   */
  private readonly apiUrl = environment.apiUsuarios;

  /**
   * Crea una instancia del servicio de usuarios.
   * @param http - Cliente HTTP para hacer peticiones a la API.
   */
  constructor(private http: HttpClient) {}

  /**
   * Obtiene la lista de usuarios.
   * @returns Un observable que emite una lista de usuarios.
   */
  getUsers(): Observable<IUsuario[]> {
    return this.http
      .get<IUsuario[]>(`${this.apiUrl}/getUsers`)
      .pipe(catchError(this.handleError<IUsuario[]>('getUsers', [])));
  }

  /**
   * Registra un nuevo usuario.
   * @param usuario - Objeto que contiene los datos del usuario a registrar.
   * @returns Un observable que emite la respuesta del servidor.
   */
  registro(usuario: IUsuario): Observable<any> {
    return this.http
      .post<any>(`${this.apiUrl}/register`, usuario)
      .pipe(catchError(this.handleError<any>('registro')));
  }

  /**
   * Inicia sesión de un usuario.
   * @param email - Correo electrónico del usuario.
   * @param password - Contraseña del usuario.
   * @returns Un observable que emite la respuesta del servidor.
   */
  login(email: string, password: string): Observable<any> {
    return this.http
      .post<any>(`${this.apiUrl}/login`, { email, password })
      .pipe(catchError(this.handleError<any>('login')));
  }

  /**
   * Maneja los errores que ocurren durante las solicitudes HTTP.
   * @param operation - Nombre de la operación que falló.
   * @param result - Resultado opcional que se devuelve en caso de error.
   * @returns Función que maneja el error.
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(`${operation} failed: ${error.message}`);
      // Dejar que la aplicación siga funcionando devolviendo un resultado vacío.
      return of(result as T);
    };
  }
}
