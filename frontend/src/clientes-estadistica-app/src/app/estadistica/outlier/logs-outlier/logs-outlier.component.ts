import { Component, OnInit } from '@angular/core';
import { ITransaccion } from 'src/app/interfaces/transaccion';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

@Component({
  selector: 'app-logs-outlier',
  templateUrl: './logs-outlier.component.html',
  styleUrls: ['./logs-outlier.component.css']
})
export class LogsOutlierComponent implements OnInit{

  outliers: ITransaccion[];

  constructor(private transaccionService: TransaccionService) {}
  

  ngOnInit(): void {

    this.transaccionService.outliersVistos().subscribe( datos => {
      this.outliers = datos;
    })

  }


}
