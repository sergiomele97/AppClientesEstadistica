import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'; // Servicio para navegación
import { catchError } from 'rxjs/operators'; // Operador para manejar errores
import { throwError } from 'rxjs'; // Función para propagar errores
import { AuthService } from '../servicios/auth.service'; // Servicio para autenticación

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  errorMessage: string = ''; // Mensaje de error a mostrar
  isErrorVisible = false; // Controla la visibilidad del mensaje de error

  email: string = ''; // Email del usuario
  password: string = ''; // Contraseña del usuario
  rememberMe: boolean = false; // Estado del checkbox "Recuérdame"

  constructor(
    private authService: AuthService, // Servicio de autenticación
    private route: Router // Servicio de navegación
  ) {}

  ngOnInit() {}

  // Maneja el envío del formulario de inicio de sesión
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
      .subscribe(); // Se suscribe al observable
  }

  // Muestra un mensaje de error en la interfaz
  showError(message: string) {
    this.errorMessage = message;
    this.isErrorVisible = true;
    setTimeout(() => (this.isErrorVisible = false), 3000); // Oculta el mensaje después de 3 segundos
  }

  // Navega a la página de registro
  navigateToRegistro() {
    this.route.navigate(['/registro']);
  }
}
