import { Component, OnInit } from '@angular/core';
import { UserService } from '../servicios/user.service';
import { Usuario } from '../clases/usuario';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  usuarios: Usuario[];

  email: string = '';

  contraseña: string = '';

  constructor(private usuarioService: UserService, private route: Router) { }

  ngOnInit() {
    this.getUsuarios();
  }

  getUsuarios() {

    this.usuarioService.getUsuarios().subscribe( datos => {
      this.usuarios = datos;

      console.log(datos);
    });

  }

  authentication() {

    this.usuarioService.autenticarUsuario(this.email, this.contraseña).subscribe( datos => {

      if (datos.length > 0) { 
        this.route.navigate(['/registro']);
      } else {
        alert('Credenciales incorrectas');
      }

    });

  }

}
