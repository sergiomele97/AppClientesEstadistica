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
import { ClustersGraphComponent } from './menu/usuarios/clusters-graph/clusters-graph.component';
import { ClustersTableComponent } from './menu/usuarios/clusters/clusters-table/clusters-table.component';
import { OutliersDetailTableComponent } from './menu/usuarios/outliers/outliers-detail/outliers-detail-table/outliers-detail-table.component';
import { OutliersDetailGraphComponent } from './menu/usuarios/outliers/outliers-detail/outliers-detail-graph/outliers-detail-graph.component';

import { NgApexchartsModule } from 'ng-apexcharts';
import { HighchartsChartModule } from 'highcharts-angular';


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
      ClustersGraphComponent,
      ClustersTableComponent,
      OutliersDetailTableComponent,
      OutliersDetailGraphComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgApexchartsModule,
    HighchartsChartModule
  ],
  providers: [
    UserService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
