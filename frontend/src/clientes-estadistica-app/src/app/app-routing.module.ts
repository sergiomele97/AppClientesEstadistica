import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SpaghettiComponent } from './estadisticas/spaghetti/spaghetti.component';
import { GraphComponent } from './estadisticas/graph/graph.component';
import { MapComponent } from './estadisticas/map/map.component';

import { VolumetryComponent } from './estadisticas/volumetry/volumetry.component';
import { TableComponent } from './estadistica/table/table.component';
import { EstadisticasComponent } from './estadisticas/estadisticas.component';

import { ClientesComponent } from './estadistica/clientes/clientes.component';
import { DivisasComponent } from './estadistica/divisas/divisas.component';
import { EstadisticaComponent } from './estadistica/estadistica.component';
import { OutlierComponent } from './estadistica/outlier/outlier.component';
import { ShowOutlierComponent } from './estadistica/outlier/show-outlier/show-outlier.component';
import { GraficasComponent } from './estadistica/graficas/Graficas.component';
import { RegisterComponent } from './register/register.component';
import { LogsOutlierComponent } from './estadistica/outlier/logs-outlier/logs-outlier.component';
import { ClustersComponent } from './estadistica/clusters/clusters.component';
import { AuthGuard } from './guards/auth.guard';
import { BienvenidaComponent } from './estadistica/bienvenida/bienvenida.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'registro', component: RegisterComponent },
  {
    path: 'estadistica',
    component: EstadisticaComponent,
    canActivate: [AuthGuard],
    children: [
      { path: '', component: BienvenidaComponent },
      { path: 'outliers', component: OutlierComponent },
      { path: 'outliers/:id', component: ShowOutlierComponent },
      { path: 'outliers-logs', component: LogsOutlierComponent },
      { path: 'divisas', component: DivisasComponent },
      { path: 'graficas', component: GraficasComponent },
      { path: 'clientes', component: ClientesComponent },
      { path: 'clientes/:id', component: ClientesComponent },
      { path: 'table', component: TableComponent },
      { path: 'clusters', component: ClustersComponent },
    ],
  },
  { path: '', redirectTo: '/estadistica', pathMatch: 'full' },
  { path: '**', redirectTo: '/estadistica', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
