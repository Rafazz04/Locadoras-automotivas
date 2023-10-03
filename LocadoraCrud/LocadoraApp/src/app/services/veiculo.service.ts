import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Veiculo } from '../models/Veiculo';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
  })
export class VeiculoService {
private url = `${environment.mainUrlAPI}veiculo`;

constructor(private http: HttpClient) {}

getVeiculos(): Observable<Veiculo[]> {
    return this.http.get<Veiculo[]>(`${this.url}`);
}

getVeiculo(placa: string, chassi: string): Observable<Veiculo> {
    return this.http.get<Veiculo>(`${this.url}/${placa}/${chassi}`);
}

postVeiculo(veiculo: Veiculo): Observable<Veiculo> {
    return this.http.post<Veiculo>(`${this.url}`, veiculo);
}

putVeiculo(placa: string, chassi: string, veiculo: Veiculo): Observable<Veiculo> {
    return this.http.put<Veiculo>(`${this.url}/${placa}/${chassi}`, veiculo);
}

deleteVeiculo(placa: string, chassi: string): Observable<void> {
    return this.http.delete<void>(`${this.url}/${placa}/${chassi}`);
}

}
