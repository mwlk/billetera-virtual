import { Component } from "@angular/core";
import { FormBuilder, Validators } from "@angular/forms";


@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})

export class SignupComponent {

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
    emailRepeat: ['', Validators.compose([
      Validators.required])],
    password: ['', Validators.compose([
      Validators.required])],
    passwordRepeat: ['', Validators.compose([
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

  constructor(private builder: FormBuilder) {

  }

  signup() {

  }
}
