import { Component } from "@angular/core";
import { FormBuilder, Validators, FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { Cliente, ClienteViewModel } from "../models/cliente";
import { Provincia } from "../models/provincia";
import { UbicacionService } from "../services/ubicacion.service";
import { Direccion } from "../models/direccion";

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
  providers: [UbicacionService]
})

export class SignupComponent {

  public provincias: any;
  public localidades: any;
  public idLocalidad: any;
  public displayDireccion: boolean;

  provinciaSelected = new FormControl('');
  localidadSelected = new FormControl('');

  emailRepeat = new FormControl('');
  passwordRepeat = new FormControl('');

  clienteViewModel: ClienteViewModel;
  direccion: Direccion;

 /*public provincia: Provincia = {
    idProvincia: 0,
    nombre: 'Provincia',
    descripcion: ''
  };**/

  public signupForm = this.builder.group({
    nombre: ['', Validators.compose([
      Validators.required])],
    apellido: ['', Validators.compose([
      Validators.required])],
    nroTelefono: [''],
    nroDni: ['', Validators.compose([
      Validators.required])],
    frontalDni: [''],
    traseralDni: [''],
    email: ['', Validators.compose([
      Validators.required, Validators.email])],
    password: ['', Validators.compose([
      Validators.required, Validators.minLength(8)])],
    direccion: ['', Validators.compose([
      Validators.required])],
    alturaCalle: ['', Validators.compose([
      Validators.required])],
    ciudad: ['', Validators.compose([
      Validators.required])],
    provincia: ['', Validators.compose([
      Validators.required])]
  })

  constructor(private builder: FormBuilder, private ubicacion: UbicacionService) {

  }

  ngOnInit(): void {
    this.ubicacion.getProvincias().subscribe(rsp => {
      this.provincias = rsp.data;
      //console.log(rsc.data);
    });
  }

  SelectProvincia(id: number): void {
    //console.log('ID PROVINCIA ', id);
    this.ubicacion.getLocalidades(id).subscribe(rsp => {
      this.localidades = rsp.data;
    })
  }

  SelectLocalidad(id: any): void {
    //console.log('ID LOCALIDAD ', id);
    this.idLocalidad = id;
    //console.log(this.idLocalidad);
    if (this.idLocalidad == 'Seleccionar Localidad') {
      this.displayDireccion = false;
    } else {
      this.displayDireccion = true;
    }
  }

  signup() {
    this.clienteViewModel = this.signupForm.value;
     this.direccion = {
       calle: this.clienteViewModel.direccion,
       numero: this.clienteViewModel.alturaCalle,
       idLocalidad: this.idLocalidad
    };
    this.ubicacion.addDireccion(this.direccion);
  }

}
