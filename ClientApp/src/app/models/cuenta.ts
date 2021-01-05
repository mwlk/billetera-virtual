export interface Cuenta {
  cvu: string;
  estado: number;
  fechaAlta: string;
  idCliente: number;
  idCuenta: number
  idEntidadBancaria: number;
  idTipoMoneda: number;
  nombreBanco: string;
  nombreCliente: string;
  saldo: number;
  tipoMoneda: string;
  topeDescubierto: number;
}
