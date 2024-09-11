import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

/**
 * Servicio para manejar la activación de scripts gráficos.
 * @service
 */
@Injectable({
  providedIn: 'root',
})
export class GraficasService {
  /**
   * Subject que emite notificaciones para activar scripts gráficos.
   * @private
   */
  private triggerScriptSubject = new Subject<void>();

  /**
   * Observable que emite eventos para activar scripts gráficos.
   * @public
   */
  triggerScript$ = this.triggerScriptSubject.asObservable();

  /**
   * Activa el script gráfico enviando una notificación a todos los suscriptores.
   * @public
   */
  triggerScript() {
    this.triggerScriptSubject.next();
  }
}
