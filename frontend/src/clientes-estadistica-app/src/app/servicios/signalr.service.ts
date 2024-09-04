import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  private hubConnection: signalR.HubConnection;

  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(environment.apiNotification)
      .build();
  }

  public startConnection(): void {
    this.hubConnection
      .start()
      .then(() => console.log('SignalR Connected'))
      .catch((err) => console.error('Error al conectar con SignalR:', err));
  }

  public addOutlierListener(callback: (data: any) => void): void {
    this.hubConnection.on('OutlierDetected', (data) => {
      callback({ type: 'detected', data });
    });
    this.hubConnection.on('OutlierRemoved', (data) => {
      callback({ type: 'removed', data });
    });
  }
}
