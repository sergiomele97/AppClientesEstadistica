import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IUsuario } from '../interfaces/usuario';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {


  constructor(private http: HttpClient) {}

  // URL base para las solicitudes a la API
  private readonly apiUrl = environment.apiUsuarios; // Asegúrate de que el environment esté configurado correctamente

  // Método para obtener la lista de usuarios
  getUsers(): Observable<IUsuario[]> {
    return this.http.get<IUsuario[]>(`${this.apiUrl}/getUsers`);
  }

  // Método para registrar un nuevo usuario
  registro(usuario: IUsuario): Observable<any> {
    // El método POST envía los datos del usuario al backend para registrarlo
    return this.http.post<any>(`${this.apiUrl}/register`, usuario);
  }

  // Método para iniciar sesión
  login(email: string, password: string): Observable<any> {
    // El método POST envía las credenciales al backend para autenticar al usuario
    return this.http.post<any>(`${this.apiUrl}/login`, {email, password});
  }
}
