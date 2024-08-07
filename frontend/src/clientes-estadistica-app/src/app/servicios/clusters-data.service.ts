import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClustersDataService {

  private selectedDataSubject = new BehaviorSubject<any[]>([]);
  selectedData$ = this.selectedDataSubject.asObservable();

  constructor() { }

  setSelectedData(data: any[]) {
    this.selectedDataSubject.next(data);
  }
}
