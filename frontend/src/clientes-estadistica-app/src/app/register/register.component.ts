import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../servicios/auth.service'; // Importa el AuthService en lugar del UsuarioService
import { IUsuario } from '../interfaces/usuario'; // Importamos la interfaz del usuario
import { Router } from '@angular/router'; // Importamos Router para la navegación

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup; // Definimos un formulario reactivo de Angular
  isFormBlocked = false; // Flag para indicar si el formulario está bloqueado por errores

  constructor(
    private fb: FormBuilder, // Inyectamos FormBuilder para construir el formulario
    private authService: AuthService, // Inyectamos AuthService en lugar de UsuarioService
    private route: Router // Inyectamos Router para manejar la navegación entre rutas
  ) {}

  ngOnInit(): void {
    // Inicializamos el formulario cuando el componente se carga
    this.registerForm = this.fb.group(
      {
        email: ['', [Validators.required, Validators.email]], // Campo email con validadores de requerido y formato de email
        password: ['', [Validators.required, Validators.minLength(6)]], // Campo password con validadores de requerido y longitud mínima
        confirmpassword: ['', [Validators.required]], // Campo para confirmar la contraseña, también requerido
        phone: ['', Validators.required], // Campo de teléfono, requerido
      },
      {
        // Agregamos un validador personalizado para verificar que las contraseñas coinciden
        validator: this.passwordMatchValidator('password', 'confirmpassword'),
      }
    );
  }

  // Validador personalizado para verificar que las contraseñas coincidan
  passwordMatchValidator(password: string, confirmPassword: string) {
    return (formGroup: FormGroup) => {
      const passwordControl = formGroup.get(password); // Obtenemos el control del campo de contraseña
      const confirmPasswordControl = formGroup.get(confirmPassword); // Obtenemos el control del campo de confirmación de contraseña

      // Si ya hay otros errores, no sobrescribimos esos errores
      if (
        confirmPasswordControl?.errors &&
        !confirmPasswordControl.errors['passwordMismatch']
      ) {
        return;
      }

      // Si las contraseñas no coinciden, establecemos un error en el campo de confirmación
      if (passwordControl?.value !== confirmPasswordControl?.value) {
        confirmPasswordControl?.setErrors({ passwordMismatch: true });
      } else {
        confirmPasswordControl?.setErrors(null); // Si coinciden, limpiamos cualquier error previo
      }
    };
  }

  // Método que se ejecuta al pulsar en el botón de registro
  onSubmit(): void {
    // 1. Validamos el formulario, si es inválido mostramos los errores y terminamos la función
    if (this.registerForm.invalid) {
      this.checkFormErrors(); // Verifica los errores en el formulario
      return; // Si no es válido, finalizamos la ejecución
    }

    // 2. Validamos nuevamente si las contraseñas coinciden, aunque ya lo hace el validador personalizado
    if (
      this.registerForm.value.password !==
      this.registerForm.value.confirmpassword
    ) {
      alert('Las contraseñas no coinciden.');
      return;
    }

    // 3. Creamos un objeto usuario con los datos del formulario
    const usuario: IUsuario = {
      email: this.registerForm.value.email, // Asignamos el valor del email
      password: this.registerForm.value.password, // Asignamos la contraseña
      confirmpassword: this.registerForm.value.confirmpassword, // Asignamos la confirmación de contraseña
      phoneNumber: this.registerForm.value.phone, // Asignamos el teléfono
    };

    // 4. Llamar al servicio para registrar el usuario en el backend
    this.authService.register(usuario).subscribe(
      (response) => {
        // Registro exitoso
        console.log('Usuario registrado exitosamente', response);
        this.onRegistroOK(); // Navega al login después del registro
      },
      (error) => {
        // Manejo de errores
        if (error.status === 400) {
          console.error('Error de validación', error.error);
          alert('Error al registrar usuario: ' + error.error);
        } else if (error.status === 0) {
          console.error('No se pudo conectar al servidor.');
          alert('No se pudo conectar al servidor.');
        } else {
          console.error(`Error ${error.status}: ${error.message}`);
          alert('Error al registrar usuario: ' + error.message);
        }
      }
    );
  }

  // Método que se ejecuta cuando el registro es exitoso
  onRegistroOK(): void {
    this.route.navigate(['/login']); // Navegamos a la página de login
  }

  // Método para navegar manualmente a la página de login (puede usarse desde el template)
  navigateToLogin() {
    this.route.navigate(['/login']);
  }

  // Método para comprobar los errores del formulario y bloquear el botón si es necesario
  private checkFormErrors(): void {
    this.isFormBlocked = this.registerForm.invalid; // Si el formulario es inválido, bloqueamos el formulario
  }
}
