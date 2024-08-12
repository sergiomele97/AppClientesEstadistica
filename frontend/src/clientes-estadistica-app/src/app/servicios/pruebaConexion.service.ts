import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { Usuario } from '../clases/usuario';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PruebaConexionService {

    // IMPORTANTE:
  //    1 URL ESTADISTICA Y OTRA PARA CLIENTES
  private readonly url_estadistica = environment.apiUrl;

  constructor(private http: HttpClient) { }

  // -------------------- Método Sergio para Debuggear en Azure, no borrar:
  getUsuariosPrueba(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.url_estadistica);
  }
  // -------------------- Fin Método Sergio para Debuggear en Azure, no borrar:
}
