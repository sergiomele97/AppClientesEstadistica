import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistroComponent } from './registro/registro.component';
import { MenuComponent } from './menu/menu.component';

const routes: Routes = [
  { path: "registro", component: RegistroComponent },
  // { path: "", redirectTo: "/registro", pathMatch: "full" },
  // { path: "**", redirectTo: "/registro", pathMatch: "full" },
  { path: "menu", component: MenuComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
