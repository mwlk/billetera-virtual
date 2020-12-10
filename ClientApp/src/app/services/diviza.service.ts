import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})

export class DivizaService {
  _urlAPI = 'https://www.dolarsi.com/api/api.php?type=valoresprincipales';
  constructor(private client: HttpClient) {

  }

  getCotizacion() {
    let header = new HttpHeaders().
      set('Content-Type', 'application-json')

    return this.client.get(this._urlAPI, {
      headers: header
    });
  }
}
