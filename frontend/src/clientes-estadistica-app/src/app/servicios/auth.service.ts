// src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http'; // Para realizar solicitudes HTTP
import { catchError, tap } from 'rxjs/operators';
import { Router } from '@angular/router'; // Para redirigir a otras rutas
import { of } from 'rxjs'; // Para manejar errores
import { environment } from 'src/environments/environment';
import { IUsuario } from '../interfaces/usuario';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private userSubject: BehaviorSubject<string | null> = new BehaviorSubject<
    string | null
  >(null);
  public user$: Observable<string | null> = this.userSubject.asObservable();

  // URL base para las solicitudes a la API
  private readonly apiUrl = environment.apiUsuarios; // Asegúrate de que el environment esté configurado correctamente

  constructor(private http: HttpClient, private router: Router) {
    // Cargar el usuario desde localStorage si existe
    const storedUser = localStorage.getItem('currentUser');
    if (storedUser) {
      this.userSubject.next(storedUser);
    }
  }

// Método para registrar un nuevo usuario
register(usuario: IUsuario): Observable<any> {
  return this.http
    .post<any>(`${this.apiUrl}/register`, usuario) // Asume que la ruta es /register y que el backend acepta un objeto IUsuario
    .pipe(
      tap((response) => {
        // Puedes manejar respuestas o configuraciones adicionales aquí si es necesario
      }),
      catchError((error) => {
        console.error('Error during registration', error);
        return of(null); // Manejar el error y retornar un observable
      })
    );
}

  // Método para iniciar sesión con el correo electrónico
  login(email: string, password: string): Observable<any> {
    return this.http
      .post<{ token: string; username: string }>(`${this.apiUrl}/login`, {
        email,
        password,
      })
      .pipe(
        tap((response) => {
          if (response.token) {
            // Guardar el nombre de usuario en localStorage
            localStorage.setItem('currentUser', response.username);
            this.userSubject.next(response.username); // Actualizar el BehaviorSubject con el nombre de usuario
            this.router.navigate(['/estadistica']); // Redirige a la página principal o al destino deseado
          }
        }),
        catchError((error) => {
          console.error('Error during login', error);
          return of(null); // Manejar el error y retornar un observable
        })
      );
  }

  // Método para cerrar sesión
  logout(): void {
    localStorage.removeItem('currentUser'); // Elimina el usuario del localStorage
    this.userSubject.next(null); // Actualiza el BehaviorSubject
    this.router.navigate(['/login']); // Redirige al usuario a la página de inicio de sesión
  }

  // Método para verificar si hay un usuario autenticado
  isAuthenticated(): boolean {
    return this.userSubject.value !== null;
  }

  // Método para establecer el nombre de usuario en el BehaviorSubject
  setUser(username: string | null): void {
    this.userSubject.next(username);
  }

  // Método para obtener el nombre de usuario actual
  getCurrentUser(): string | null {
    return this.userSubject.value;
  }
}
