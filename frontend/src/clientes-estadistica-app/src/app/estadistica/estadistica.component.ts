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
  detectado: boolean = false;

  constructor(
    private pruebaConexionService: PruebaConexionService,
    private transaccionService: TransaccionService,
    private authService: AuthService,
    private router: Router,
    private signalrService: SignalrService
  ) {}

  ngOnInit(): void {
    this.initializeUser();
    this.setupSignalRListeners();
    this.actualizarOutliers();
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

    this.authService.user$.subscribe((user) => {
      this.username = user;
    });
  }

  setupSignalRListeners() {
    this.signalrService.startConnection();
    this.signalrService.addOutlierListener(() => {
      this.detectado = true;
      this.actualizarOutliers(); 
      this.hideMessagesAfterDelay();
    });
  }

  actualizarOutliers() {
    this.transaccionService.obtenerOutlier().subscribe((datos) => {
      this.outliers = datos.length; 
    });
  }

  hideMessagesAfterDelay() {
    setTimeout(() => {
      this.detectado = null;
    }, 5000); 
  }

  toggleDropdown(event: Event): void {
    event.stopPropagation(); 
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  @HostListener('document:click', ['$event'])
  closeDropdown(event: Event): void {
    if (this.isDropdownOpen) {
      this.isDropdownOpen = false;
    }
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
