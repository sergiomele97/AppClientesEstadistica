import { Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { BehaviorSubject, Subject, Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  private readonly apiUrl = environment.apiEstadisticas;
  private readonly apiNot = environment.apiNotification;

  private hubConnection: signalR.HubConnection;
  private isConnected = false; // Flag to track connection status

  private outliersSubject = new BehaviorSubject<number>(0);
  private alertSubject = new Subject<boolean>();

  outliers$ = this.outliersSubject.asObservable();
  alert$ = this.alertSubject.asObservable();

  constructor(private http: HttpClient) {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(this.apiNot)
      .build();

    this.setupListeners();
  }

  public startConnection(): void {
    if (this.isConnected) {
      console.log('SignalR connection is already established.');
      return;
    }

    this.hubConnection
      .start()
      .then(() => {
        this.isConnected = true;
        console.log('SignalR Connected');
      })
      .catch((err) => {
        console.error('Error al conectar con SignalR:', err);
        // Optionally, retry connection after a delay
        setTimeout(() => this.startConnection(), 5000);
      });
  }

  private setupListeners(): void {
    this.hubConnection.on('OutlierDetected', (data: any) => {
      console.log('OutlierDetected received:', data); // Debugging
      this.updateOutliersCount(); // Update the outliers count on notification
      this.alertSubject.next(true); // Trigger alert
      setTimeout(() => {
        console.log('Hiding alert');
        this.alertSubject.next(false); // Hide alert after 5 seconds
      }, 5000);
    });

    // Listen for other events like "OutlierRemoved"
    this.hubConnection.on('OutlierRemoved', () => {
      console.log('OutlierRemoved received');
      this.updateOutliersCount();
      this.alertSubject.next(true);
      setTimeout(() => {
        this.alertSubject.next(false);
      }, 5000);
    });
  }

  public updateOutliersCount(): void {
    this.getOutliers().subscribe((outliers) => {
      console.log('Updating outliers count:', outliers.length); // Debugging: Muestra el conteo de outliers
      this.outliersSubject.next(outliers.length);
    });
  }

  public getOutliers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/getOutliers`); // Ajusta la URL según tu API
  }
}
