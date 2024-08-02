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
import { MapComponent } from './menu/usuarios/map/map.component';
import { ClustersComponent } from './menu/usuarios/clusters/clusters.component';
import { VolumetryComponent } from './menu/usuarios/volumetry/volumetry.component';
import { TableComponent } from './menu/usuarios/table/table.component';
import { OutliersDetailComponent } from './menu/usuarios/outliers/outliers-detail/outliers-detail.component';


const routes: Routes = [
  { path: "login", component: LoginComponent},
  { path: "registro", component: RegistroComponent },
  { path: "menu", component: MenuComponent,
    children: [
      { path: "clientes", component: ClientesComponent},
      { path: "usuarios", component: UsuariosComponent,
        children: [
          {path: "outliers", component: OutliersComponent},
          {path: "outliers/:id", component:OutliersDetailComponent},
          {path: "volumetry", component: VolumetryComponent},
          {path: "clusters", component: ClustersComponent},
          {path: "map", component: MapComponent},
          {path: "graph", component: GraphComponent},
          {path: "spaghetti", component: SpaghettiComponent},
          {path: "table", component: TableComponent},
        ]
      }
    ]
  },
  { path:"", redirectTo:"/login", pathMatch:"full" },
  { path:"**", redirectTo:"/login", pathMatch:"full" },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
