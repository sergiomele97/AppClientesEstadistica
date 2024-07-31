import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../clases/usuario';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private url = 'https://localhost:44339/api/Account'; // Cambia esta URL por la de tu backend

  constructor(private http: HttpClient) { }

  getUsuarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.url);
  }

  autenticarUsuario(email: string, password: string, remember: boolean): Observable<any> {
    remember = false;
    return this.http.post<any>(`${this.url}/login`, { email, password, remember });
  }

  registrarUsuario(usuario: Usuario): Observable<Usuario> {
    console.log(usuario); // Asegúrate de que los campos estén presentes y correctos DEBUG
    return this.http.post<Usuario>(`${this.url}/register`, usuario);
  }
}
