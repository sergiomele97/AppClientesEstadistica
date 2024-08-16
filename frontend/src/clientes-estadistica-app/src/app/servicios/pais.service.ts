import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { IPais } from '../interfaces/pais';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PaisService {

constructor(private http: HttpClient) {}

private readonly url_estadistica = environment.apiUrl;

getPaises(): Observable<IPais[]> {
  return this.http.get<IPais[]>(
    `${this.url_estadistica}/getPaises`
  );
}
}
