import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../servicios/user.service';
import { UsuarioAdmin } from '../interfaces/usuarioAdmin.interface';

@Component({
  selector: 'app-registroAdmin',
  templateUrl: './registroAdmin.component.html',
  styleUrls: ['./registroAdmin.component.css']
})
export class RegistroAdminComponent implements OnInit {

  registroAdminForm: FormGroup;
  isFormBlocked = false;

  constructor(private fb: FormBuilder, private miServicio: UserService) { }

  ngOnInit(): void {
    this.registroAdminForm = this.fb.group({
      Correo: ['', [Validators.required, Validators.email]],
      Contraseña: ['', [Validators.required, Validators.minLength(6)]],
      Contraseña2: ['', [Validators.required]],
      Rol: ['Admin', Validators.required],
      PaisNombre: ['', Validators.required],
      FechaNac: ['', Validators.required]
    }, {
      validator: this.passwordMatchValidator('Contraseña', 'Contraseña2')
    });

    this.registroAdminForm.valueChanges.subscribe(() => {
      this.checkFormErrors();
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
    if (this.registroAdminForm.invalid) {
      this.checkFormErrors();
      return;
    }

    if (this.registroAdminForm.value.Contraseña !== this.registroAdminForm.value.Contraseña2) {
      alert('Las contraseñas no coinciden.');
      return;
    }

    const fechaNacTimestamp = new Date(this.registroAdminForm.value.FechaNac).getTime();
    const usuario: UsuarioAdmin = {
      Email: this.registroAdminForm.value.Correo,
      Password: this.registroAdminForm.value.Contraseña,
      ConfirmPassword: this.registroAdminForm.value.Contraseña2,
      Rol: this.registroAdminForm.value.Rol,
      PaisNombre: this.registroAdminForm.value.PaisNombre,
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

  private checkFormErrors(): void {
    this.isFormBlocked = this.registroAdminForm.invalid;
  }
}
