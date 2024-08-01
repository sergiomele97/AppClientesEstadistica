import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistroComponent } from './registro/registro.component';

import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';

import { UserService } from './servicios/user.service';
import { FormsModule } from '@angular/forms';
import { ClientesComponent } from './menu/clientes/clientes.component';
import { UsuariosComponent } from './menu/usuarios/usuarios.component';
import { MenuComponent } from './menu/menu.component';

import { NgApexchartsModule } from 'ng-apexcharts'
import { VolumetryComponent } from './menu/usuarios/volumetry/volumetry.component';
import { ClustersComponent } from './menu/usuarios/clusters/clusters.component';
import { GraphComponent } from './menu/usuarios/graph/graph.component';
import { MapComponent } from './menu/usuarios/map/map.component';
import { OutliersComponent } from './menu/usuarios/outliers/outliers.component';
import { SpaghettiComponent } from './menu/usuarios/spaghetti/spaghetti.component';
import { TableComponent } from './menu/usuarios/table/table.component';

@NgModule({
  declarations: [				
    AppComponent,
      RegistroComponent,
      LoginComponent,
      RegistroComponent,
      ClientesComponent,
      UsuariosComponent,
      MenuComponent,
      VolumetryComponent,
      ClustersComponent,
      GraphComponent,
      MapComponent,
      OutliersComponent,
      SpaghettiComponent,
      TableComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgApexchartsModule
  ],
  providers: [
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
