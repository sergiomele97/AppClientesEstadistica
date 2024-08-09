import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../servicios/user.service';
import { Usuario } from '../interfaces/usuario.interface';
import { CambioRolModel } from '../interfaces/cambioRol.interface';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {

  registroForm: FormGroup;
  errorMessage: string | null = null; // Mensaje de error general

  constructor(private fb: FormBuilder, private miServicio: UserService) { }

  ngOnInit(): void {
    this.registroForm = this.fb.group({
      Nombre: ['', [Validators.required, Validators.minLength(3)]],
      Apellido: ['', [Validators.required, Validators.minLength(3)]],
      Correo: ['', [Validators.required, Validators.email]],
      Contraseña: ['', [Validators.required, Validators.minLength(6)]],
      Contraseña2: ['', [Validators.required]],
      Rol: ['Client', Validators.required],
      PaisNombre: ['', Validators.required],
      Empleo: [''],
      FechaNac: ['', Validators.required]
    }, {
      validator: this.passwordMatchValidator('Contraseña', 'Contraseña2')
    });
  }

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

  onSubmit(): void {
    if (this.registroForm.invalid) {
      this.showValidationErrors();
      return;
    }
  
    if (this.registroForm.value.Contraseña !== this.registroForm.value.Contraseña2) {
      alert('Las contraseñas no coinciden.');
      return;
    }
  
    const fechaNacTimestamp = new Date(this.registroForm.value.FechaNac).getTime();
  
    const usuario: Usuario = {
      Email: this.registroForm.value.Correo,
      Password: this.registroForm.value.Contraseña,
      ConfirmPassword: this.registroForm.value.Contraseña2,
      Nombre: this.registroForm.value.Nombre,
      Apellido: this.registroForm.value.Apellido,
      PaisNombre: this.registroForm.value.PaisNombre,
      FechaNacimiento: fechaNacTimestamp
    };
  
    // Registrar usuario
    this.miServicio.registrarUsuario(usuario).subscribe(
      response => {
        console.log('Usuario registrado exitosamente', response);
  
        // Solo después de que el usuario ha sido registrado exitosamente, agregar el rol
        const datosCambioRol: CambioRolModel = {
          Email: this.registroForm.value.Correo,
          NuevoRol: "Admin",
          Nombre: this.registroForm.value.Nombre,
          Apellido: this.registroForm.value.Apellido,
          Pais: this.registroForm.value.PaisNombre,
          Empleo: this.registroForm.value.Empleo,
          FechaNacimiento: fechaNacTimestamp
        };
  
        this.miServicio.añadirRolUsuario(datosCambioRol).subscribe(
          response => {
            console.log('Rol añadido exitosamente', response);
          },
          error => {
            if (error.status === 400) {
              console.error('Error de validación al añadir rol', error.error);
              alert('Error al añadir rol: ' + error.error);
            } else if (error.status === 0) {
              console.error('No se pudo conectar al servidor al añadir rol.');
              alert('No se pudo conectar al servidor al añadir rol.');
            } else {
              console.error(`Error ${error.status}: ${error.message}`);
              alert('Error al añadir rol: ' + error.message);
            }
          }
        );
  
      },
      error => {
        if (error.status === 400) {
          console.error('Error de validación al registrar usuario', error.error);
          alert('Error al registrar usuario: ' + error.error);
        } else if (error.status === 0) {
          console.error('No se pudo conectar al servidor al registrar usuario.');
          alert('No se pudo conectar al servidor al registrar usuario.');
        } else {
          console.error(`Error ${error.status}: ${error.message}`);
          alert('Error al registrar usuario: ' + error.message);
        }
      }
    );
  }
  

  private showValidationErrors(): void {
    let errorMessage = 'Por favor corrige los siguientes errores:\n';
    const controls = this.registroForm.controls;

    for (const key in controls) {
      if (controls.hasOwnProperty(key)) {
        const control = controls[key];
        if (control.invalid) {
          if (control.errors) {
            if (control.errors['required']) {
              errorMessage += `- El campo ${key} es requerido.\n`;
            }
            if (control.errors['minlength']) {
              errorMessage += `- El campo ${key} debe tener al menos ${control.errors['minlength'].requiredLength} caracteres.\n`;
            }
            if (control.errors['email']) {
              errorMessage += `- El campo ${key} debe ser un email válido.\n`;
            }
            if (control.errors['passwordMismatch']) {
              errorMessage += `- Las contraseñas no coinciden.\n`;
            }
          }
        }
      }
    }

    if (errorMessage === 'Por favor corrige los siguientes errores:\n') {
      errorMessage = 'Hay errores en el formulario. Por favor, corrígelos antes de enviar.';
    }

    alert(errorMessage);
  }
}
