import { Component, AfterViewInit, OnInit } from '@angular/core';
import { Usuario } from '../clases/usuario';
import { PruebaConexionService } from '../servicios/pruebaConexion.service';

// Decorador 
@Component({
  selector: 'app-estadistica',
  templateUrl: './estadistica.component.html',
  styleUrls: ['./estadistica.component.css']
})

export class EstadisticaComponent implements OnInit, AfterViewInit {
  usuarios: Usuario[];
  private usuarioService: PruebaConexionService;
  

  // Método para dropdown
  isDropdownOpen = false;

  toggleDropdown() {
    this.isDropdownOpen = !this.isDropdownOpen;
  }

  constructor(private pruebaConexionService: PruebaConexionService) { }
  ngAfterViewInit(): void {
    throw new Error('Method not implemented.');
  }

  // -------------------- Método Sergio para Debuggear en Azure, no borrar:
  ngOnInit(): void {
    this.pruebaConexionService.getUsuariosPrueba().subscribe((data: Usuario[]) => {
      this.usuarios = data;
      console.log('Usuarios obtenidos:', this.usuarios)
    }, error => {
      console.error('Error al obtener los usuarios', error);
    });
  }
  // -------------------- Fin Método Sergio para Debuggear en Azure, no borrar:
  
  
}


  