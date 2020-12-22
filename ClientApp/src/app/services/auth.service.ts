import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Response } from '../models/response';
import { Usuario } from '../models/usuario';
import { map } from 'rxjs/operators';
import { Login } from '../models/login';

const httpOptions = {
  headers: new HttpHeaders({
    'Contend-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  url: string = 'https://localhost:5001/api/cliente/login';

  private usuarioSubject: BehaviorSubject<Usuario>;

  public get usuarioData(): Usuario {
    return this.usuarioSubject.value
  }

  constructor(private _http: HttpClient) {
    this.usuarioSubject = new BehaviorSubject<Usuario>(
      JSON.parse(localStorage.getItem('User'))
    );
  }

  login(login: Login): Observable<Response> {
    return this._http.post<Response>(this.url, login, httpOptions).pipe(
      map(res => {
        if (res.exito === 1) {
          const user: Usuario = res.data;
          localStorage.setItem('User', JSON.stringify(user));
          this.usuarioSubject.next(user);
        }
        return res;
      })
    );
  }

  logout() {
    localStorage.removeItem('User');
    this.usuarioSubject.next(null);
  }
}
