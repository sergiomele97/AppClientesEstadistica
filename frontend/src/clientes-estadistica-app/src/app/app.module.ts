import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { RegistroComponent } from './registro/registro.component';
import { LoginComponent } from './login/login.component';
import { UserService } from './servicios/user.service';
import { MenuComponent } from './menu/menu.component';
import { ClientesComponent } from './menu/clientes/clientes.component';
import { UsuariosComponent } from './menu/usuarios/usuarios.component';
import { VolumetryComponent } from './menu/usuarios/volumetry/volumetry.component';
import { ClustersComponent } from './menu/usuarios/clusters/clusters.component';
import { GraphComponent } from './menu/usuarios/graph/graph.component';
import { MapComponent } from './menu/usuarios/map/map.component';
import { OutliersComponent } from './menu/usuarios/outliers/outliers.component';
import { SpaghettiComponent } from './menu/usuarios/spaghetti/spaghetti.component';
import { TableComponent } from './menu/usuarios/table/table.component';
import { BalanceComponent } from './menu/clientes/balance/balance.component';
import { DivisePredictionComponent } from './menu/clientes/divise-prediction/divise-prediction.component';
import { OutliersDetailComponent } from './menu/usuarios/outliers/outliers-detail/outliers-detail.component';

import { NgApexchartsModule } from 'ng-apexcharts';
import { HighchartsChartModule } from 'highcharts-angular';
import { UsersInfoComponent } from './menu/usuarios/users-info/users-info.component';

@NgModule({
  declarations: [					
    AppComponent,
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
      TableComponent,
      DivisePredictionComponent,
      BalanceComponent,
      OutliersComponent,
      OutliersDetailComponent,
      UsersInfoComponent
      
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgApexchartsModule,
    HighchartsChartModule,
    ReactiveFormsModule
  ],
  providers: [
    UserService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
