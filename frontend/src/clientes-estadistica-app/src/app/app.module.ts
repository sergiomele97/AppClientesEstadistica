import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination'; 
import { NgApexchartsModule } from 'ng-apexcharts';
import { HighchartsChartModule } from 'highcharts-angular';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { RegistroComponent } from './registro/registro.component';
import { RegistroAdminComponent } from './registroAdmin/registroAdmin.component';
import { LoginComponent } from './login/login.component';
import { UserService } from './servicios/user.service';
import { VolumetryComponent } from './estadisticas/volumetry/volumetry.component';
import { ClustersComponent } from './estadisticas/clusters/clusters.component';
import { GraphComponent } from './estadisticas/graph/graph.component';
import { MapComponent } from './estadisticas/map/map.component';
import { OutliersComponent } from './estadisticas/outliers/outliers.component';
import { SpaghettiComponent } from './estadisticas/spaghetti/spaghetti.component';
import { TableComponent } from './estadisticas/table/table.component';
import { OutliersDetailComponent } from './estadisticas/outliers/outliers-detail/outliers-detail.component';
import { ClustersGraphComponent } from './estadisticas/clusters/clusters-graph/clusters-graph.component';
import { ClustersTableComponent } from './estadisticas/clusters/clusters-table/clusters-table.component';
import { OutliersDetailTableComponent } from './estadisticas/outliers/outliers-detail/outliers-detail-table/outliers-detail-table.component';
import { OutliersDetailGraphComponent } from './estadisticas/outliers/outliers-detail/outliers-detail-graph/outliers-detail-graph.component';
import { EstadisticaComponent } from './estadistica/estadistica.component';
import { EstadisticasComponent } from './estadisticas/estadisticas.component';
import { ClientesComponent } from './estadisticas/clientes/clientes.component';
import { DivisasComponent } from './estadisticas/divisas/divisas.component';
import { AuthGuard } from './auth.guard';
import { UsersInfoComponent } from './menu/usuarios/users-info/users-info.component';
import { ClustersDataService } from './servicios/clusters-data.service';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [	
    AppComponent,
    LoginComponent,
    RegistroComponent,
    EstadisticasComponent,
    RegistroAdminComponent,
    ClientesComponent,
    VolumetryComponent,
    ClustersComponent,
    ClustersGraphComponent,      
    ClustersTableComponent,
    GraphComponent,
    MapComponent,
    OutliersComponent,
    SpaghettiComponent,
    TableComponent,
    OutliersComponent,
    OutliersDetailComponent,
    OutliersDetailTableComponent, 
    OutliersDetailGraphComponent, 
    HomeComponent ,
    EstadisticaComponent,
    ClientesComponent,
    DivisasComponent,
    UsersInfoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgApexchartsModule,
    HighchartsChartModule,
    NgxPaginationModule
  ],
  providers: [
    UserService,
    ClustersDataService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA] 
})

export class AppModule { }
