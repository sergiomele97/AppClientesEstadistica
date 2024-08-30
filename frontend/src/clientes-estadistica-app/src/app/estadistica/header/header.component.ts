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
  isDropdownOpen: boolean = false;
  username: string | null = null;
  usuario: Usuario | undefined;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {
    this.initializeUser();
  }

  initializeUser() {
    this.authService.user$.subscribe((user) => {
      this.username = user;
    });
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
