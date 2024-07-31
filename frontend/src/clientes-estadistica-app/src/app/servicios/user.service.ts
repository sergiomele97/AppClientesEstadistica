import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../clases/usuario';

@Injectable()
export class UserService {

    private url = 'https://localhost:7144/api/usuarios';    // Cambia esta URL por la de tu backend

// Constructor que instancia un servicio http
constructor(private http: HttpClient) { }

getUsuarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.url);
}

autenticarUsuario(email: string, password: string): Observable<Usuario[]> {     // pendiente (enviaremos solo 1 usuario y se comprobara en back)
    return this.http.get<Usuario[]>(`${this.url}?email=${email}&password=${password}`);
}

// Método con parámetro tipo usuario
registrarUsuario(usuario: Usuario): Observable<Usuario> {
    console.log(usuario); // Asegúrate de que los campos estén presentes y correctos DEBUG
    return this.http.post<Usuario>(`${this.url}/crearUsuario`, usuario);
  }

}

  