import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { Router } from '@angular/router';
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

  private readonly apiUrl = environment.apiUsuarios;

  constructor(private http: HttpClient, private router: Router) {
    const storedUser = localStorage.getItem('currentUser');
    if (storedUser) {
      this.userSubject.next(storedUser);
    }
  }

  register(usuario: IUsuario): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/register`, usuario).pipe(
      catchError((error: HttpErrorResponse) => {
        console.error('Error during registration', error);
        return throwError(error); // Propagar el error
      })
    );
  }

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

  logout(): void {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('token');
    sessionStorage.removeItem('token'); // Elimina el token de sessionStorage si está presente
    this.userSubject.next(null);
    this.router.navigate(['/login']);
  }

  isAuthenticated(): boolean {
    // Comprueba en ambos almacenamiento local y de sesión
    return !!localStorage.getItem('token') || !!sessionStorage.getItem('token');
  }

  setUser(username: string | null): void {
    this.userSubject.next(username);
  }

  getCurrentUser(): string | null {
    return this.userSubject.value;
  }
}
