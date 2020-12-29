import { ErrorHandler, OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Usuario } from '../models/usuario';
import { TryCatchStmt } from '@angular/compiler';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'login-component',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  public usuario: Usuario;
  private errorLogin: boolean = false;

  public loginForm = this.builder.group({
    email: ['', Validators.compose(
      [Validators.required, Validators.email])],
    password: ['', Validators.compose(
      [Validators.required, Validators.minLength(3)])]
    //cambiar a 8 el minimo, mi user-mail es mirkowlk@gmail.com y la pass es 1234 para probar las respuestas del login
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
        this.errorLogin = false;
        this.router.navigate(['/home']);
      } 
      //console.log('ID de usuario '+localStorage.getItem('ID'));
    },
      (err) => {
        this.loginForm.reset();
        this.errorLogin = true;
      }
    );
  }

  closeAlert() {
    this.errorLogin = false;
  }
}
