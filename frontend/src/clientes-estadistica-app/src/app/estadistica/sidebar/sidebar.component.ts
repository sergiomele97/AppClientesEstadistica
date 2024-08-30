import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { SignalrService } from 'src/app/servicios/signalr.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
})
export class SidebarComponent implements OnInit, OnDestroy {
  isSubmenuOpen = false;
  outliers: number = 0;
  private subscription: Subscription = new Subscription();

  constructor(private signalrService: SignalrService) {}

  ngOnInit() {
    console.log('SidebarComponent initialized');

    // Initial outliers count
    this.subscription.add(
      this.signalrService.getOutliers().subscribe((outliers) => {
        console.log('Initial outliers count:', outliers.length);
        this.outliers = outliers.length;
      })
    );

    // Subscribe to updates
    this.subscription.add(
      this.signalrService.outliers$.subscribe((count) => {
        console.log('Outliers count updated:', count);
        this.outliers = count;
      })
    );
  }

  toggleSubmenu() {
    this.isSubmenuOpen = !this.isSubmenuOpen;
  }

  ngOnDestroy() {
    console.log('SidebarComponent destroyed');
    this.subscription.unsubscribe(); // Limpiar suscripciones al destruir el componente
  }
}
