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
  vacio: boolean = false;
  loading: boolean = true;
  successMessage: string;
  errorMessage: string;

  outliers: ITransaccion[] = [];
  private subscription: Subscription = new Subscription();

  constructor(
    private transaccionService: TransaccionService,
    private signalrService: SignalrService
  ) {}

  ngOnInit() {
    this.cargarOutliers();
    this.setUpSignalRListeners();
  }

  setUpSignalRListeners() {
    this.signalrService.startConnection();
    this.signalrService.addOutlierListener(() => {
      this.cargarOutliers();
    });
  }

  cargarOutliers() {
    this.transaccionService.obtenerOutlier().subscribe((datos) => {
      this.outliers = datos;
      this.vacio = this.outliers.length === 0;
      this.loading = false;
    });
  }

  borrarOutlier(idTransaccion: number) {
    this.subscription.add(
      this.transaccionService.borrarOutlier(idTransaccion).subscribe({
        next: (response) => {
          this.successMessage = response;
          this.errorMessage = null;
          this.cargarOutliers();
        },
        error: (err) => {
          this.errorMessage =
            'Error al resolver el outlier. Por favor, intentelo de nuevo.';
          this.successMessage = null;
          console.error('Error: ', err);
        },
      })
    );
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
