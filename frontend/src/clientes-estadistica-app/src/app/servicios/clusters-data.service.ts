import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';

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

  sendDataToBackend(sampleData: any[], nCluster: number): Observable<any> {
    const payload = { sampleData, nCluster };
    console.log("log: ",this.http.post<any>(this.apiUrl, payload));
    
    return this.http.post<any>(this.apiUrl, payload);
  }
}
