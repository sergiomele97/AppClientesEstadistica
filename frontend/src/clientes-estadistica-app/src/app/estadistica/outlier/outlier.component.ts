import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { SignalrService } from 'src/app/servicios/signalr.service';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

/**
 * Componente que maneja la visualización y eliminación de outliers.
 * También escucha notificaciones en tiempo real mediante SignalR.
 */
@Component({
  selector: 'app-outlier',
  templateUrl: './outlier.component.html',
  styleUrls: ['./outlier.component.css'],
})
export class OutlierComponent implements OnInit, OnDestroy {
  vacio: boolean = false; // Indica si no hay outliers
  loading: boolean = true; // Muestra si los datos están cargando
  successMessage: string | null = null; // Mensaje de éxito
  errorMessage: string | null = null; // Mensaje de error

  outliers: ITransaccion[] = []; // Lista de outliers
  private subscription: Subscription = new Subscription(); // Maneja suscripciones

  /**
   * Constructor del componente.
   * @param transaccionService Servicio para manejar transacciones.
   * @param signalrService Servicio para manejar SignalR.
   */
  constructor(
    private transaccionService: TransaccionService,
    private signalrService: SignalrService
  ) {}

  /**
   * Inicializa el componente, carga los outliers y configura los listeners de SignalR.
   */
  ngOnInit() {
    this.loadOutliers(); // Cargar outliers al iniciar
    this.setupSignalRListeners(); // Configurar SignalR
  }

  /**
   * Configura los listeners de SignalR para recibir notificaciones en tiempo real.
   */
  private setupSignalRListeners() {
    this.signalrService.startConnection(); // Iniciar conexión
    this.signalrService.addOutlierListener(() => {
      this.loadOutliers(); // Recargar datos cuando se recibe una notificación
    });
  }

  /**
   * Obtiene la lista de outliers desde el servicio y actualiza el estado del componente.
   */
  private loadOutliers() {
    this.loading = true; // Iniciar carga de datos
    this.transaccionService.obtenerOutlier().subscribe({
      next: (datos) => {
        this.outliers = datos;
        this.vacio = this.outliers.length === 0; // Verificar si la lista está vacía
        this.successMessage = null; // Limpiar mensaje de éxito
        this.errorMessage = null; // Limpiar mensaje de error
        this.loading = false; // Detener carga
      },
      error: (err) => {
        this.errorMessage =
          'Error al cargar los outliers. Por favor, intente de nuevo.'; // Mensaje de error
        this.successMessage = null; // Limpiar mensaje de éxito
        console.error('Error: ', err); // Registrar error
        this.loading = false; // Detener carga
      },
    });
  }

  /**
   * Elimina un outlier por su ID y actualiza la lista de outliers.
   * @param idTransaccion ID del outlier a eliminar.
   */
  borrarOutlier(idTransaccion: number) {
    this.subscription.add(
      this.transaccionService.borrarOutlier(idTransaccion).subscribe({
        next: (response) => {
          this.successMessage = response; // Mensaje de éxito
          this.errorMessage = null; // Limpiar mensaje de error
          this.loadOutliers(); // Recargar lista de outliers
        },
        error: (err) => {
          this.errorMessage =
            'Error al resolver el outlier. Por favor, intente de nuevo.'; // Mensaje de error
          this.successMessage = null; // Limpiar mensaje de éxito
          console.error('Error: ', err); // Registrar error
        },
      })
    );
  }

  /**
   * Limpia las suscripciones al destruir el componente.
   */
  ngOnDestroy() {
    this.subscription.unsubscribe(); // Cancelar todas las suscripciones
  }
}
