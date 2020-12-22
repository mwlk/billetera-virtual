import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'login-component',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{

  public email: string;
  public password: string;

  constructor(public authService: AuthService) {

  }

  ngOnInit() {

  }

  login() {
    this.authService.login(this.email, this.password).subscribe(response => {
      console.log(response);
    });
  }
}
