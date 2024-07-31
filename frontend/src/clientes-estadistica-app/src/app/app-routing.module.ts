import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistroComponent } from './registro/registro.component';
import { LoginComponent } from './login/login.component';
import { MenuComponent } from './menu/menu.component';
import { ClientesComponent } from './menu/clientes/clientes.component';
import { UsuariosComponent } from './menu/usuarios/usuarios.component';

const routes: Routes = [
  { path: "login", component: LoginComponent},
  
  { path: "registro", component: RegistroComponent },
  { path: "menu", component: MenuComponent},
  { path: "clientes", component: ClientesComponent},
  { path: "usuarios", component: UsuariosComponent},
  { path: "", redirectTo: "/login", pathMatch: "full" },
  { path: "*", redirectTo: "/login", pathMatch: "full" }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
