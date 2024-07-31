import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistroComponent } from './registro/registro.component';
import { LoginComponent } from './login/login.component';
import { MenuComponent } from './menu/menu.component';
import { ClientesComponent } from './menu/clientes/clientes.component';
import { UsuariosComponent } from './menu/usuarios/usuarios.component';
import { OutliersComponent } from './menu/usuarios/outliers/outliers.component';
import { SpaghettiComponent } from './menu/usuarios/spaghetti/spaghetti.component';
import { GraphComponent } from './menu/usuarios/graph/graph.component';
import { MapaComponent } from './menu/usuarios/mapa/mapa.component';
import { ClusterComponent } from './menu/usuarios/cluster/cluster.component';
import { VolumetriaComponent } from './menu/usuarios/volumetria/volumetria.component';
import { TableComponent } from './menu/usuarios/table/table.component';
const routes: Routes = [
  { path: "login", component: LoginComponent},
  { path: "", redirectTo: "/login", pathMatch: "full" },
  { path: "*", redirectTo: "/login", pathMatch: "full" },
  { path: "registro", component: RegistroComponent },
  { path: "menu", component: MenuComponent,
    children: [
      { path: "clientes", component: ClientesComponent},
      { path: "usuarios", component: UsuariosComponent,
        children: [
          {path: "outliers", component: OutliersComponent},
          {path: "volumetria", component: VolumetriaComponent},
          {path: "cluster", component: ClusterComponent},
          {path: "mapa", component: MapaComponent},
          {path: "graph", component: GraphComponent},
          {path: "spaghetti", component: SpaghettiComponent},
          {path: "tabla", component: TableComponent},
        ]
      }
    ]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
