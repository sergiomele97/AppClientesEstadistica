import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../servicios/user.service';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})

export class RegistroComponent implements OnInit {

  // Define una propiedad para el formulario de registro
  registroForm: FormGroup;

  // Constructor de la clase que inyecta FormBuilder y UserService
  constructor(private fb: FormBuilder, private miServicio: UserService) { }

  // Método que se ejecuta al inicializar el componente
  ngOnInit(): void {

    // Inicializa el formulario con FormBuilder
    this.registroForm = this.fb.group({
      nombre: ['', Validators.required],           // Campo 'nombre', requerido
      email: ['', [Validators.required, Validators.email]],  // Campo 'email', requerido y debe ser un email válido
      password: ['', Validators.required]           // Campo 'password', requerido
      
    });
  }

  // Método que se ejecuta al enviar el formulario
  onSubmit(): void {
    
    if (this.registroForm.valid) {
      // Llama al método registrarUsuario del servicio con los datos del formulario
      this.miServicio.registrarUsuario(this.registroForm.value).subscribe(
        response => {
          console.log('Usuario registrado exitosamente', response);
          // Manejar la respuesta exitosa aquí 
        },
        error => {
          console.error('Error al registrar usuario', error);
          // Manejar el error aquí 
        }
      );
    } else {
      console.error('Formulario inválido');
      
    }
  }
}
