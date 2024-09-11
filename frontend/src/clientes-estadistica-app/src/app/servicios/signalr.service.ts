import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { environment } from 'src/environments/environment';

/**
 * Servicio para manejar la conexión y la comunicación con un servidor SignalR.
 * @service
 */
@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  /**
   * Instancia de la conexión Hub de SignalR.
   * @private
   */
  private hubConnection: signalR.HubConnection;

  /**
   * Crea una instancia del servicio para manejar la conexión SignalR.
   * Configura la conexión con la URL proporcionada en el archivo de entorno.
   */
  constructor() {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(environment.apiNotification)
      .build();
  }

  /**
   * Inicia la conexión con el servidor SignalR.
   * Muestra un mensaje en la consola si la conexión es exitosa o un error si falla.
   */
  public startConnection(): void {
    this.hubConnection
      .start()
      .then(() => console.log('SignalR Connected'))
      .catch((err) => console.error('Error al conectar con SignalR:', err));
  }

  /**
   * Añade un oyente para eventos relacionados con outliers.
   * Registra dos tipos de eventos: 'OutlierDetected' y 'OutlierRemoved'.
   * Llama al callback proporcionado con un objeto que contiene el tipo de evento y los datos asociados.
   * @param callback - Función que se ejecuta cuando se detecta un evento de outlier.
   */
  public addOutlierListener(
    callback: (event: { type: string; data: any }) => void
  ): void {
    this.hubConnection.on('OutlierDetected', (data) => {
      callback({ type: 'detected', data });
    });
    this.hubConnection.on('OutlierRemoved', (data) => {
      callback({ type: 'removed', data });
    });
  }
}
