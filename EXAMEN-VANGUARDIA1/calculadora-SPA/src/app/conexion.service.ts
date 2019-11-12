import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ConexionService {

  constructor(private http: HttpClient) { }

  addSuma(suma: any)
  {
    let json = JSON.stringify(suma);
    let headers = new HttpHeaders().set('content-Type', 'application/json');
    return this.http.post("http://localhost:5000/Calculadora/api/Sumar",json,{headers:headers});
  }
  addResta(resta: any)
  {
    let json = JSON.stringify(resta);
    let headers = new HttpHeaders().set('content-Type', 'application/json');
    return this.http.post("http://localhost:5000/Calculadora/api/Restar",json,{headers:headers});
  }
  addRaiz(raiz: any)
  {
    let json = JSON.stringify(raiz);
    let headers = new HttpHeaders().set('content-Type', 'application/json');
    return this.http.post("http://localhost:5000/Calculadora/api/Raiz",json,{headers:headers});
  }
  addMultiplicar(multiplicaar: any)
  {
    let json = JSON.stringify(multiplicaar);
    let headers = new HttpHeaders().set('content-Type', 'application/json');
    return this.http.post("http://localhost:5000/Calculadora/api/Multiplicar",json,{headers:headers});
  }
  addExponencial(exponencial: any)
  {
    let json = JSON.stringify(exponencial);
    let headers = new HttpHeaders().set('content-Type', 'application/json');
    return this.http.post("http://localhost:5000/Calculadora/api/Exponencial",json,{headers:headers});
  }

  addDividir(dividir: any)
  {
    let json = JSON.stringify(dividir);
    let headers = new HttpHeaders().set('content-Type', 'application/json');
    return this.http.post("http://localhost:5000/Calculadora/api/Dividir",json,{headers:headers});
  }
}
