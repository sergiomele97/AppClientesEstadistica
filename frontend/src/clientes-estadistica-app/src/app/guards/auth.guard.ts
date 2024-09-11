import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../servicios/auth.service';

/**
 * Guard que protege las rutas que requieren autenticación.
 */
@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  /**
   * Determina si la navegación a una ruta protegida está permitida.
   * @returns `true` si el usuario está autenticado, de lo contrario `false`.
   */
  canActivate(): boolean {
    const isLoggedIn = this.authService.isAuthenticated();

    if (isLoggedIn) {
      // Permitir acceso si el usuario está autenticado
      return true;
    } else {
      // Redirigir al usuario a la página de login si no está autenticado
      this.router.navigate(['/login']);
      return false;
    }
  }
}
