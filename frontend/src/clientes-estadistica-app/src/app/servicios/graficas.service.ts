import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GraficasService {
  private triggerScriptSubject = new Subject<void>();

  triggerScript$ = this.triggerScriptSubject.asObservable();

  triggerScript() {
    this.triggerScriptSubject.next();
  }
}
