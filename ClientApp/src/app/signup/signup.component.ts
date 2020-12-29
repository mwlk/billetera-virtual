import { Component } from "@angular/core";
import { FormBuilder, Validators, FormControl } from "@angular/forms";
import { Observable } from "rxjs";
import { Provincia } from "../models/provincia";
import { UbicacionService } from "../services/ubicacion.service";


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
  providers: [UbicacionService]
})

export class SignupComponent {

  public provincias: any;

  emailRepeat = new FormControl('');
  passwordRepeat = new FormControl('');

 /*public provinciaSelected: Provincia = {
    idProvincia: 0,
    nombre: '',
    descripcion: ''
  };
  */
  provinciaSelected = new FormControl('');

  public ciudades: any;

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
      Validators.required])],
    password: ['', Validators.compose([
      Validators.required])],
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
    this.ubicacion.getProvincias().subscribe(rsc => {
      this.provincias = rsc.data;
      //console.log(rsc.data);
    });
  }

  SelectProvincia(id: any): void {
    console.log('ID PROVINCIA ', id)
  }

  signup() {
    
  }

}
