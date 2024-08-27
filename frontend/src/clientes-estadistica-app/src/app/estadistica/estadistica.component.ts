import { Component, OnInit } from '@angular/core';
import { Usuario } from '../clases/usuario';
import { PruebaConexionService } from '../servicios/pruebaConexion.service';
import { TransaccionService } from '../servicios/transaccion.service';
import { interval } from 'rxjs';
import { AuthService } from '../servicios/auth.service';
import { Router } from '@angular/router';

// Decorador
@Component({
  selector: 'app-estadistica',
  templateUrl: './estadistica.component.html',
  styleUrls: ['./estadistica.component.css'],
})
export class EstadisticaComponent implements OnInit {
  outliers: number = 0;
  isDropdownOpen: boolean = false;
  username: string | null = null;

  constructor(
    private pruebaConexionService: PruebaConexionService,
    private transaccionService: TransaccionService,
    private authService: AuthService,
    private router: Router
  ) {}

  // Método para abrir/cerrar el menú desplegable
  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  // Método para cerrar sesión
  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  // -------------------- Método Sergio para Debuggear en Azure, no borrar:
  usuario: Usuario | undefined;

  ngOnInit(): void {
    const userId = 1; // Cambia esto al ID que deseas buscar

    this.pruebaConexionService.getUsuarioById(userId).subscribe(
      (data: Usuario) => {
        this.usuario = data;
        console.log('Usuario obtenido:', this.usuario);
      },
      (error) => {
        console.error('Error al obtener el usuario', error);
      }
    );

    // -------------------- Fin Método Sergio para Debuggear en Azure, no borrar:

    this.actualizarOutliers();

    interval(30000).subscribe(() => {
      this.actualizarOutliers();
    });

    this.authService.user$.subscribe((user) => {
      this.username = user;
    });
  }

  actualizarOutliers() {
    this.transaccionService.obtenerOutlier().subscribe((datos) => {
      this.outliers = datos.length;
    });
  }
}
