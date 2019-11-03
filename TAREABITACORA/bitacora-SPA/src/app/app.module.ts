import {RouterModule, Routes} from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ConexionService } from './conexion.service';
import { BitacoraComponent } from './bitacora/bitacora.component';
import { EncabezadoComponent } from './encabezado/encabezado.component';
import { ReporteComponent } from './reporte/reporte.component';
import {HttpClientModule} from '@angular/common/http';


const routes: Routes = [
  { path: 'bitacora', component: BitacoraComponent },
  { path: 'reporte', component: ReporteComponent },
  { path: '', component: BitacoraComponent, pathMatch: 'full' },
  { path: '**', redirectTo: '/', pathMatch: 'full' }
];

@NgModule({
  declarations:
  [
    AppComponent,
    BitacoraComponent,
    EncabezadoComponent,
    ReporteComponent
  ],
  imports:
  [
    BrowserModule,
    RouterModule.forRoot(routes),
    FormsModule, ReactiveFormsModule,
    HttpClientModule,
  ],
  providers:
  [
    ConexionService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
