
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

  setLabel(data: any[]) {
    this.selectedLabelSubject.next(data);
  }
  async sendDataToBackend(){
 
  }
  
  
}