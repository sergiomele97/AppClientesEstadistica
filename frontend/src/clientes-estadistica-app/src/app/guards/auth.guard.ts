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
      // Permitir acceso a todas las rutas protegidas
      return true;
    } else {
      // Redirigir a la página de login si el usuario no está autenticado
      this.router.navigate(['/login']);
      return false;
    }
  }
}
