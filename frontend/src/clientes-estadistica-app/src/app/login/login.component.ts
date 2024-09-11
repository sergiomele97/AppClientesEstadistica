import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'; // Servicio para navegación
import { catchError } from 'rxjs/operators'; // Operador para manejar errores
import { throwError } from 'rxjs'; // Función para propagar errores
import { AuthService } from '../servicios/auth.service'; // Servicio para autenticación

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
  isErrorVisible = false;

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
  constructor(private authService: AuthService, private route: Router) {}

  /**
   * Método del ciclo de vida del componente. Se llama después de la creación del componente.
   */
  ngOnInit() {}

  /**
   * Maneja el envío del formulario de inicio de sesión.
   * Intenta autenticar al usuario utilizando el servicio `AuthService`.
   */
  onSubmit() {
    this.authService
      .login(this.email, this.password, this.rememberMe) // Pasar el estado de rememberMe
      .pipe(
        catchError((error) => {
          // Define mensajes de error basados en el código de estado
          const message =
            error.status === 401
              ? 'Credenciales incorrectas. Verifique su email y contraseña.'
              : error.status === 400
              ? 'Solicitud incorrecta. Verifique los datos proporcionados.'
              : 'Ocurrió un error al intentar autenticarse. Intente de nuevo.';

          this.showError(message); // Muestra el mensaje de error
          return throwError(error); // Propaga el error
        })
      )
      .subscribe(); // Se suscribe al observable para ejecutar la solicitud
  }

  /**
   * Muestra un mensaje de error en la interfaz.
   * El mensaje se oculta automáticamente después de 3 segundos.
   * @param {string} message - El mensaje de error a mostrar.
   */
  showError(message: string) {
    this.errorMessage = message;
    this.isErrorVisible = true;
    setTimeout(() => (this.isErrorVisible = false), 3000); // Oculta el mensaje después de 3 segundos
  }

  /**
   * Navega a la página de registro.
   * Este método es llamado cuando el usuario selecciona la opción de registro.
   */
  navigateToRegistro() {
    this.route.navigate(['/registro']);
  }
}
