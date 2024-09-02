import { Component, OnInit } from '@angular/core';
import { SignalrService } from 'src/app/servicios/signalr.service';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css'],
})
export class AlertComponent implements OnInit {
  detectado: boolean = false;
  eliminado: boolean = false;

  constructor(private signalrService: SignalrService) {}

  ngOnInit() {
    this.setupSignalRListeners();
  }

  setupSignalRListeners() {
    this.signalrService.startConnection();
    this.signalrService.addOutlierListener((data: any) => {
      if (data.type === 'detected') {
        this.detectado = true;
        this.showAlert();
        this.hideMessagesAfterDelay();
      } else if (data.type === 'removed') {
        this.eliminado = true;
        this.showAlert();
        this.hideMessagesAfterDelay();
      }
    });
  }

  showAlert() {
    const alertElement = document.querySelector(
      '.alert-container'
    ) as HTMLElement;
    if (alertElement) {
      alertElement.classList.add('show');
      alertElement.classList.remove('hide'); // Optional: Ensure 'hide' class is removed
    }
  }

  hideMessagesAfterDelay() {
    setTimeout(() => {
      const alertElement = document.querySelector(
        '.alert-container'
      ) as HTMLElement;
      if (alertElement) {
        alertElement.classList.add('hide'); // Apply hide animation
        alertElement.classList.remove('show'); // Ensure 'show' class is removed
      }
    }, 4200);
    setTimeout(() => {
      // Reset both flags after the alert has been hidden
      this.detectado = false;
      this.eliminado = false;
    }, 5000);
  }
}
