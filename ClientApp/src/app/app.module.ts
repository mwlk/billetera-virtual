import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { JwtInterceptor } from './security/jwt.interceptor';
import { SignupComponent } from './signup/signup.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CotizadorComponent,
    LoginComponent,
    ClienteComponent,
    SignupComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    MatTableModule,
    MatCardModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'login', pathMatch: 'full', canActivate: [AuthGuard]},
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard]},
      { path: 'cliente', component: ClienteComponent, canActivate: [AuthGuard]},
      { path: 'cotizador', component: CotizadorComponent},
      { path: 'login', component: LoginComponent},
      { path: 'signup', component: SignupComponent}
      //,canActivate: [AuthGuard]
    ])
  ],
  providers: [
    ClienteService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
