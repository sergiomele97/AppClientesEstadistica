import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/servicios/user.service';

@Component({
  selector: 'app-outliers-detail-table',
  templateUrl: './outliers-detail-table.component.html',
  styleUrls: ['./outliers-detail-table.component.css']
})
export class OutliersDetailTableComponent implements OnInit {


  envios: any[];

  constructor( private userService: UserService ) { }

  ngOnInit() {
    this.getEnvios();
  }

  getEnvios() {

    this.userService.getEnvios().subscribe( datos=> {
      this.envios = datos;
    });

  }

}
