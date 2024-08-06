import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../servicios/user.service';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent implements OnInit {

  registroForm: FormGroup;
  paisId: number | null = null; // Para almacenar el ID del país

  constructor(private fb: FormBuilder, private miServicio: UserService) { }

  ngOnInit(): void {
    this.registroForm = this.fb.group({
      Nombre: ['', Validators.required],
      Apellido: ['', Validators.required],
      Correo: ['', [Validators.required, Validators.email]],
      Contraseña: ['', Validators.required],
      Contraseña2: ['', Validators.required],
      Rol: ['Client', Validators.required],  // Puede ser un campo oculto si siempre es 'Client'
      PaisNombre: ['', ] // Campo para el nombre del país
    });
  }

  onSubmit(): void {
    if (this.registroForm.valid) {
      if (this.registroForm.value.Contraseña !== this.registroForm.value.Contraseña2) {
        console.error('Las contraseñas no coinciden');
        return;
      }
      
      // Obtener el ID del país por nombre
       this.miServicio.obtenerPaisIdPorNombre(this.registroForm.value.PaisNombre).subscribe(
        response => {
          this.paisId = response.Id;
          if (this.paisId !== null) {
            // Crear el objeto usuario con el PaisId obtenido
            const usuario = {
              Email: this.registroForm.value.Correo,
              Password: this.registroForm.value.Contraseña,
              ConfirmPassword: this.registroForm.value.Contraseña2,
              Nombre: this.registroForm.value.Nombre,
              Apellido: this.registroForm.value.Apellido,
              Rol: this.registroForm.value.Rol,
              PaisId: this.paisId // Asignar el ID del país al usuario
              
            };
            // Registrar el usuario
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
          } else {
            console.error('ID del país no encontrado.');
            alert('No se encontró el país especificado.');
          }
        },
        error => {
          console.error('Error al obtener el ID del país', error);
          alert('Error al obtener el ID del país.');
        }
      );
    }
  }
}
