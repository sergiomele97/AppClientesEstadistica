import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from '../clases/usuario';

@Injectable()
export class UserService {

    private url = 'https://localhost:7144/api/usuarios';

constructor(private http: HttpClient) { }

getUsuarios(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.url);
}

autenticarUsuario(email: string, password: string): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(`${this.url}?email=${email}&password=${password}`);
}

}
