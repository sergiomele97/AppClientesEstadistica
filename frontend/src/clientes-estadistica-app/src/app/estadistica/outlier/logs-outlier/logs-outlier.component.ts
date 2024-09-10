// src/app/components/logs-outlier/logs-outlier.component.ts

import { Component, OnInit } from '@angular/core';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

/**
 * Componente que muestra los outliers registrados.
 */
@Component({
  selector: 'app-logs-outlier',
  templateUrl: './logs-outlier.component.html',
  styleUrls: ['./logs-outlier.component.css'],
})
export class LogsOutlierComponent implements OnInit {
  outliers: ITransaccion[] = []; // Lista de outliers obtenidos
  vacio: boolean = false; // Indica si no hay outliers
  loading: boolean = true; // Muestra si los datos están cargando

  /**
   * Constructor del componente.
   * @param transaccionService Servicio para manejar las transacciones.
   */
  constructor(private transaccionService: TransaccionService) {}

  /**
   * Inicializa el componente y carga los outliers.
   */
  ngOnInit(): void {
    this.cargarOutliers(); // Llama al método para cargar los outliers
  }

  /**
   * Obtiene la lista de outliers desde el servicio y actualiza el estado del componente.
   */
  cargarOutliers(): void {
    this.transaccionService.outliersVistos().subscribe({
      next: (datos) => {
        this.outliers = datos;
        this.vacio = this.outliers.length === 0; // Verifica si la lista está vacía
        this.loading = false; // Detiene el indicador de carga
      },
      error: (err) => {
        console.error('Error al cargar los outliers:', err);
        // Aquí podrías agregar lógica para mostrar un mensaje de error al usuario
        this.loading = false; // Detiene el indicador de carga incluso en caso de error
      },
    });
  }
}
