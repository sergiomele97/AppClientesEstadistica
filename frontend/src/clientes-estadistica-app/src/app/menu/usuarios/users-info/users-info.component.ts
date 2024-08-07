import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserService } from 'src/app/servicios/user.service'; 
import { ClienteService } from 'src/app/servicios/cliente.service';
import { Usuario } from 'src/app/clases/usuario'; 
import { Cliente } from 'src/app/clases/cliente'; 

@Component({
  selector: 'app-users-info',
  templateUrl: './users-info.component.html',
})
export class UsersInfoComponent implements OnInit, OnDestroy {
selectedCliente(_t71: Cliente) {
throw new Error('Method not implemented.');
}
editCliente(_t71: Cliente) {
throw new Error('Method not implemented.');
}
editUsuario(_t37: Usuario) {
throw new Error('Method not implemented.');
}
  selectedUsuario: any;
  usuarios: Usuario[] = [];
  filteredUsuarios: Usuario[] = [];
  clientes: Cliente[] = [];
  filteredClientes: Cliente[] = [];
  
  // Variables para la paginación
  page: number = 1;
  pageSize: number = 5;
  totalUsuarios: number = 0;
  totalClientes: number = 0;

  // Variable para el filtrado
  searchTerm: string = '';

  // Variables para la tabulación
  activeTab: string = 'table1';

  // Variable para almacenar la suscripción
  private subscription: Subscription = new Subscription();

  constructor(private userService: UserService, private clienteService: ClienteService) { }

  ngOnInit(): void {
    this.loadUsuarios();
    this.loadClientes();
  }

  loadUsuarios(): void {
    this.subscription.add(
      this.userService.getUsuarios().subscribe(
        data => {
          this.usuarios = data;
          this.filteredUsuarios = data;
          this.totalUsuarios = data.length;
        },
        error => {
          console.error('Error fetching users', error);
        }
      )
    );
  }

  loadClientes(): void {
    this.subscription.add(
      this.clienteService.getClientes().subscribe(
        data => {
          this.clientes = data;
          this.filteredClientes = data;
          this.totalClientes = data.length;
        },
        error => {
          console.error('Error fetching clients', error);
        }
      )
    );
  }

  filterResults(): void {
    if (this.activeTab === 'table1') {
      this.filteredUsuarios = this.usuarios.filter(usuario => 
        usuario.userName.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
        usuario.email.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
        usuario.rol.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
      this.totalUsuarios = this.filteredUsuarios.length;
    } else if (this.activeTab === 'table2') {
      this.filteredClientes = this.clientes.filter(cliente => 
        cliente.nombre.toLowerCase().includes(this.searchTerm.toLowerCase()) ||
        cliente.email.toLowerCase().includes(this.searchTerm.toLowerCase())
      );
      this.totalClientes = this.filteredClientes.length;
    }
    this.page = 1; 
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
