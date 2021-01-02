import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../models/cliente';
import { Response } from '../models/response';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'token-auth'
  })
}

@Injectable({
  providedIn: 'root'
})

export class ClienteService {

  url: string = 'https://localhost:5001/api/Cliente/getlistmodels';

  urlAdd: string = 'https://localhost:5001/api/Cliente/Add';

  constructor(
    private _http: HttpClient) { }

  getClientes(): Observable<Response> {
    return this._http.get<Response>(this.url);
  }

  postCliente(cliente: Cliente) {
     this._http.post<Response>(this.urlAdd, cliente, httpOptions).subscribe(res => {
       console.log(res);
    }, error => console.log(error))
  }
}
