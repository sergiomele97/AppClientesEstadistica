import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

@Component({
  selector: 'app-outlier',
  templateUrl: './outlier.component.html',
  styleUrls: ['./outlier.component.css'],
})
export class OutlierComponent implements OnInit, OnDestroy {
  vacio: boolean = false;
  loading: boolean = true;
  successMessage: string;
  errorMessage: string;

  outliers: ITransaccion[] = [];
  subscription: Subscription = new Subscription();

  constructor(private transaccionService: TransaccionService) {}

  ngOnInit() {
    this.cargarOutliers();
  }

  cargarOutliers() {
    this.subscription.add(
      this.transaccionService.obtenerOutlier().subscribe({
        next: (outlier) => {
          this.outliers = outlier;
          this.vacio = this.outliers.length === 0;
          this.loading = false;
        },
        error: (err) => {
          console.error('Error al cargar outliers:', err);
          this.loading = false;
        },
      })
    );
  }

  borrarOutlier(idTransaccion: number) {
    this.subscription.add(
      this.transaccionService.borrarOutlier(idTransaccion).subscribe({
        next: (response) => {
          this.successMessage = response;
          this.errorMessage = null;
          this.cargarOutliers();
          this.hideMessagesAfterDelay();
        },
        error: (err) => {
          this.errorMessage =
            'Error al resolver el outlier. Por favor, intentelo de nuevo.';
          this.successMessage = null;
          this.hideMessagesAfterDelay();
          console.error('Error: ', err);
        },
      })
    );
  }

  hideMessagesAfterDelay() {
    setTimeout(() => {
      this.successMessage = null;
      this.errorMessage = null;
    }, 3000);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
