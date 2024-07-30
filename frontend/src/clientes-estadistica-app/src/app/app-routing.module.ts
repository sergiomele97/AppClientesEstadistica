import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistroComponent } from './registro/registro.component';
import { MenuComponent } from './menu/menu.component';
import { ClientesComponent } from './clientes/clientes.component';
import { UsuariosComponent } from './usuarios/usuarios.component';

const routes: Routes = [
  { path: "registro", component: RegistroComponent },
  { path: "", redirectTo: "/menu", pathMatch: "full" },
  { path: "menu", component: MenuComponent},
  { path: "clientes", component: ClientesComponent},
  { path: "usuarios", component: UsuariosComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
