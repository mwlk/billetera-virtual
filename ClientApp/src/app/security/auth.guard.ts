import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {

  constructor(private router: Router, private authService: AuthService) {

  }

  canActivate(route: ActivatedRouteSnapshot) {
    const user = this.authService.usuarioData;

    if (user) {
      return true;
    }
    this.router.navigate(['/'])
    return false;
    }

}
