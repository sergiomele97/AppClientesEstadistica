import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Authentication Components
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

// Estadísticas Components
import { EstadisticaComponent } from './estadistica/estadistica.component';
import { BienvenidaComponent } from './estadistica/bienvenida/bienvenida.component';
import { ClientesComponent } from './estadistica/clientes/clientes.component';
import { DivisasComponent } from './estadistica/divisas/divisas.component';
import { OutlierComponent } from './estadistica/outlier/outlier.component';
import { ShowOutlierComponent } from './estadistica/outlier/show-outlier/show-outlier.component';
import { LogsOutlierComponent } from './estadistica/outlier/logs-outlier/logs-outlier.component';
import { GraficasComponent } from './estadistica/graficas/Graficas.component';
import { TableComponent } from './estadistica/table/table.component';
import { ClustersComponent } from './estadistica/clusters/clusters.component';

// Guards
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  // Authentication Routes
  { path: 'login', component: LoginComponent },
  { path: 'registro', component: RegisterComponent },

  // Estadística Routes (Protected by AuthGuard)
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

  // Default Route
  { path: '', redirectTo: '/estadistica', pathMatch: 'full' },

  // Fallback Route
  { path: '**', redirectTo: '/estadistica', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
