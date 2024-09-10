import { Component, OnInit } from '@angular/core';
import { SignalrService } from 'src/app/servicios/signalr.service';

/**
 * Componente para mostrar alertas basadas en eventos de SignalR.
 * @component
 */
@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css'],
})
export class AlertComponent implements OnInit {
  /**
   * Indica si se ha detectado un evento.
   * @type {boolean}
   */
  detectado: boolean = false;

  /**
   * Indica si se ha eliminado un evento.
   * @type {boolean}
   */
  eliminado: boolean = false;

  /**
   * Crea una instancia del AlertComponent.
   * @param {SignalrService} signalrService - Servicio para la conexión SignalR.
   */
  constructor(private signalrService: SignalrService) {}

  /**
   * Inicializa el componente y configura los listeners de SignalR.
   * @method
   */
  ngOnInit() {
    this.setupSignalRListeners();
  }

  /**
   * Configura los listeners de SignalR para manejar alertas.
   * Inicia la conexión SignalR y añade un listener para eventos de alerta.
   * @method
   */
  setupSignalRListeners() {
    this.signalrService.startConnection(); // Inicia la conexión SignalR
    this.signalrService.addOutlierListener((data: any) => {
      // Actualiza estado y muestra alerta según el tipo de dato
      this.detectado = data.type === 'detected';
      this.eliminado = data.type === 'removed';
      this.showAlert();
      this.hideMessagesAfterDelay();
    });
  }

  /**
   * Muestra el contenedor de alerta.
   * Añade la clase 'show' y elimina la clase 'hide' del contenedor de alerta.
   * @method
   */
  showAlert() {
    const alertElement = document.querySelector(
      '.alert-container'
    ) as HTMLElement;
    if (alertElement) {
      alertElement.classList.add('show');
      alertElement.classList.remove('hide');
    }
  }

  /**
   * Oculta el contenedor de alerta después de un retraso.
   * Añade la clase 'hide' y elimina la clase 'show' después de un retraso.
   * Reinicia los estados de detección y eliminación después de otro retraso.
   * @method
   */
  hideMessagesAfterDelay() {
    setTimeout(() => {
      const alertElement = document.querySelector(
        '.alert-container'
      ) as HTMLElement;
      if (alertElement) {
        alertElement.classList.add('hide');
        alertElement.classList.remove('show');
      }
    }, 4200); // Tiempo de retraso

    // Reinicia los estados después de ocultar
    setTimeout(() => {
      this.detectado = false;
      this.eliminado = false;
    }, 5000);
  }
}
