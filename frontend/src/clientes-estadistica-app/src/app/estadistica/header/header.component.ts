import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/clases/usuario';
import { AuthService } from 'src/app/servicios/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  isDropdownOpen: boolean = false; // Estado del menú desplegable
  username: string | null = null; // Nombre de usuario
  usuario: Usuario | undefined;

  constructor(private authService: AuthService, private router: Router) {}

  // Inicializa el usuario
  ngOnInit() {
    this.initializeUser();
  }

  // Suscribirse al observable de usuario
  initializeUser() {
    this.authService.user$.subscribe((user) => {
      this.username = user;
    });
  }

  // Alterna la visibilidad del menú desplegable
  toggleDropdown(event: Event): void {
    event.stopPropagation(); // Previene la propagación del clic
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  // Cierra el menú desplegable si está abierto
  @HostListener('document:click', ['$event'])
  closeDropdown(event: Event): void {
    if (this.isDropdownOpen) {
      this.isDropdownOpen = false;
    }
  }

  // Cierra sesión y navega al login
  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
