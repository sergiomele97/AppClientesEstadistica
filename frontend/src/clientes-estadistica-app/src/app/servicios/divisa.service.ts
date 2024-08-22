// divisa.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDivisa } from '../interfaces/divisa';

@Injectable({
  providedIn: 'root'
})
export class DivisaService {
  private apiUrl = 'http://localhost:5000/divisas';

  constructor(private http: HttpClient) { }

  getDivisasData(): Observable<IDivisa[]> {
    return this.http.get<IDivisa[]>(this.apiUrl);
  }
}