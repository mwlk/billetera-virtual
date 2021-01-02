export interface Cliente {
    nombre: string,
    apellido: string,
    estado: number,
    idDireccion: number,
    nroTelefono: string,
    nroDni: string,
    frontalDni: any,
    traseraDni: any,
    email: string,
    password: string
}

export interface ClienteViewModel {
  nombre: string,
  apellido: string
  nroTelefono: string,
  nroDni: string,
  frontalDni: any,
  traseraDni: any,
  email: string,
  password: string,
  direccion: string,
  alturaCalle: string,
  ciudad: string,
  provincia: string

}
