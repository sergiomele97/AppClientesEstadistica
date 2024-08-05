import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/servicios/user.service'; 
import { Usuario } from 'src/app/clases/usuario'; 

@Component({
  selector: 'app-users-info',
  templateUrl: './users-info.component.html',
  styleUrls: ['./users-info.component.css']
})
export class UsersInfoComponent implements OnInit {
  usuarios: Usuario[] = [];

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loadUsuarios();
  }

  loadUsuarios(): void {
    this.userService.getUsuarios().subscribe(
      data => {
        this.usuarios = data;
      },
      error => {
        console.error('Error fetching users', error);
      }
    );
  }
}
