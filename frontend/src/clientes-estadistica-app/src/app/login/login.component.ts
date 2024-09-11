import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { AuthService } from '../servicios/auth.service';

/**
 * Componente para el formulario de inicio de sesión.
 * @component
 */
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  /**
   * Mensaje de error a mostrar en la interfaz.
   * @type {string}
   */
  errorMessage: string = '';

  /**
   * Controla la visibilidad del mensaje de error.
   * @type {boolean}
   */
  isErrorVisible: boolean = false;

  /**
   * Email del usuario para el inicio de sesión.
   * @type {string}
   */
  email: string = '';

  /**
   * Contraseña del usuario para el inicio de sesión.
   * @type {string}
   */
  password: string = '';

  /**
   * Estado del checkbox "Recuérdame".
   * @type {boolean}
   */
  rememberMe: boolean = false;

  /**
   * Crea una instancia del componente `LoginComponent`.
   * @param {AuthService} authService - Servicio de autenticación para manejar el inicio de sesión.
   * @param {Router} route - Servicio de navegación para redirigir a otras páginas.
   */
  constructor(private authService: AuthService, private router: Router) {}

  /**
   * Método del ciclo de vida del componente. Se llama después de la creación del componente.
   */
  ngOnInit(): void {}

  /**
   * Maneja el envío del formulario de inicio de sesión.
   * Intenta autenticar al usuario utilizando el servicio `AuthService`.
   */
  onSubmit(): void {
    this.authService
      .login(this.email, this.password, this.rememberMe)
      .pipe(
        catchError((error) => {
          const message = this.getErrorMessage(error.status);
          this.showError(message);
          return throwError(error);
        })
      )
      .subscribe({
        next: () => {
          this.router.navigate(['/dashboard']); // Redirige al dashboard después de iniciar sesión
        },
        error: (error) => {
          console.error('Error en el proceso de inicio de sesión:', error);
        },
      });
  }

  /**
   * Obtiene un mensaje de error basado en el código de estado HTTP.
   * @param {number} status - Código de estado HTTP del error.
   * @returns {string} - Mensaje de error correspondiente.
   */
  private getErrorMessage(status: number): string {
    switch (status) {
      case 401:
        return 'Credenciales incorrectas. Verifique su email y contraseña.';
      case 400:
        return 'Solicitud incorrecta. Verifique los datos proporcionados.';
      default:
        return 'Ocurrió un error al intentar autenticarse. Intente de nuevo.';
    }
  }

  /**
   * Muestra un mensaje de error en la interfaz.
   * El mensaje se oculta automáticamente después de 3 segundos.
   * @param {string} message - El mensaje de error a mostrar.
   */
  private showError(message: string): void {
    this.errorMessage = message;
    this.isErrorVisible = true;
    setTimeout(() => (this.isErrorVisible = false), 3000);
  }

  /**
   * Navega a la página de registro.
   * Este método es llamado cuando el usuario selecciona la opción de registro.
   */
  navigateToRegistro(): void {
    this.router.navigate(['/registro']);
  }
}
