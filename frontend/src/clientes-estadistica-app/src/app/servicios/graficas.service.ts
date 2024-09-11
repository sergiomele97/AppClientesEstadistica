import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

/**
 * Servicio para manejar la activación de scripts gráficos en la aplicación.
 * @service
 */
@Injectable({
  providedIn: 'root',
})
export class GraficasService {
  /**
   * Subject que emite notificaciones para activar scripts gráficos.
   * Utiliza este Subject para enviar eventos que dispararán la ejecución de scripts gráficos.
   * @private
   */
  private triggerScriptSubject = new Subject<void>();

  /**
   * Observable que emite eventos para activar scripts gráficos.
   * Suscríbete a este Observable para recibir notificaciones cuando se necesite activar un script gráfico.
   * @public
   */
  triggerScript$ = this.triggerScriptSubject.asObservable();

  /**
   * Activa el script gráfico enviando una notificación a todos los suscriptores.
   * Utiliza este método cuando necesites que los scripts gráficos se activen en respuesta a algún evento.
   * @public
   */
  triggerScript() {
    this.triggerScriptSubject.next();
  }
}
