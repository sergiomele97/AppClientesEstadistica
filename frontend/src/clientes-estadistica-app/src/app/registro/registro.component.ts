import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../servicios/user.service';
import { Usuario } from '../interfaces/usuario.interface';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {

  registroForm: FormGroup;
  paisId: number | null = null; // Para almacenar el ID del país
  errorMessage: string | null = null; // Mensaje de error general

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

      // Obtener el ID del país por nombre
      this.miServicio.obtenerPaisIdPorNombre(this.registroForm.value.PaisNombre).subscribe(
        response => {
          this.paisId = response.id;
          if (this.paisId !== null) {
            // Crear el objeto usuario con el PaisId obtenido
            const fechaNacTimestamp = new Date(this.registroForm.value.FechaNac).getTime();
            const usuario: Usuario = {
              Email: this.registroForm.value.Correo,
              Password: this.registroForm.value.Contraseña,
              ConfirmPassword: this.registroForm.value.Contraseña2,
              Nombre: this.registroForm.value.Nombre,
              Apellido: this.registroForm.value.Apellido,
              Rol: this.registroForm.value.Rol,
              PaisId: this.paisId, // Asignar el ID del país al usuario
              Empleo: this.registroForm.value.Empleo,
              FechaNacimiento: fechaNacTimestamp
            };
            // Registrar el usuario
            this.miServicio.registrarUsuario(usuario).subscribe(
              response => {
                console.log('Usuario registrado exitosamente', response);
                this.errorMessage = null; // Limpiar mensaje de error
              },
              error => {
                if (error.status === 400) {
                  console.error('Error de validación', error.error);
                  // Verificar si el error es sobre el nombre de usuario duplicado
                  if (error.error.code === 'DuplicateUserName') {
                    this.errorMessage = `Username '${this.registroForm.value.Correo}' is already taken.`;
                  } else {
                    this.errorMessage = 'Error al registrar usuario: ' + error.error.description;
                  }
                } else if (error.status === 0) {
                  console.error('No se pudo conectar al servidor.');
                  this.errorMessage = 'No se pudo conectar al servidor.';
                } else {
                  console.error(`Error ${error.status}: ${error.message}`);
                  this.errorMessage = 'Error al registrar usuario: ' + error.message;
                }
              }
            );
          } else {
            console.error('ID del país no encontrado.');
            this.errorMessage = 'No se encontró el país especificado.';
          }
        },
        error => {
          console.error('Error al obtener el ID del país', error);
          this.errorMessage = 'Error al obtener el ID del país.';
        }
      );
    }
  }
}
