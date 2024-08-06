import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../clases/usuario';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  // IMPORTANTE:
  //    1 URL ESTADISTICA Y OTRA PARA CLIENTES
  private url_estadistica = environment.apiUrl; 

  constructor(private http: HttpClient) { }

  getUsuarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(`${this.url_estadistica}Account/users`);
  }

  autenticarUsuario(email: string, password: string, remember: boolean): Observable<any> {
    remember = false;
    return this.http.post<any>(`${this.url_estadistica}Account/login`, { email, password, remember });
  }

  registrarUsuario(usuario: any): Observable<any> {
    console.log(usuario); // Asegúrate de que los campos estén presentes y correctos DEBUG
    return this.http.post<any>(`${this.url_estadistica}Account/register`, usuario);
  }

  obtenerPaisIdPorNombre(nombre: string): Observable<{ id: number }> {
    // Construir la URL con el nombre del país
    const url = `${this.url_estadistica}Paises/nombre/${nombre}`;
    
    // Hacer la solicitud GET
    return this.http.get<{ id: number }>(url);
  }
  
}
