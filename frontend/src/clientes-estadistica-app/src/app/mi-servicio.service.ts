import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class MiServicioService {

  private apiUrl = 'https://localhost:7144/api/usuarios'; // Cambia esta URL por la de tu backend

  constructor(private http: HttpClient) { }

  registrarUsuario(usuario: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/crearUsuario`, usuario);
  }

  getUsuarios(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
