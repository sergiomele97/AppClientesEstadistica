import { Component, OnInit } from '@angular/core';
import { AuthService } from '../servicios/auth.service'; // Importa el AuthService en lugar del UsuarioService
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  errorMessage: string; // Variable para almacenar el mensaje de error
  isErrorVisible = false; // Bandera para controlar la visibilidad del mensaje de error

  email: string = ''; // Variable para almacenar el email del usuario
  password: string = ''; // Variable para almacenar la contraseña del usuario

  constructor(
    private authService: AuthService, // Cambiado a AuthService para manejar autenticación
    private route: Router // Router para redirigir al usuario después del login
  ) {}

  ngOnInit() {
    // Aquí puedes inicializar cualquier cosa si es necesario al cargar el componente
  }

  // Método para autenticar al usuario
  onSubmit() {
    // Llama al método login del AuthService con el email y la contraseña
    this.authService
      .login(this.email, this.password)
      .pipe(
        catchError((error) => {
          // Manejo de errores
          if (error.status === 401) {
            // Si el error es 401, significa que las credenciales son incorrectas
            this.showError('Credenciales incorrectas');
          } else {
            // Otros errores
            this.showError(
              'Ocurrió un error al intentar autenticarse. Por favor, intente de nuevo.'
            );
          }
          // Propaga el error para manejo adicional si es necesario
          return throwError(error);
        })
      )
      .subscribe((response) => {
        // Si la autenticación es exitosa
        if (response && response.token) {
          // Guarda el token en el localStorage para uso futuro (ej. autenticación de solicitudes)
          localStorage.setItem('token', response.token);

          // Guarda el nombre de usuario en el localStorage
          localStorage.setItem('currentUser', response.username);

          // Actualiza el BehaviorSubject del AuthService con el nombre de usuario
          this.authService.setUser(response.username);

          // Redirige al usuario a la página de estadísticas
          this.route.navigate(['/estadistica']);
        }
      });
  }

  // Método para mostrar el mensaje de error
  showError(message: string) {
    // Asigna el mensaje de error y hace visible el mensaje
    this.errorMessage = message;
    this.isErrorVisible = true;
    // Oculta el mensaje después de 3 segundos
    setTimeout(() => (this.isErrorVisible = false), 3000);
  }

  // Método para redirigir a la página de registro
  navigateToRegistro() {
    this.route.navigate(['/registro']);
  }
}
