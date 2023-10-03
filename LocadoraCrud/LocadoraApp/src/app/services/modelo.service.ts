import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Modelo } from '../models/Modelo';
@Injectable({
    providedIn: 'root'
  })
export class ModeloService {
    private url = `${environment.mainUrlAPI}modelo`;

    constructor(private http: HttpClient) { }

    getModelos(): Observable<Modelo[]> {
        return this.http.get<Modelo[]>(`${this.url}`);
      }
    
    getModelo(nomeModelo: string): Observable<Modelo> {
        return this.http.get<Modelo>(`${this.url}/${nomeModelo}`);
    }
    
    postModelo(modelo: Modelo): Observable<Modelo> {
        return this.http.post<Modelo>(`${this.url}`, modelo);
    }
    
    putModelo(nomeModelo: string, modelo: Modelo): Observable<Modelo> {
        return this.http.put<Modelo>(`${this.url}/${nomeModelo}`, modelo);
    }
    
    deleteModelo(nomeModelo: string): Observable<Modelo> {
        return this.http.delete<Modelo>(`${this.url}/${nomeModelo}`);
    }

}
