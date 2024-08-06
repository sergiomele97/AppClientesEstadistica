import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/servicios/user.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  envios: any[];

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.getEnvios();
  }

  getEnvios() {
    this.userService.getEnvios().subscribe( datos => {
      this.envios = datos
    })
  }

}
