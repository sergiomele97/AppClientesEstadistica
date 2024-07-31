import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../clases/usuario';

@Injectable()
export class UserService {

    private url = 'https://localhost:7144/api/usuarios';    // Cambia esta URL por la de tu backend

constructor(private http: HttpClient) { }

getUsuarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.url);
}

autenticarUsuario(email: string, password: string): Observable<Usuario[]> {     // pendiente (enviaremos solo 1 usuario y se comprobara en back)
    return this.http.get<Usuario[]>(`${this.url}?email=${email}&password=${password}`);
}

registrarUsuario(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(`${this.url}/crearUsuario`, usuario);
  }

}

  