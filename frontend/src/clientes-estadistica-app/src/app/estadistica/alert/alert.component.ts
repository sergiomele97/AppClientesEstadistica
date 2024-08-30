import { Component, OnInit } from '@angular/core';
import { SignalrService } from 'src/app/servicios/signalr.service';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.css'],
})
export class AlertComponent implements OnInit {
  detectado: boolean = false;

  constructor(private signalrService: SignalrService) {}

  ngOnInit() {
    this.signalrService.alert$.subscribe(show => {
      this.detectado = show;
    });
  }
}
