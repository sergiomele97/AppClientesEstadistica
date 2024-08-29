import { Component, OnInit } from '@angular/core';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { SignalrService } from 'src/app/servicios/signalr.service';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

@Component({
  selector: 'app-outlier',
  templateUrl: './outlier.component.html',
  styleUrls: ['./outlier.component.css'],
})
export class OutlierComponent implements OnInit {
  outliers: ITransaccion[] = [];
  vacio: boolean = false;
  loading: boolean = true;
  successMessage: string;
  errorMessage: string;


  constructor(private transaccionService: TransaccionService, private signalrService: SignalrService) { }

  ngOnInit() {
    this.cargarOutliers();
    this.setUpSignalRListeners();

  }

  setUpSignalRListeners(){
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
    });
  }

  hideMessagesAfterDelay() {
    setTimeout(() => {
      this.successMessage = null;
      this.errorMessage = null;
    }, 3000);
  }
}
