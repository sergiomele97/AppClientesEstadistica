import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';

import { IEnvio } from '../interfaces/envios';

@Injectable({
  providedIn: 'root'
})

export class EnviosService {

constructor(private http: HttpClient) { }

private readonly url_prueba = "https://localhost:7144/api/usuarios";



getEnvios(): Observable<IEnvio[]> {
  return this.http.get<IEnvio[]>(`${this.url_prueba}/getEnvios`);
}

}
