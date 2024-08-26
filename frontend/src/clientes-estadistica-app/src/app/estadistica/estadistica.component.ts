import { Component, OnInit } from '@angular/core';
import { Usuario } from '../clases/usuario';
import { PruebaConexionService } from '../servicios/pruebaConexion.service';
import { TransaccionService } from '../servicios/transaccion.service';
import { interval } from 'rxjs';

// Decorador 
@Component({
  selector: 'app-estadistica',
  templateUrl: './estadistica.component.html',
  styleUrls: ['./estadistica.component.css']
})

export class EstadisticaComponent implements OnInit {
  usuarios: Usuario[];

  outliers: number;

  // Método para dropdown
  isDropdownOpen = false;

  menuOpen: boolean = false;

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  constructor(private pruebaConexionService: PruebaConexionService, private transaccionService: TransaccionService) { }
  

  // -------------------- Método Sergio para Debuggear en Azure, no borrar:
  usuario: Usuario | undefined;

   ngOnInit(): void {
    const userId = 1; // Cambia esto al ID que deseas buscar

    this.pruebaConexionService.getUsuarioById(userId).subscribe(
      (data: Usuario) => {
        this.usuario = data;
        console.log('Usuario obtenido:', this.usuario);
      },
      error => {
        console.error('Error al obtener el usuario', error);
      }
    );

    this.actualizarOutliers();

    interval(30000).subscribe(() => {
      this.actualizarOutliers()
    });

  }
  // -------------------- Fin Método Sergio para Debuggear en Azure, no borrar:
  
    actualizarOutliers() {
      this.transaccionService.obtenerOutlier().subscribe( datos => {
        this.outliers = datos.length;
      });
    }

  
}


  