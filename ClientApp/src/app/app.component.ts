import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from './models/usuario';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  isLoginIn = true;
  usuario: Usuario;

  constructor(public authService: AuthService,
    private router: Router) {

    //metodo pasado a nav-menu.component
    /* this.authService.usuario.subscribe(res => {
      this.usuario = res;
      
    })**/
  }
}
