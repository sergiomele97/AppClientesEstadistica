import { Component, OnInit } from '@angular/core';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

@Component({
  selector: 'app-outlier',
  templateUrl: './outlier.component.html',
  styleUrls: ['./outlier.component.css']
})
export class OutlierComponent implements OnInit {

  outliers: ITransaccion[] = [];
  vacio: boolean = false;
  loading: boolean = true;

  constructor(private transaccionService: TransaccionService) { }

  ngOnInit() {
    this.transaccionService.obtenerOutlier().subscribe(datos => {
      this.outliers = datos;
      this.vacio = this.outliers.length === 0;
      this.loading = false;
    });
  }

}
