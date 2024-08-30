import { Component, HostListener, OnInit } from '@angular/core';
import { Usuario } from '../clases/usuario';
import { PruebaConexionService } from '../servicios/pruebaConexion.service';
import { TransaccionService } from '../servicios/transaccion.service';
import { AuthService } from '../servicios/auth.service';
import { Router } from '@angular/router';
import { SignalrService } from '../servicios/signalr.service';

@Component({
  selector: 'app-estadistica',
  templateUrl: './estadistica.component.html',
  styleUrls: ['./estadistica.component.css'],
})
export class EstadisticaComponent implements OnInit {
  outliers: number = 0;
  isDropdownOpen: boolean = false;
  username: string | null = null;
  usuario: Usuario | undefined;

  constructor(
    private pruebaConexionService: PruebaConexionService,
  ) {}

  ngOnInit(): void {
    this.initializeUser();
  }

  initializeUser() {
    const userId = 1; // Cambia esto al ID que deseas buscar

    this.pruebaConexionService.getUsuarioById(userId).subscribe(
      (data: Usuario) => {
        this.usuario = data;
      },
      (error) => {
        console.error('Error al obtener el usuario', error);
      }
    );
  }
}
