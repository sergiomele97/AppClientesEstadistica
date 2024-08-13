import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { IConversion } from '../interfaces/conversion';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})

export class ConversionService {

  constructor(private http: HttpClient) {}

  private readonly url_estadistica = environment.apiUrl;

  getConversiones(): Observable<IConversion[]> {
    return this.http.get<IConversion[]>(
      `${this.url_estadistica}/getTransacciones`
    );
  }
}
