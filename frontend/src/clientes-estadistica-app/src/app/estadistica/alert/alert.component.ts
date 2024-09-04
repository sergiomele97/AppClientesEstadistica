import { Component, OnInit } from '@angular/core';
import { SignalrService } from 'src/app/servicios/signalr.service';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css'],
})
export class AlertComponent implements OnInit {
  detectado: boolean = false; // Estado de detección
  eliminado: boolean = false; // Estado de eliminación

  constructor(private signalrService: SignalrService) {}

  ngOnInit() {
    this.setupSignalRListeners();
  }

  // Configura los listeners de SignalR para manejar alertas
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

  // Muestra el contenedor de alerta
  showAlert() {
    const alertElement = document.querySelector(
      '.alert-container'
    ) as HTMLElement;
    if (alertElement) {
      alertElement.classList.add('show');
      alertElement.classList.remove('hide');
    }
  }

  // Oculta el contenedor de alerta después de un retraso
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
