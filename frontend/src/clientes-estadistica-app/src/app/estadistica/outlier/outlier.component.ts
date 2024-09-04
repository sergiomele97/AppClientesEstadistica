import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { SignalrService } from 'src/app/servicios/signalr.service';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

@Component({
  selector: 'app-outlier',
  templateUrl: './outlier.component.html',
  styleUrls: ['./outlier.component.css'],
})
export class OutlierComponent implements OnInit, OnDestroy {
  vacio: boolean = false; // Indica si no hay outliers
  loading: boolean = true; // Muestra si los datos están cargando
  successMessage: string; // Mensaje de éxito
  errorMessage: string; // Mensaje de error

  outliers: ITransaccion[] = []; // Lista de outliers
  private subscription: Subscription = new Subscription(); // Maneja suscripciones

  constructor(
    private transaccionService: TransaccionService,
    private signalrService: SignalrService
  ) {}

  ngOnInit() {
    this.cargarOutliers(); // Cargar outliers al iniciar
    this.setUpSignalRListeners(); // Configurar SignalR
  }

  setUpSignalRListeners() {
    this.signalrService.startConnection(); // Iniciar conexión
    this.signalrService.addOutlierListener(() => {
      this.cargarOutliers(); // Recargar datos cuando se recibe una notificación
    });
  }

  // Obtener y mostrar outliers
  cargarOutliers() {
    this.transaccionService.obtenerOutlier().subscribe((datos) => {
      this.outliers = datos;
      this.vacio = this.outliers.length === 0; // Verificar si la lista está vacía
      this.loading = false; // Detener carga
    });
  }

  // Eliminar un outlier
  borrarOutlier(idTransaccion: number) {
    this.subscription.add(
      this.transaccionService.borrarOutlier(idTransaccion).subscribe({
        next: (response) => {
          this.successMessage = response; // Mensaje de éxito
          this.errorMessage = null; // Limpiar mensaje de error
          this.cargarOutliers(); // Recargar lista de outliers
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

  // Cancelar suscripciones al destruir el componente
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
