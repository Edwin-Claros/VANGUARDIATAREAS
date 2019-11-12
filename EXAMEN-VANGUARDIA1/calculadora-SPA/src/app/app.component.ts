import { Component, OnInit } from '@angular/core';
import { ConexionService } from './conexion.service';
import { SumarModels } from './Models/Sumar';
import { RestarModels } from './Models/Restar';
import { DividirModels } from './Models/Dividir';
import { MultiplicarModels } from './Models/Multiplicar';
import { ExponencialModels } from './Models/Exponencial';
import { RaizModels } from './Models/Raiz';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

completo = '';
  constructor(private _service: ConexionService) {
  }

  ngOnInit() {
  }
  subText = '';
  mainText = '';
  operand1: number;
  operand2: number;
  operador3:number;
  operator = '';
  calculationString = '';
  answered = false;
  operatorSet = false;

  pressKey(key: string) {
    if (key === '/' || key === 'x' || key === '-' || key === '+') {
      const lastKey = this.mainText[this.mainText.length - 1];
      if (lastKey === '/' || lastKey === 'x' || lastKey === '-' || lastKey === '+')  {
        this.operatorSet = true;
      }
      if ((this.operatorSet) || (this.mainText === '')) {
        return;
      }
      this.operand1 = parseFloat(this.mainText);
      this.operator = key;
      Math.sqrt(this.operador3);
      this.operatorSet = true;
    }
    if (this.mainText.length === 10) {
      return;
    }
    this.mainText += key;
  }

  allClear() {
    this.mainText = '';
    this.subText = '';
    this.operatorSet = false;
  }


  AddSuma(ModeloClase: any){
      const agregar = new  SumarModels();
      agregar.sumarHistorico = ModeloClase;
      this._service.addSuma(agregar).subscribe(resultado => {

      },
      error =>{
        console.log('Error');
      });
  }

  AddResta(ModeloClase: any){
    const agregar = new  RestarModels();
    agregar.restarlHistorico = ModeloClase;
    this._service.addResta(agregar).subscribe(resultado => {

    },
    error =>{
      console.log('Error');
    });
}

AddDividir(ModeloClase: any){
  const agregar = new  DividirModels();
  agregar.dividirHistorico = ModeloClase;
  this._service.addDividir(agregar).subscribe(resultado => {

  },
  error =>{
    console.log('Error');
  });
}

AddMultiplicar(ModeloClase: any){
  const agregar = new  MultiplicarModels();
  agregar.multiplicarHistorico = ModeloClase;
  this._service.addMultiplicar(agregar).subscribe(resultado => {

  },
  error =>{
    console.log('Error');
  });
}

AddExponencial(ModeloClase: any){
  const agregar = new  ExponencialModels();
  agregar.exponencialHistorico = ModeloClase;
  this._service.addExponencial(agregar).subscribe(resultado => {

  },
  error =>{
    console.log('Error');
  });
}

AddRaiz(ModeloClase: any){
  const agregar = new  RaizModels();
  agregar.raizHistorico = ModeloClase;
  this._service.addRaiz(agregar).subscribe(resultado => {

  },
  error =>{
    console.log('Error');
  });
}

  getAnswer() {
    this.calculationString = this.mainText;
    this.operand2 = parseFloat(this.mainText.split(this.operator)[1]);
    if (this.operator === '/') {
      this.subText = this.mainText;
      this.mainText = (this.operand1 / this.operand2).toString();
      this.subText = this.calculationString;
      if (this.mainText.length > 9) {
        this.mainText = this.mainText.substr(0, 9);
      }
      this.completo=this.subText+" = "+this.mainText;
      this.AddDividir(this.completo);


    } else if (this.operator === 'x') {
      this.subText = this.mainText;
      this.mainText = (this.operand1 * this.operand2).toString();
      this.subText = this.calculationString;
      if (this.mainText.length > 9) {
        this.mainText = 'ERROR';
        this.subText = 'Range Exceeded';
      }
      this.completo=this.subText+" = "+this.mainText;
      this.AddMultiplicar(this.completo);

    } else if (this.operator === '-') {
      this.subText = this.mainText;
      this.mainText = (this.operand1 - this.operand2).toString();
      this.subText = this.calculationString;
      this.completo=this.subText+" = "+this.mainText;
      this.AddResta(this.completo);

    }  else if (this.operator === '') {
      this.subText = this.mainText;
      this.mainText = (this.operador3).toString();
      this.subText = this.calculationString;
      this.completo=this.subText+" = "+this.mainText;
      this.AddRaiz(this.completo);

    }else if (this.operator === '+') {
      this.subText = this.mainText;
      this.mainText = (this.operand1 + this.operand2).toString();
      this.subText = this.calculationString;
      if (this.mainText.length > 9) {
        this.mainText = 'ERROR';
        this.subText = 'Range Exceeded';
      }
      this.completo=this.subText+" = "+this.mainText;
      this.AddSuma(this.completo);

    } else {
      this.subText = 'ERROR: Invalid Operation';
    }
    this.answered = true;
  }
}
