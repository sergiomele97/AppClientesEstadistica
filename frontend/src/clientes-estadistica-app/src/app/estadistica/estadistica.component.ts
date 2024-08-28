import { Component, HostListener, OnInit } from '@angular/core';
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

  // Alternar la apertura del dropdown
  toggleDropdown(event: Event): void {
    event.stopPropagation(); // Evitar que el click se propague al document
    this.isDropdownOpen = !this.isDropdownOpen;
  }

    // Detectar clics fuera del dropdown y cerrarlo si está abierto
    @HostListener('document:click', ['$event'])
    closeDropdown(event: Event): void {
      if (this.isDropdownOpen) {
        this.isDropdownOpen = false;
      }
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
        //console.log('Usuario obtenido:', this.usuario);
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
