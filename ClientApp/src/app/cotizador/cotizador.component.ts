import { Component } from '@angular/core';
import { DivizaService } from '../services/diviza.service';

@Component({
  selector: 'cotizador-component',
  templateUrl: './cotizador.component.html',
  styleUrls: ['./cotizador.component.css']
})

export class CotizadorComponent {
  
  public divizas: Array<any> = [];

  constructor(private service: DivizaService) {
    this.service.getCotizacion().subscribe((resp: any) => {
      this.divizas = resp;
    });
  }

}
