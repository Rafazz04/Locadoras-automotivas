import { Component, OnInit } from '@angular/core';
import { RelatorioLocadoraModelo } from 'src/app/models/RelatorioLocadoraModelo';
import { RelatorioService } from 'src/app/services/relatorio.service';

@Component({
  selector: 'app-locadoraModelos',
  templateUrl: './locadoraModelos.component.html',
  styleUrls: ['./locadoraModelos.component.css']
})
export class LocadoraModelosComponent implements OnInit {
  public relatorioLocadoraModelos: RelatorioLocadoraModelo[] = [];
  public titulo = 'Relatórios das Locadoras e Modelos';

  constructor(private relatorioLocadoraModeloService: RelatorioService) { }

  ngOnInit() {
    this.carregarRelatorioLocadoraModelo();
  }

  carregarRelatorioLocadoraModelo(): void {
    this.relatorioLocadoraModeloService.getRelatorioLocadoraModelo().subscribe((relatorioLocadoraModelos) => {
      this.relatorioLocadoraModelos = this.relatorioLocadoraModelos;
    });
  }

}
