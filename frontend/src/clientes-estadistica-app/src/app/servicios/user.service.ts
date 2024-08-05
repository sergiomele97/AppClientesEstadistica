import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../clases/usuario';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  private url = 'https://localhost:7107/api/'; 

  constructor(private http: HttpClient) { }

  getUsuarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(`${this.url}Account/users`);
  }
  
  autenticarUsuario(email: string, password: string, remember: boolean): Observable<any> {
    remember = false;
    return this.http.post<any>(`${this.url}Account/login`, { email, password, remember });
  }

  registrarUsuario(usuario: any): Observable<any> {
    console.log(usuario); // Asegúrate de que los campos estén presentes y correctos DEBUG
    return this.http.post<any>(`${this.url}Account/register`, usuario);
  }

  obtenerPaisIdPorNombre(nombre: string): Observable<{ id: number }> {
    // Construir la URL con el nombre del país
    const url = `${this.url}Paises/nombre/${nombre}`;
    
    // Hacer la solicitud GET
    return this.http.get<{ id: number }>(url);
  }

  
}
