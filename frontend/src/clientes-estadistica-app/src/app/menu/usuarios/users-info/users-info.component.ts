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
  // Variables para almacenar el usuario o cliente seleccionado y el estado del modal
  selectedCliente: Cliente | null = null;
  selectedUsuario: Usuario | null = null;
  isModalOpen = false;
  editMode: 'user' | 'client' = 'user';

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

  editUsuario(usuario: Usuario): void {
    this.selectedUsuario = { ...usuario };
    this.editMode = 'user';
    this.isModalOpen = true;
  }

  editCliente(cliente: Cliente): void {
    this.selectedCliente = { ...cliente };
    this.editMode = 'client';
    this.isModalOpen = true;
  }

  closeModal(): void {
    this.isModalOpen = false;
    this.selectedUsuario = null;
    this.selectedCliente = null;
  }

  onSave(): void {
    if (this.editMode === 'user' && this.selectedUsuario) {
      // Implementa aquí la lógica para guardar el usuario editado
      console.log('Usuario guardado:', this.selectedUsuario);
    } else if (this.editMode === 'client' && this.selectedCliente) {
      // Implementa aquí la lógica para guardar el cliente editado
      console.log('Cliente guardado:', this.selectedCliente);
    }
    this.closeModal();
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
