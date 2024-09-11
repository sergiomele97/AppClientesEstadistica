import { Component, OnInit, OnDestroy, Renderer2 } from '@angular/core';
import { SignalrService } from 'src/app/servicios/signalr.service';

/**
 * Componente para mostrar alertas basadas en eventos de SignalR.
 */
@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css'],
})
export class AlertComponent implements OnInit, OnDestroy {
  detectado: boolean = false; // Indica si se ha detectado un evento.
  eliminado: boolean = false; // Indica si se ha eliminado un evento.
  private alertTimeoutId: any; // ID del temporizador para ocultar alertas

  /**
   * Crea una instancia del AlertComponent.
   * @param signalrService Servicio para la conexión SignalR.
   * @param renderer Renderer para manipulación del DOM.
   */
  constructor(
    private signalrService: SignalrService,
    private renderer: Renderer2
  ) {}

  /**
   * Inicializa el componente y configura los listeners de SignalR.
   */
  ngOnInit() {
    this.setupSignalRListeners();
  }

  /**
   * Configura los listeners de SignalR para manejar alertas.
   * Inicia la conexión SignalR y añade un listener para eventos de alerta.
   */
  setupSignalRListeners() {
    this.signalrService.startConnection(); // Inicia la conexión SignalR
    this.signalrService.addOutlierListener((data: { type: string }) => {
      this.detectado = data.type === 'detected';
      this.eliminado = data.type === 'removed';
      this.showAlert();
      this.hideMessagesAfterDelay();
    });
  }

  /**
   * Muestra el contenedor de alerta.
   * Añade la clase 'show' y elimina la clase 'hide' del contenedor de alerta.
   */
  showAlert() {
    const alertElement = document.querySelector(
      '.alert-container'
    ) as HTMLElement;
    if (alertElement) {
      this.renderer.addClass(alertElement, 'show');
      this.renderer.removeClass(alertElement, 'hide');
    }
  }

  /**
   * Oculta el contenedor de alerta después de un retraso.
   * Añade la clase 'hide' y elimina la clase 'show' después de un retraso.
   * Reinicia los estados de detección y eliminación después de otro retraso.
   */
  hideMessagesAfterDelay() {
    if (this.alertTimeoutId) {
      clearTimeout(this.alertTimeoutId);
    }

    this.alertTimeoutId = setTimeout(() => {
      const alertElement = document.querySelector(
        '.alert-container'
      ) as HTMLElement;
      if (alertElement) {
        this.renderer.addClass(alertElement, 'hide');
        this.renderer.removeClass(alertElement, 'show');
      }
      this.resetStates();
    }, 4200); // Tiempo de retraso para ocultar la alerta
  }

  /**
   * Reinicia los estados de detección y eliminación después de ocultar la alerta.
   */
  resetStates() {
    setTimeout(() => {
      this.detectado = false;
      this.eliminado = false;
    }, 5000); // Tiempo adicional para reiniciar los estados
  }

  /**
   * Limpia los recursos utilizados por el componente al destruirlo.
   */
  ngOnDestroy() {
    if (this.alertTimeoutId) {
      clearTimeout(this.alertTimeoutId);
    }
  }
}
