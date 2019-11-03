import { Component, OnInit } from '@angular/core';
import { ConexionService } from '../conexion.service';

@Component({
  selector: 'app-reporte',
  templateUrl: './reporte.component.html',
  styleUrls: ['./reporte.component.css']
})
export class ReporteComponent implements OnInit {

  obtenerDatosBitacora: any;
  getFecha1: any;
  getFecha2: any;
  
  constructor( private _service: ConexionService,) { }

  ngOnInit() {
  }

  getReposteBitacoraRango(fecha1: any, fecha2: any){
    this._service.getBitacoraRango(fecha1, fecha2).subscribe(result => {
      this.obtenerDatosBitacora = result;
        },
        error => {
      console.log(JSON.stringify(error));
        });
  }

  CambioFecha1(){
    alert(this.getFecha1);
  }

  CambioFecha2(){
    alert(this.getFecha2);
  }
}
