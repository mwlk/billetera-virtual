import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../services/cliente.service';
import { Response } from '../models/response';


@Component({
  selector: 'app-cliente-component',
  templateUrl: './cliente.component.html'
})
export class ClienteComponent {

  public lista: any[];
  public columnas: string[] = ['idCliente', 'nombre', 'apellido', 'estado', 'idDireccion', 'nroTelefono', 'nroDni', 'frontalDni', 'traseraDni'];

  constructor(
    private clienteService: ClienteService
  ) {
    
  }
  ngOnInit(): void {
    this.getClientes();
  }

  getClientes() {
    this.clienteService.getClientes().subscribe(response => {
      this.lista = response.data;
      //console.log(response.data);
    });
  }
}
