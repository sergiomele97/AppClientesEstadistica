import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/servicios/user.service'; 
import { Usuario } from 'src/app/clases/usuario'; 

@Component({
  selector: 'app-users-info',
  templateUrl: './users-info.component.html',
  styleUrls: ['./users-info.component.css']
})
export class UsersInfoComponent implements OnInit, OnDestroy {
editUsuario(_t34: Usuario) {
throw new Error('Method not implemented.');
}
  selectedUsuario: any;
  usuarios: Usuario[] = [];
  filteredUsuarios: Usuario[] = [];
  clientes: Usuario[] = [];
  
  // Variables para la paginación
  page: number = 1;
  pageSize: number = 5;
  totalUsuarios: number = 0;

  // Variable para el filtrado
  searchTerm: string = '';

  // Variables para la tabulación
  activeTab: string = 'table1';

  // Variable para almacenar la suscripción
  private subscription: Subscription;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loadUsuarios();
  }

  loadUsuarios(): void {
    this.subscription = this.userService.getUsuarios().subscribe(
      data => {
        this.usuarios = data;
        this.filteredUsuarios = data;
        this.totalUsuarios = data.length;
        console.log(this.usuarios);
      },
      error => {
        console.error('Error fetching users', error);
      }
    );
  }

  filterUsuarios(): void {
    this.filteredUsuarios = this.usuarios.filter(usuario => 
      usuario.userName.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      usuario.email.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
      usuario.rol.toLowerCase().includes(this.searchTerm.toLowerCase())
    );
    this.totalUsuarios = this.filteredUsuarios.length;
    this.page = 1; 
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
