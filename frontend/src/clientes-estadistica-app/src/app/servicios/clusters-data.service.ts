import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { throwError } from 'rxjs';
import { catchError, sample, tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class ClustersDataService {
  private apiUrl = 'http://127.0.0.1:5000/cluster';  // URL del servidor Flask

  private selectedDataSubject = new Subject<any[]>();
  selectedData$ = this.selectedDataSubject.asObservable();

  private selectedClusterSubject = new Subject<any>();
  selectedCluster$ = this.selectedClusterSubject.asObservable();

  private selectedLabelSubject = new Subject<any[]>();
  selectedLabel$ = this.selectedLabelSubject.asObservable();

  constructor(private http: HttpClient) { }

  setSelectedData(data: any[]) {
    this.selectedDataSubject.next(data);
  }

  setSelectednCluster(data: any) {
    this.selectedClusterSubject.next(data);
  }

  setSendLabel(data: any[]) {
    this.selectedLabelSubject.next(data);
  }
  async sendDataToBackend(): Promise<any> {
    try {
      // Convert Observables to Promises
      const data = [[0,0],[1,1]];//await this.selectedData$.toPromise();
      const n_clusters = 2;//await this.selectedCluster$.toPromise();
      
      // Send data to backend
      const response = await this.http.post<any>(this.apiUrl, { data, n_clusters }).toPromise();
  
      // Handle response
      console.log('Received data:', response);
      const etiqueta = response.etiqueta || [];
      console.log('etiqueta:', etiqueta);
  
      // Set label in the service
      this.setSendLabel(etiqueta);
  
      return response;
    } catch (error) {
      // Handle errors
      console.error('Error al enviar datos al backend:', error);
      throw new Error('Error al enviar datos al backend');
    }
  }
  
  
}