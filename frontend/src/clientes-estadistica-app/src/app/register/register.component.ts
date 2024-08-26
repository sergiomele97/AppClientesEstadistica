import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../servicios/user.service';
import { UsuarioAdmin } from '../interfaces/usuarioAdmin.interface';
import { User } from '../interfaces/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  isFormBlocked = false;

  constructor(private fb: FormBuilder, private miServicio: UserService, private route: Router) { }


  ngOnInit(): void {
    // inyectamos el formulario
    this.registerForm = this.fb.group({

      // Se inicializan con valor vacio y validan con  validadores
      // Todos required y alguno extra
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmpassword: ['', [Validators.required]],
      phone: ['', Validators.required],
    }, {
      // Esto es un validador personalizado
      validator: this.passwordMatchValidator('password', 'confirmpassword')
    });
  }

  // Método para comprobar que las dos contraseñas sean iguales
  passwordMatchValidator(password: string, confirmPassword: string) {
    return (formGroup: FormGroup) => {
      const passwordControl = formGroup.get(password);
      const confirmPasswordControl = formGroup.get(confirmPassword);

      if (confirmPasswordControl?.errors && !confirmPasswordControl.errors['passwordMismatch']) {
        return;
      }

      if (passwordControl?.value !== confirmPasswordControl?.value) {
        confirmPasswordControl?.setErrors({ passwordMismatch: true });
      } else {
        confirmPasswordControl?.setErrors(null);
      }
    };
  }
  
  // Metodo que se ejecuta al pulsar en el botón de registro
  onSubmit(): void {

    // 1. Es válido el formulario? (Se cumplen todos los validators?)
    if (this.registerForm.invalid) {
      this.checkFormErrors();
      return; // Si no es válido, ahí acabamos
    }

    // 2. Coindicen las contraseñas?
    if (this.registerForm.value.password !== this.registerForm.value.confirmpassword) {
      alert('Las contraseñas no coinciden.');
      return;
    }

    // 3. Crear objeto usuario
    const usuario: User = {
      Correo: this.registerForm.value.email,
      Contraseña: this.registerForm.value.password,
      confirmpassword: this.registerForm.value.confirmpassword,
      Telefono: this.registerForm.value.phone,
     
    };

    // 4. Registrar usuario en el backend
    this.miServicio.registrarUsuario(usuario).subscribe(
      response => {
        console.log('Usuario registrado exitosamente', response);
        this.onRegistroOK()
      },
      error => {
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

  onRegistroOK(): void{
    this.route.navigate(['/login']);
    
  }

  navigateToLogin() {
    this.route.navigate(['/login']);
  }

  private checkFormErrors(): void {
    this.isFormBlocked = this.registerForm.invalid;
  }
  
}
