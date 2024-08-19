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
  private readonly url_estadistica = environment.apiUsuarios;

  constructor(private http: HttpClient) { }

  // -------------------- Método Sergio para Debuggear en Azure, no borrar:
  getUsuarioById(id: number): Observable<Usuario> {
    const url = `${this.url_estadistica}/${id}`;
    return this.http.get<Usuario>(url);
}

  // -------------------- Fin Método Sergio para Debuggear en Azure, no borrar:
}
