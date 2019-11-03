import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConexionService {

  constructor(private http: HttpClient, ) {}

  getCategory(): Observable<any> {return this.http.get('http://localhost:5000/api/Category'); }
  getBitacora(): Observable<any> {return this.http.get('http://localhost:5000/api/Bitacora'); }

  getBitacoraRango(Rango1: string, Rango2: string) {
    return this.http.get(`http://localhost:5000/api/Bitacora/${Rango1}/${Rango2}`);
  }

  addCategory(category: any)
  {
    let json = JSON.stringify(category);
    let headers = new HttpHeaders().set('content-Type', 'application/json');
    return this.http.post("http://localhost:5000/api/Category",json,{headers:headers});
  }
  
  addBitacora(bitacora: any)
  {
    let json = JSON.stringify(bitacora);
    let headers = new HttpHeaders().set('content-Type', 'application/json');
  
    return this.http.post("http://localhost:5000/api/Bitacora",json,{headers:headers});
  }


}
