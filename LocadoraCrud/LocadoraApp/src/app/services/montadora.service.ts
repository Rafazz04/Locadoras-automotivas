import { Injectable } from '@angular/core';
import { Montadora } from '../models/Montadora';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })
export class MontadoraService {
    private url = `${environment.mainUrlAPI}montadora`;

  constructor(private http: HttpClient) {}

  getMontadoras(): Observable<Montadora[]> {
    return this.http.get<Montadora[]>(`${this.url}`);
  }

  getMontadora(nomeMontadora: string): Observable<Montadora> {
    return this.http.get<Montadora>(`${this.url}/${nomeMontadora}`);
  }

  postMontadora(montadora: Montadora): Observable<Montadora> {
    return this.http.post<Montadora>(`${this.url}`, montadora);
  }

  putMontadora(nomeMontadora: string, montadora: Montadora): Observable<Montadora> {
    return this.http.put<Montadora>(`${this.url}/${nomeMontadora}`, montadora);
  }

  deleteMontadora(nomeMontadora: string): Observable<void> {
    return this.http.delete<void>(`${this.url}/${nomeMontadora}`);
  }

}
