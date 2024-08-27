// auth.guard.ts
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from '../servicios/auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): boolean {
    const isLoggedIn = this.authService.isAuthenticated();

    // Si el usuario está autenticado
    if (isLoggedIn) {
      // Bloquear acceso a las rutas de login y registro
      if (this.router.url === '/login' || this.router.url === '/register') {
        this.router.navigate(['/estadistica']); // Redirige a la página principal o a cualquier otra ruta autorizada
        return false;
      }
      return true;
    } else {
      // Si el usuario no está autenticado
      if (this.router.url === '/login' || this.router.url === '/register') {
        return true; // Permitir el acceso a login y registro
      }
      this.router.navigate(['/login']); // Redirige a la página de login
      return false;
    }
  }
}
