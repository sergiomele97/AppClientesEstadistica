import { Component, OnInit } from '@angular/core';
import { UserService } from '../servicios/user.service';
import { Usuario } from '../clases/usuario';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  errorMessage: string;
  isErrorVisible = false;
  usuarios: Usuario[];

  email: string = '';

  contrase: string = '';
  password: any;
  username: any;

  constructor(private usuarioService: UserService, private route: Router) { }

  navigateToRegistro() {
    this.route.navigate(['/registro']);
  }


  ngOnInit() {
    
  }

  authentication() {
    this.usuarioService.autenticarUsuario(this.email, this.contrase, true)
      .pipe(
        catchError(error => {
          if (error.status === 401) {
            this.showError('Credenciales incorrectas');
          } else {
            this.showError('Ocurrió un error al intentar autenticarse. Por favor, intente de nuevo.');
          }
          return throwError(error);
        })
      )
      .subscribe(response => {
        //if (response && response.token) {
          //localStorage.setItem('token', response.token);
          console.log("respuesta")      
          this.route.navigate(['/estadistica']); // Redirige a la ruta protegida
      });
  }
  
  showError(message: string) {
    this.errorMessage = message;
    this.isErrorVisible = true;
    setTimeout(() => this.isErrorVisible = false, 3000); // Ocultar el mensaje después de 5 segundos
  }
}
