import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormsModule } from '@angular/forms';
import { Cuenta } from '../models/cuenta';
import { OperacionService } from 'src/app/services/operacion.service';
import { RedireccionService } from 'src/app/services/redireccion.service';
import { CuentaService } from '../../services/cuenta.service';
import { NgbModal } from '../ap';


       
@Component({
   selector: 'ingreso-egreso-dinero-component',
   templateUrl: './reti.html',
   //styleUrls: ['./pantalla-retiro-ingreso-dinero.component.css']
})

export class IngresoEgresoDinero implements OnInit {

    constructor(private modalService: NgbModal,
        private redireccionar: RedireccionService,
        private operacionService: OperacionService,
        private fb: FormBuilder,
        private cuentaService: CuentaService) { }

    //esta cuenta, se carga automaticamente cuando se abre la ventana
    //@Input()
    cuentaOrigen: Cuenta
    cvuIngresado: string;
    formRetiroDinero: FormGroup;
    formDinero: FormGroup;

    tiposOperaciones: Array<string> = ['Deposito', 'Extraccion'];
    isSubmitted = false;
    labelBotonCuenta = 'Ver datos de cuenta';
    verDatosCuenta = true;


    public buscarCuenta() {

        this.cuentaOrigen.Cvu = "cargando datos"
        this.cuentaOrigen.Saldo = 0
        this.cuentaOrigen.NombreUsuario = ""

        this.cuentaService.obtenerCuenta(this.inputCVU.value).subscribe(
            cuenta => {
                this.cuentaOrigen = cuenta;
            }, err => {
                this.cuentaOrigen.NombreUsuario = err.error
            }, () => {
            }
        )
    }



    public realizarOperacion() {
        //validacion si no cargo monto 
        if (this.inputMonto.value <= 0 || this.inputMonto == null) {
            alert("error: ingrese un monto valido")
            return;
        }
        // OPCION DEPOSITO
        if (this.selectorTipoOperacion.value == "Deposito") {
            this.operacionService.realizarDeposito(this.cuentaOrigen.cvu, this.inputMonto.value).subscribe(
                x => {
                    this.redireccionar.exito();
                    this.modalService.dismissAll();
                },
                err => {
                    console.log(err);
                    alert(err.error);

                }
            );
            return;
        }
        //  OPCION EXTRACCION
        if (this.selectorTipoOperacion.value == "Extraccion") {
            this.operacionService.realizarExtraccion(this.cuentaOrigen.Cvu, this.inputMonto.value).subscribe(
                x => {
                    console.log("Extraccion realizado exitosamente");
                    this.redireccionar.exito();
                    this.modalService.dismissAll()
                },
                err => {
                    alert(err.error);

                }
            );
            return;
        }
        alert("error: seleccione un tipo de operacion")
    }

    ngOnInit(): void {

        this.cuentaOrigen = new Cuenta()

        this.cuentaOrigen.Cvu = ""
        this.cuentaOrigen.Saldo = 0
        this.cuentaOrigen.NombreUsuario = ""

        this.cuentaService.obtenerCuentasUsuario().subscribe(
            cuenta => {
                this.cuentaOrigen = cuenta[0];
                this.cvuIngresado = this.cuentaOrigen.Cvu
            }, err => {
            }, () => {

            }
        )

        // VALIDACION DEL MONTO
        this.formDinero = this.fb.group({
            inputCVU: ['', [Validators.required], [Validators.maxLength(22)], [Validators.minLength(22)]],
            selectorTipoOperacion: ['', [Validators.required]],
            Monto: ['', [Validators.required, Validators.pattern("^[0-9]{1,8}$")]]
        })
    }


    //
    get selectorTipoOperacion() {
        return this.formDinero.get('selectorTipoOperacion');
    }

    get inputMonto() {
        return this.formDinero.get('Monto');
    }

    get inputCVU() {
        return this.formDinero.get('inputCVU');
    }
    //
    public changeCuenta(e) {

        this.selectorTipoOperacion.setValue(e.target.value, {
            onlySelf: true
        })
    }
    //
    onSubmit() {
        console.log(JSON.stringify(this.selectorTipoOperacion.value))
    }

    public LimpiarForm() {
        this.formDinero.reset();
    }

    public verCuenta() {


        this.verDatosCuenta = !this.verDatosCuenta;
        if (this.verDatosCuenta == true) {
            this.labelBotonCuenta = 'Esconder datos de cuenta';
        }
        else {
            this.labelBotonCuenta = 'Ver datos de cuenta';
        }

    }

}
