import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Response } from '../models/response'

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'token-auth'
  })
}

@Injectable({
  providedIn: 'root'
})

export class CuentaService{
  urlBase: string = 'https://localhost:5001/api/cuenta/';
  cuenta: any;

  constructor(private _http: HttpClient) {
  }

  getByIdCliente(_id: number): Observable<Response> {
    return this._http.get<Response>(this.urlBase + 'GetByCliente/' + _id);
  }
}
