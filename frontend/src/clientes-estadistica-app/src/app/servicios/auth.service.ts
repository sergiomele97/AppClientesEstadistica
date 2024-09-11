import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { IUsuario } from '../interfaces/usuario';

/**
 * Servicio de autenticación para gestionar el registro, inicio de sesión,
 * cierre de sesión y verificación de autenticación del usuario.
 * @service
 */
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private userSubject: BehaviorSubject<string | null> = new BehaviorSubject<
    string | null
  >(null);
  public user$: Observable<string | null> = this.userSubject.asObservable();

  private readonly apiUrl = environment.apiUsuarios;

  /**
   * Crea una instancia del servicio de autenticación.
   * @param {HttpClient} http - Servicio para realizar solicitudes HTTP.
   * @param {Router} router - Servicio para manejar la navegación entre rutas.
   */
  constructor(private http: HttpClient, private router: Router) {
    const storedUser = localStorage.getItem('currentUser');
    if (storedUser) {
      this.userSubject.next(storedUser);
    }
  }

  /**
   * Registra un nuevo usuario.
   * @param {IUsuario} usuario - Información del usuario a registrar.
   * @returns {Observable<any>} - Un observable que emite la respuesta del servidor.
   */
  register(usuario: IUsuario): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/register`, usuario).pipe(
      catchError((error: HttpErrorResponse) => {
        console.error('Error during registration', error);
        return throwError(error); // Propagar el error
      })
    );
  }

  /**
   * Inicia sesión con las credenciales proporcionadas.
   * @param {string} email - Correo electrónico del usuario.
   * @param {string} password - Contraseña del usuario.
   * @param {boolean} rememberMe - Indica si se debe recordar al usuario.
   * @returns {Observable<{ token: string; username: string }>} - Un observable que emite el token y nombre de usuario.
   */
  login(
    email: string,
    password: string,
    rememberMe: boolean
  ): Observable<{ token: string; username: string }> {
    return this.http
      .post<{ token: string; username: string }>(`${this.apiUrl}/login`, {
        email,
        password,
      })
      .pipe(
        tap((response) => {
          if (response.token) {
            // Guarda el token en localStorage o sessionStorage según el estado del checkbox
            if (rememberMe) {
              localStorage.setItem('token', response.token);
            } else {
              sessionStorage.setItem('token', response.token);
            }
            localStorage.setItem('currentUser', response.username);
            this.userSubject.next(response.username);
            this.router.navigate(['/estadistica']);
          }
        }),
        catchError((error: HttpErrorResponse) => {
          return throwError(error); // Propagar el error
        })
      );
  }

  /**
   * Cierra la sesión del usuario actual.
   * Elimina el token y el nombre de usuario del almacenamiento local y de sesión.
   */
  logout(): void {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('token');
    sessionStorage.removeItem('token'); // Elimina el token de sessionStorage si está presente
    this.userSubject.next(null);
    this.router.navigate(['/login']);
  }

  /**
   * Verifica si el usuario está autenticado.
   * @returns {boolean} - `true` si el token está presente en el almacenamiento local o de sesión, de lo contrario `false`.
   */
  isAuthenticated(): boolean {
    // Comprueba en ambos almacenamiento local y de sesión
    return !!localStorage.getItem('token') || !!sessionStorage.getItem('token');
  }

  /**
   * Establece el nombre de usuario actual.
   * @param {string | null} username - Nombre de usuario a establecer o `null` para desactivar.
   */
  setUser(username: string | null): void {
    this.userSubject.next(username);
  }

  /**
   * Obtiene el nombre de usuario actual.
   * @returns {string | null} - El nombre de usuario actual o `null` si no hay ninguno.
   */
  getCurrentUser(): string | null {
    return this.userSubject.value;
  }
}
