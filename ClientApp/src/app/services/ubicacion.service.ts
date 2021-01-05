import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Response } from '../models/response';
import { Provincia } from '../models/provincia';
import { Localidad } from '../models/localidad';
import { Direccion } from "../models/direccion";



const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable()

export class UbicacionService {

  urlBase: string = 'https://localhost:5001/api/provincia/';

  private provincia: Provincia[];
  private localidad: Localidad[];

  constructor(private _http: HttpClient) {
  }

  getProvincias(): Observable<Response> {
    return this._http.get<Response>(this.urlBase + 'get');
  }

  getLocalidades(id: number): Observable<Response> {
    return this._http.get<Response>(this.urlBase + 'byid/' + id);
  }

  addDireccion(direccion: Direccion) {
    return this._http.post<Response>(this.urlBase + 'AddDirecion', direccion, httpOptions).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }
}
