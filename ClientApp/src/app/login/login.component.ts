import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Usuario } from '../models/usuario';

@Component({
  selector: 'login-component',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  public usuario: Usuario;

  public loginForm = this.builder.group({
    email: ['', Validators.compose(
      [Validators.required, Validators.email])],
    password: ['', Validators.compose(
      [Validators.required, Validators.minLength(3)])]
  });

  /*public loginForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl('')
  });
  **/
  constructor(public authService: AuthService, private router: Router,
    private builder: FormBuilder) {
    if (this.authService.usuarioData) {
      this.router.navigate(['/home'])
    }
  }

  ngOnInit() {

  }

  login() {
    //console.log(this.loginForm.value);
    this.authService.login(this.loginForm.value).subscribe(response => {
      if (response.exito === 1) {
        this.router.navigate(['/home']);
      }
      //console.log('ID de usuario '+localStorage.getItem('ID'));
    });
  }
}
