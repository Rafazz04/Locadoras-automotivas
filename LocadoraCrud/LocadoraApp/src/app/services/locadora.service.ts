import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import{Locadora} from '../models/Locadora'
import { environment } from 'src/environments/environment';
@Injectable({
    providedIn: 'root'
  })
export class LocadoraService {
    private url = `${environment.mainUrlAPI}locadora`;

    constructor(private http: HttpClient) { }

    getLocadoras(): Observable<Locadora[]> {
        return this.http.get<Locadora[]>(`${this.url}`);
    }
    
    getLocadora(cnpj: string): Observable<Locadora> {
        return this.http.get<Locadora>(`${this.url}/${cnpj}`);
    }

    postLocadora(locadoraDto: Locadora): Observable<Locadora> {
        return this.http.post<Locadora>(`${this.url}`, locadoraDto);
    }
    
    putLocadora(cnpj: string, locadoraDto: Locadora): Observable<Locadora> {
        return this.http.put<Locadora>(`${this.url}/${cnpj}`, locadoraDto);
    }
    
    deleteLocadora(cnpj: string): Observable<any> {
        return this.http.delete(`${this.url}/${cnpj}`);
    }

}
