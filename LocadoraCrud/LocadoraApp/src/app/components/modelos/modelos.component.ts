import { Component, OnInit } from '@angular/core';
import { Modelo } from 'src/app/models/Modelo';
import { ModeloService } from 'src/app/services/modelo.service';

@Component({
  selector: 'app-modelos',
  templateUrl: './modelos.component.html',
  styleUrls: ['./modelos.component.css']
})
export class ModelosComponent implements OnInit {
  public titulo = 'Lista de Modelos'
  public modelos: Modelo[] = [];

  constructor(private modeloService: ModeloService) { }

  ngOnInit(): void {
    this.carregarModelos();
  }

  carregarModelos(): void {
    this.modeloService.getModelos().subscribe((modelos) => {
      this.modelos = modelos;
    });
  }

}
