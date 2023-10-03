import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RelatorioLocadoraModelo } from '../models/RelatorioLocadoraModelo';

@Injectable({
    providedIn: 'root'
  })
export class RelatorioService {
    private url = `${environment.mainUrlAPI}Relatorios`;

    constructor(private http: HttpClient) { }
  
    getRelatorioLocadoraModelo(): Observable<RelatorioLocadoraModelo[]> {
      return this.http.get<RelatorioLocadoraModelo[]>(this.url);
    }

}
