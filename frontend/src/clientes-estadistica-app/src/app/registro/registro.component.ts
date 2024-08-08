import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../servicios/user.service';
import { Usuario } from '../interfaces/usuario.interface'; // Ajusta la ruta según sea necesario

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {

  registroForm: FormGroup;

  constructor(private fb: FormBuilder, private miServicio: UserService) { }

  ngOnInit(): void {
    this.registroForm = this.fb.group({
      Nombre: ['', [Validators.required, Validators.minLength(2)]],
      Apellido: ['', [Validators.required, Validators.minLength(2)]],
      Correo: ['', [Validators.required, Validators.email]],
      Contraseña: ['', [
        Validators.required,
        Validators.minLength(6),
        this.passwordValidators
      ]],
      Contraseña2: ['', [Validators.required, Validators.minLength(6)]],
      Rol: ['Client', Validators.required],  // Puede ser un campo oculto si siempre es 'Client'
      PaisNombre: [''],
      Empleo: [''],
      FechaNac: ['', Validators.required]
    }, {
      validators: this.passwordMatchValidator
    });
  }

  passwordValidators(control: any) {
    const value = control.value || '';
    const errors: any = {};

    if (!/[A-Z]/.test(value)) {
      errors['passwordRequiresUpper'] = true;
    }
    if (!/[a-z]/.test(value)) {
      errors['passwordRequiresLower'] = true;
    }
    if (!/\W/.test(value)) { // \W matches any non-word character
      errors['passwordRequiresNonAlphanumeric'] = true;
    }

    return Object.keys(errors).length ? errors : null;
  }

  passwordMatchValidator(form: FormGroup): { [key: string]: boolean } | null {
    return form.get('Contraseña')?.value === form.get('Contraseña2')?.value
      ? null
      : { 'mismatch': true };
  }

  onSubmit(): void {
    if (this.registroForm.valid) {
      if (this.registroForm.value.Contraseña !== this.registroForm.value.Contraseña2) {
        this.errorMessage = 'Passwords do not match.';
        return;
      }

    const fechaNacTimestamp = new Date(this.registroForm.value.FechaNac).getTime();

    const usuario: Usuario = {
      Email: this.registroForm.value.Correo,
      Password: this.registroForm.value.Contraseña,
      ConfirmPassword: this.registroForm.value.Contraseña2,
      Nombre: this.registroForm.value.Nombre,
      Apellido: this.registroForm.value.Apellido,
      Rol: this.registroForm.value.Rol,
      PaisNombre: this.registroForm.value.PaisNombre,
      Empleo: this.registroForm.value.Empleo,
      FechaNacimiento: fechaNacTimestamp
    };

    this.miServicio.registrarUsuario(usuario).subscribe(
      response => {
        console.log('Usuario registrado exitosamente', response);
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
