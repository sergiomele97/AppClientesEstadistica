import { Component, OnInit, OnDestroy } from '@angular/core';
import { SignalrService } from 'src/app/servicios/signalr.service';
import { TransaccionService } from 'src/app/servicios/transaccion.service';
import { Subscription } from 'rxjs';

/**
 * Componente para la barra lateral de la aplicación.
 * Muestra el número de outliers y controla la visibilidad del submenú.
 */
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
})
export class SidebarComponent implements OnInit, OnDestroy {
  isSubmenuOpen = false; // Estado del submenú
  outliers: number = 0; // Número de outliers
  private subscription: Subscription = new Subscription(); // Manejo de suscripciones

  /**
   * Crea una instancia del componente `SidebarComponent`.
   * @param signalrService - Servicio para la comunicación en tiempo real con SignalR
   * @param transaccionService - Servicio para operaciones con transacciones
   */
  constructor(
    private signalrService: SignalrService,
    private transaccionService: TransaccionService
  ) {}

  /**
   * Inicializa el componente configurando SignalR y actualizando la cantidad de outliers.
   */
  ngOnInit(): void {
    this.setupSignalRListeners();
    this.actualizarOutliers();
  }

  /**
   * Configura los escuchadores de eventos de SignalR.
   * Inicia la conexión y agrega un oyente para actualizar la cantidad de outliers.
   */
  setupSignalRListeners(): void {
    this.signalrService.startConnection();
    this.signalrService.addOutlierListener(() => {
      this.actualizarOutliers();
    });
  }

  /**
   * Actualiza el número de outliers obteniendo los datos del servicio de transacciones.
   */
  actualizarOutliers(): void {
    this.subscription.add(
      this.transaccionService.obtenerOutlier().subscribe({
        next: (datos) => {
          this.outliers = datos.length;
        },
        error: (err) => {
          console.error('Error al obtener outliers:', err);
          // Aquí podrías agregar lógica para manejar errores
        },
      })
    );
  }

  /**
   * Alterna la visibilidad del submenú.
   */
  toggleSubmenu(): void {
    this.isSubmenuOpen = !this.isSubmenuOpen;
  }

  /**
   * Limpia los recursos utilizados por el componente al destruirlo.
   */
  ngOnDestroy(): void {
    this.subscription.unsubscribe(); // Limpia las suscripciones
    // Aquí podrías agregar lógica para detener la conexión de SignalR si es necesario
  }
}
