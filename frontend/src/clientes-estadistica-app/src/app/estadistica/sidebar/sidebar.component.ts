import { Component, OnInit, OnDestroy } from '@angular/core';
import { SignalrService } from 'src/app/servicios/signalr.service';
import { TransaccionService } from 'src/app/servicios/transaccion.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
})
export class SidebarComponent implements OnInit, OnDestroy {
  isSubmenuOpen = false;
  outliers: number = 0;

  constructor(
    private signalrService: SignalrService,
    private transaccionService: TransaccionService
  ) {}

  ngOnInit() {
    this.setupSignalRListeners();
    this.actualizarOutliers();
  }

  setupSignalRListeners() {
    this.signalrService.startConnection();
    this.signalrService.addOutlierListener(() => {
      this.actualizarOutliers();
    });
  }

  actualizarOutliers() {
    this.transaccionService.obtenerOutlier().subscribe((datos) => {
      this.outliers = datos.length;
    });
  }

  toggleSubmenu() {
    this.isSubmenuOpen = !this.isSubmenuOpen;
  }

  ngOnDestroy() {}
}
