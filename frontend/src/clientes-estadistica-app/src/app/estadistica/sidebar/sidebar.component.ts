import { Component, OnInit, OnDestroy } from '@angular/core';
import { SignalrService } from 'src/app/servicios/signalr.service';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

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
  ngOnInit() {
    this.setupSignalRListeners();
    this.actualizarOutliers();
  }

  /**
   * Configura los escuchadores de eventos de SignalR.
   * Inicia la conexión y agrega un oyente para actualizar la cantidad de outliers.
   */
  setupSignalRListeners() {
    this.signalrService.startConnection();
    this.signalrService.addOutlierListener(() => {
      this.actualizarOutliers();
    });
  }

  /**
   * Actualiza el número de outliers obteniendo los datos del servicio de transacciones.
   */
  actualizarOutliers() {
    this.transaccionService.obtenerOutlier().subscribe((datos) => {
      this.outliers = datos.length;
    });
  }

  /**
   * Alterna la visibilidad del submenú.
   */
  toggleSubmenu() {
    this.isSubmenuOpen = !this.isSubmenuOpen;
  }

  /**
   * Limpia los recursos utilizados por el componente al destruirlo.
   */
  ngOnDestroy() {
    // Implementar la limpieza de recursos si es necesario
  }
}
