import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response } from '../models/response';

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

  constructor(private _http: HttpClient) {

  }

  login(email: string, password: string): Observable<Response> {
    return this._http.post<Response>(this.url, { email, password }, httpOptions);
  }
}
