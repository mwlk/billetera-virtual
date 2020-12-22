import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CotizadorComponent } from './cotizador/cotizador.component'
import { LoginComponent } from './login/login.component';
import { ClienteComponent } from './cliente/cliente.component';

import { ClienteService } from './services/cliente.service';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card'; 
import { AuthGuard } from './security/auth.guard';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CotizadorComponent,
    LoginComponent,
    ClienteComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatTableModule,
    MatCardModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/home', pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'cliente', component: ClienteComponent, canActivate: [AuthGuard] },
      { path: 'cotizador', component: CotizadorComponent},
      { path: 'login', component:LoginComponent},
      // {path: 'signup', component: SignUpComponent}
    ])
  ],
  providers: [ClienteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
