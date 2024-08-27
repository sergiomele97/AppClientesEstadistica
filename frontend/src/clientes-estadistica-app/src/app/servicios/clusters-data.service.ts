
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClustersDataService {
  

  private selectedDataTable = new Subject<any[]>();
  selectedDataTable$ = this.selectedDataTable.asObservable();

  private selectedDataCluster = new Subject<any[]>();
  selectedDataCluster$ = this.selectedDataCluster.asObservable();


  private selectedClusterSubject = new Subject<any>();
  selectedCluster$ = this.selectedClusterSubject.asObservable();

  private selectedLabelSubject = new Subject<any[]>();
  selectedLabel$ = this.selectedLabelSubject.asObservable();
  private selectedIndexDB = new Subject<any[]>();
  selectedDB$ = this.selectedIndexDB.asObservable();

  constructor() { }

  setSelectedDataTable(data: any[]) {
    this.selectedDataTable.next(data);
  }

  setSelectedDataCluster(data: any[]) {
    this.selectedDataCluster.next(data);
  }

  setSelectednCluster(data: any) {
    this.selectedClusterSubject.next(data);
  }

  setLabel(data: any[]) {
    this.selectedLabelSubject.next(data);
  }
  setIndexDB(data: any[]) {
    this.selectedIndexDB.next(data);
  }
  
  async sendDataToBackend(){
 
  }
  
  
}