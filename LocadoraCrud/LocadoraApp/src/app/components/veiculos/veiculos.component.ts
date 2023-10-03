import { Component, OnInit } from '@angular/core';
import { Veiculo } from 'src/app/models/Veiculo';
import { VeiculoService } from 'src/app/services/veiculo.service';

@Component({
  selector: 'app-veiculos',
  templateUrl: './veiculos.component.html',
  styleUrls: ['./veiculos.component.css']
})
export class VeiculosComponent implements OnInit {
  public veiculos: Veiculo[] = [];
  public titulo = 'Lista de Veículos';

  constructor(private veiculoService: VeiculoService) { }

  ngOnInit() {
    this.carregarVeiculos();
  }

  carregarVeiculos(): void {
    this.veiculoService.getVeiculos().subscribe((veiculos) => {
      this.veiculos = veiculos;
    });
  }
}
