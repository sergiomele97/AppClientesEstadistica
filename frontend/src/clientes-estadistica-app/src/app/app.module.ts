import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistroComponent } from './registro/registro.component';

import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { UserService } from './servicios/user.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [		
    AppComponent,
      RegistroComponent,
      LoginComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
