import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../servicios/auth.service'; // Asegúrate de tener el servicio correcto
import { IUsuario } from '../interfaces/usuario'; // Asegúrate de tener la interfaz correcta
import { Router } from '@angular/router';

/**
 * Componente para el formulario de registro de usuarios.
 * @component
 */
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  /**
   * Formulario reactivo para el registro de usuarios.
   * @type {FormGroup}
   */
  registerForm: FormGroup;

  /**
   * Flag para indicar si el formulario está bloqueado por errores.
   * @type {boolean}
   */
  isFormBlocked = false;

  /**
   * Crea una instancia del componente `RegisterComponent`.
   * @param {FormBuilder} fb - Servicio para construir formularios reactivos.
   * @param {AuthService} authService - Servicio para manejar la autenticación.
   * @param {Router} route - Servicio para la navegación entre rutas.
   */
  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private route: Router
  ) {}

  /**
   * Método del ciclo de vida del componente. Se llama después de la creación del componente.
   * Inicializa el formulario de registro con validaciones.
   */
  ngOnInit(): void {
    this.registerForm = this.fb.group(
      {
        email: ['', [Validators.required, Validators.email]], // Campo email con validación de requerimiento y formato de correo electrónico
        password: ['', [Validators.required, Validators.minLength(6)]], // Campo password con validación de requerimiento y longitud mínima
        confirmpassword: ['', [Validators.required]], // Campo confirmar contraseña con validación de requerimiento
        phone: ['', Validators.required], // Campo de teléfono con validación de requerimiento
        terms: [false, Validators.requiredTrue], // Campo términos y condiciones con validación de requerimiento
      },
      {
        validator: this.passwordMatchValidator('password', 'confirmpassword'),
      }
    );
  }

  /**
   * Flag para controlar la visibilidad del modal.
   * @type {boolean}
   */
  isModalOpen = false;

  /**
   * Abre el modal de confirmación.
   */
  openModal() {
    this.isModalOpen = true;
  }

  /**
   * Cierra el modal de confirmación.
   */
  closeModal() {
    this.isModalOpen = false;
  }

  /**
   * Validador personalizado para verificar que las contraseñas coincidan.
   * @param {string} password - Nombre del campo de la contraseña.
   * @param {string} confirmPassword - Nombre del campo de la confirmación de la contraseña.
   * @returns {(formGroup: FormGroup) => void} - Función validadora que verifica la coincidencia de contraseñas.
   */
  passwordMatchValidator(password: string, confirmPassword: string) {
    return (formGroup: FormGroup) => {
      const passwordControl = formGroup.get(password);
      const confirmPasswordControl = formGroup.get(confirmPassword);

      if (
        confirmPasswordControl?.errors &&
        !confirmPasswordControl.errors['passwordMismatch']
      ) {
        return;
      }

      if (passwordControl?.value !== confirmPasswordControl?.value) {
        confirmPasswordControl?.setErrors({ passwordMismatch: true });
      } else {
        confirmPasswordControl?.setErrors(null);
      }
    };
  }

  /**
   * Maneja el envío del formulario de registro.
   * Marca todos los campos como tocados, valida el formulario y realiza la solicitud de registro.
   */
  onSubmit(): void {
    this.registerForm.markAllAsTouched(); // Marca todos los campos como tocados

    if (this.registerForm.invalid) {
      this.isFormBlocked = true;
      return;
    }

    const user: IUsuario = this.registerForm.value;
    this.authService.register(user).subscribe({
      next: (response) => {
        console.log('Registro exitoso', response);
        this.route.navigate(['/login']);
      },
      error: (error) => {
        console.error('Error al registrar el usuario', error);
      },
    });
  }

  /**
   * Navega a la página de inicio de sesión.
   */
  navigateToLogin() {
    this.route.navigate(['/login']);
  }
}
