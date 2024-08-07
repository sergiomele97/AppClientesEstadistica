import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { IEnvio } from 'src/app/interfaces/envios';
import { EnviosService } from 'src/app/servicios/envios.service';

@Component({
  selector: 'app-outliers-detail-table',
  templateUrl: './outliers-detail-table.component.html',
  styleUrls: ['./outliers-detail-table.component.css']
})
export class OutliersDetailTableComponent implements OnInit {
  
  constructor(private enviosService: EnviosService) {}

  ngOnInit(): void {
    this.subscription = this.enviosService.getEnvios().subscribe({
      next: (envios) => {
        this.envios = this.enviosService.formatEnvios(envios);
      },
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  subscription!: Subscription;
  envios: IEnvio[] = [];
  enviosFilter: IEnvio[] = [];
}
