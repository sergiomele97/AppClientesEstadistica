
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClustersDataService {
  

  private selectedDataSubject = new Subject<any[]>();
  selectedData$ = this.selectedDataSubject.asObservable();

  private selectedClusterSubject = new Subject<any>();
  selectedCluster$ = this.selectedClusterSubject.asObservable();

  private selectedLabelSubject = new Subject<any[]>();
  selectedLabel$ = this.selectedLabelSubject.asObservable();

  constructor() { }

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