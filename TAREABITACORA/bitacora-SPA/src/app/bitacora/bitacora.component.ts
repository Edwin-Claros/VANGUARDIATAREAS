import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ConexionService } from '../conexion.service';
import { AgregarBitacoraModels } from '../Models/Bitacora';

@Component({
  selector: 'app-bitacora',
  templateUrl: './bitacora.component.html',
  styleUrls: ['./bitacora.component.css']
})
export class BitacoraComponent implements OnInit {

  FormularioGuardar: FormGroup;
  obtenerDatosCategory: any;

  constructor(
    private _service: ConexionService,
    private formularioB: FormBuilder,
    ) {
       this.getCategoryServicio();
     }

  ngOnInit() {
    this.FormularioGuardar = this.formularioB.group({
      bitacoraFecha: [''],
      bitacoraHoraInicio: ['', Validators.required],
      bitacoraHoraFinal: ['', Validators.required],
      category_Id: ['', Validators.required],
    });
  }
  onSubmit(ModeloClase: any)
  {
    const agregar = new AgregarBitacoraModels();
    agregar.bitacoraFecha = ModeloClase.bitacoraFecha;
    agregar.bitacoraHoraInicio = ModeloClase.bitacoraHoraInicio;
    agregar.bitacoraHoraFinal = ModeloClase.bitacoraHoraFinal;
    agregar.category_Id = ModeloClase.category_Id;
    this._service.addBitacora(agregar).subscribe(resultado => {
    this.clear();
    },
    error =>
    {
      console.log('Error');
    });
  }


  clear() {
    console.log('clear clicked')
    this.FormularioGuardar.reset();
  }


  getCategoryServicio() {
    this._service.getCategory().subscribe(result => {
    this.obtenerDatosCategory = result;
    },
    error => {
    console.log(JSON.stringify(error));
    });
  }
}
