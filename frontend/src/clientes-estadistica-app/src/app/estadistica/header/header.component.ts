import { Component, HostListener, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/clases/usuario';
import { AuthService } from 'src/app/servicios/auth.service';

/**
 * Componente de cabecera para la aplicación.
 * Maneja la visualización del menú desplegable y el estado de autenticación del usuario.
 */
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  isDropdownOpen: boolean = false; // Estado del menú desplegable
  username: string | null = null; // Nombre de usuario actual
  usuario?: Usuario; // Información del usuario, si está disponible

  /**
   * Constructor del componente.
   * @param authService Servicio de autenticación para manejar la sesión del usuario.
   * @param router Router para la navegación entre rutas.
   */
  constructor(private authService: AuthService, private router: Router) {}

  /**
   * Inicializa el componente y suscribe al observable del usuario.
   */
  ngOnInit(): void {
    this.initializeUser();
  }

  /**
   * Suscribe al observable del usuario para obtener el nombre del usuario.
   */
  private initializeUser(): void {
    this.authService.user$.subscribe({
      next: (user) => {
        this.username = user; // Almacena el nombre del usuario en la propiedad `username`
      },
      error: (err) => {
        console.error('Error al obtener el usuario:', err);
        // Aquí podrías manejar el error de forma más elaborada si es necesario
      },
    });
  }

  /**
   * Alterna la visibilidad del menú desplegable.
   * @param event Evento de clic para evitar la propagación.
   */
  toggleDropdown(event: Event): void {
    event.stopPropagation(); // Previene que el clic se propague y cierre el menú inmediatamente
    this.isDropdownOpen = !this.isDropdownOpen; // Alterna el estado del menú desplegable
  }

  /**
   * Cierra el menú desplegable si está abierto cuando se hace clic fuera de él.
   * @param event Evento de clic del documento.
   */
  @HostListener('document:click', ['$event'])
  closeDropdown(event: Event): void {
    // Verifica que el clic no se haya realizado en el menú desplegable o su botón
    const target = event.target as HTMLElement;
    if (
      !target.closest('.dropdown-menu') &&
      !target.closest('.dropdown-toggle')
    ) {
      this.isDropdownOpen = false; // Cierra el menú desplegable si está abierto
    }
  }

  /**
   * Cierra la sesión del usuario y navega a la página de login.
   */
  logout(): void {
    this.authService.logout(); // Llama al servicio de autenticación para cerrar la sesión
    this.router.navigate(['/login']); // Navega a la página de login
  }
}
