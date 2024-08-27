// divisa.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDivisa } from '../interfaces/divisa';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DivisaService {

  constructor(private http: HttpClient) {}

  private readonly url_estadistica = environment.apiEstadisticas;

  getDivisasData(nombre: string): Observable<IDivisa[]> {
    return this.http.get<IDivisa[]>(`${this.url_estadistica}/getdivisas/${nombre}`);
  }


}
