import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { NgApexchartsModule } from 'ng-apexcharts';
import { HighchartsChartModule } from 'highcharts-angular';

// Routing Module
import { AppRoutingModule } from './app-routing.module';

// Root Component
import { AppComponent } from './app.component';

// Feature Components
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { VolumetryComponent } from './estadisticas/volumetry/volumetry.component';
import { ClustersComponent } from './estadistica/clusters/clusters.component';
import { GraphComponent } from './estadisticas/graph/graph.component';
import { MapComponent } from './estadisticas/map/map.component';
import { SpaghettiComponent } from './estadisticas/spaghetti/spaghetti.component';
import { TableComponent } from './estadistica/table/table.component';
import { ClustersGraphComponent } from './estadistica/clusters/clusters-graph/clusters-graph.component';
import { ClustersTableComponent } from './estadistica/clusters/clusters-table/clusters-table.component';
import { EstadisticaComponent } from './estadistica/estadistica.component';
import { ClientesComponent } from './estadistica/clientes/clientes.component';
import { DivisasComponent } from './estadistica/divisas/divisas.component';
import { OutlierComponent } from './estadistica/outlier/outlier.component';
import { ShowOutlierComponent } from './estadistica/outlier/show-outlier/show-outlier.component';
import { GraficasComponent } from './estadistica/graficas/graficas.component';
import { LogsOutlierComponent } from './estadistica/outlier/logs-outlier/logs-outlier.component';
import { HeaderComponent } from './estadistica/header/header.component';
import { SidebarComponent } from './estadistica/sidebar/sidebar.component';
import { AlertComponent } from './estadistica/alert/alert.component';
import { BienvenidaComponent } from './estadistica/bienvenida/bienvenida.component';

// Services
import { UsuarioService } from './servicios/usuario.service';
import { ClustersDataService } from './servicios/clusters-data.service';
import { PruebaConexionService } from './servicios/pruebaConexion.service';

// Pipes
import { DatePipe } from '@angular/common';
import { CustomCurrencyPipe } from './pipes/customCurrency.pipe';
import { FormaterFechaPipe } from './pipes/formaterFecha.pipe';

@NgModule({
  declarations: [
    // Root Component
    AppComponent,

    // Feature Components
    LoginComponent,
    RegisterComponent,
    ClientesComponent,
    VolumetryComponent,
    ClustersComponent,
    ClustersGraphComponent,
    ClustersTableComponent,
    GraphComponent,
    MapComponent,
    SpaghettiComponent,
    TableComponent,
    EstadisticaComponent,
    DivisasComponent,
    OutlierComponent,
    ShowOutlierComponent,
    GraficasComponent,
    LogsOutlierComponent,
    HeaderComponent,
    SidebarComponent,
    AlertComponent,
    BienvenidaComponent,

    // Pipes
    FormaterFechaPipe,
    CustomCurrencyPipe,
  ],

  imports: [
    // Core Angular Modules
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,

    // Third-Party Modules
    NgxPaginationModule,
    NgApexchartsModule,
    HighchartsChartModule,

    // Routing Module
    AppRoutingModule,
  ],

  providers: [
    // Services
    UsuarioService,
    PruebaConexionService,
    ClustersDataService,

    // Pipes
    DatePipe,
    FormaterFechaPipe,
    CustomCurrencyPipe,
  ],

  // Root Component
  bootstrap: [AppComponent],

  // Allow custom elements
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
