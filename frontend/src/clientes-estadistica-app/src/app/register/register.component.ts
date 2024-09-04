import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../servicios/auth.service'; // Asegúrate de tener el servicio correcto
import { IUsuario } from '../interfaces/usuario'; // Asegúrate de tener la interfaz correcta
import { Router } from '@angular/router';

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
    private authService: AuthService, // Inyectamos AuthService
    private route: Router // Inyectamos Router para manejar la navegación entre rutas
  ) {}

  ngOnInit(): void {
    this.registerForm = this.fb.group(
      {
        email: ['', [Validators.required, Validators.email]], // Campo email
        password: ['', [Validators.required, Validators.minLength(6)]], // Campo password
        confirmpassword: ['', [Validators.required]], // Campo confirmar contraseña
        phone: ['', Validators.required], // Campo de teléfono
        terms: [false, Validators.requiredTrue], // Campo términos y condiciones
      },
      {
        validator: this.passwordMatchValidator('password', 'confirmpassword'),
      }
    );
  }

  isModalOpen = false;

  openModal() {
    this.isModalOpen = true;
  }

  closeModal() {
    this.isModalOpen = false;
  }

  // Validador personalizado para verificar que las contraseñas coincidan
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

  navigateToLogin() {
    this.route.navigate(['/login']);
  }
}
