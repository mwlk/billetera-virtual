import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Response } from "../models/response";

@Injectable()

export class OperacionService {
  urlBase: string = 'https://localhost:5001/api/operacion/';

  constructor(private _http: HttpClient) {

  }

  GetTopTen(_id: number): Observable<Response> {
    return this._http.get<Response>(this.urlBase + 'gettopten/' + _id);
  }
}
