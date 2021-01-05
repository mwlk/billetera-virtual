import { Component } from '@angular/core';
import { CuentaService } from '../services/cuenta.service';
import { Response } from '../models/response';
import { OperacionService } from '../services/operacion.service';
import { Cuenta } from '../models/cuenta';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  public cuenta: Cuenta;
  public operaciones: any[];

  public _id: number = parseInt(localStorage.getItem('ID'));
  public _idCuenta: number;
  constructor(private cuentaSVC: CuentaService,
              private OperacionSVC: OperacionService  ) {

  }
  ngOnInit() {
    this.getCuentaById();
    this.GetTopTenOperaciones();
  }

  getCuentaById() {
    this.cuentaSVC.getByIdCliente(this._id).subscribe(response => {
      this.cuenta = response.data;
     //this._idCuenta = this.cuenta.idCuenta;
     //console.log(this._idCuenta);
    });
  }

  GetTopTenOperaciones() {
    this.OperacionSVC.GetTopTen(6).subscribe(response => {
      this.operaciones = response.data;
      console.log(response.data);
    });
  }
}
