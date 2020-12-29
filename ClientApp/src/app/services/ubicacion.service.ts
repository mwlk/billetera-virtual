import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Response } from '../models/response';
import { Provincia } from '../models/provincia';
import { Localidad } from '../models/localidad';

@Injectable()

export class UbicacionService {

  url: string = 'https://localhost:5001/api/provincia/get';

  private provincia: Provincia[];
  private localidad: Localidad[];

  constructor(private _http: HttpClient) {
  }

  getProvincias(): Observable<Response> {
    return this._http.get<Response>(this.url);
  }
}
