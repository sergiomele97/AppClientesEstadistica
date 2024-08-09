import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() {}

  // Método para verificar si el usuario está autenticado
  isLoggedIn(): boolean {
    return !!localStorage.getItem('token'); // Comprueba si hay un token en el almacenamiento local
  }
}
