import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MiServicioService {

  private apiUrl = 'https://localhost:7144/api/usuarios'; // URL de tu backend

  constructor(private http: HttpClient) { }

  getUsuarios(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
  
}
