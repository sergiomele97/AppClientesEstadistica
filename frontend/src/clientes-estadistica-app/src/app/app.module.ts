import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination'; 
import { NgApexchartsModule } from 'ng-apexcharts';
import { HighchartsChartModule } from 'highcharts-angular';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LoginComponent } from './login/login.component';
import { VolumetryComponent } from './estadisticas/volumetry/volumetry.component';
import { ClustersComponent } from './estadistica/clusters/clusters.component';
import { GraphComponent } from './estadisticas/graph/graph.component';
import { MapComponent } from './estadisticas/map/map.component';
import { SpaghettiComponent } from './estadisticas/spaghetti/spaghetti.component';
import { TableComponent } from './estadistica/table/table.component';
import { ClustersGraphComponent } from './estadistica/clusters/clusters-graph/clusters-graph.component';
import { ClustersTableComponent } from './estadistica/clusters/clusters-table/clusters-table.component';
import { EstadisticaComponent } from './estadistica/estadistica.component';
import { EstadisticasComponent } from './estadisticas/estadisticas.component';
import { ClientesComponent } from './estadistica/clientes/clientes.component';
import { DivisasComponent } from './estadistica/divisas/divisas.component';
import { AuthGuard } from './auth.guard';
import { ClustersDataService } from './servicios/clusters-data.service';
import { HomeComponent } from './home/home.component';
import { PruebaConexionService } from './servicios/pruebaConexion.service';
import { OutlierComponent } from './estadistica/outlier/outlier.component';
import { ShowOutlierComponent } from './estadistica/outlier/show-outlier/show-outlier.component';
import { GraficasComponent } from './estadistica/graficas/Graficas.component';
import { DatePipe } from '@angular/common';
import { FormaterFechaPipe } from './pipes/formaterFecha.pipe';
import { RegisterComponent } from './register/register.component';
import { LogsOutlierComponent } from './estadistica/outlier/logs-outlier/logs-outlier.component';
import { UsuarioService } from './servicios/usuario.service';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    EstadisticasComponent,
    ClientesComponent,
    VolumetryComponent,
    ClustersComponent,
    ClustersGraphComponent,
    ClustersTableComponent,
    GraphComponent,
    MapComponent,
    SpaghettiComponent,
    TableComponent,
    HomeComponent ,
    EstadisticaComponent,
    ClientesComponent,
    DivisasComponent,
    OutlierComponent,
    ShowOutlierComponent,
    GraficasComponent,
    FormaterFechaPipe,
    RegisterComponent,
    LogsOutlierComponent
   ],
   
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgApexchartsModule,
    HighchartsChartModule,
    NgxPaginationModule,
    BrowserModule
  ],
  providers: [
    UsuarioService,
    PruebaConexionService,
    ClustersDataService,
    DatePipe
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA] 
})

export class AppModule { }
