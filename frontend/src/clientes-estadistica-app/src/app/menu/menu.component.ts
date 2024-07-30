import { Component, OnInit } from '@angular/core';
import { MiServicioService } from '../mi-servicio.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  datos: any;

  constructor(private miServicio: MiServicioService) { }

  ngOnInit(): void {
    this.miServicio.getUsuarios().subscribe(
      data => {
        this.datos = data;
        console.log(this.datos);
      },
      error => {
        console.error('Error al obtener datos', error);
      }
    );
  }


}
