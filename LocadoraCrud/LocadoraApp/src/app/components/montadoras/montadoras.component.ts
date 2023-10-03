import { Component, OnInit } from '@angular/core';
import { Montadora } from 'src/app/models/Montadora';
import { MontadoraService } from 'src/app/services/montadora.service';

@Component({
  selector: 'app-montadoras',
  templateUrl: './montadoras.component.html',
  styleUrls: ['./montadoras.component.css']
})
export class MontadorasComponent implements OnInit {
  montadoras: Montadora[] = [];
  public titulo = 'Lista das Montadoras'

  constructor(private montadoraService: MontadoraService) { }

  ngOnInit(): void {
    this.carregarMontadoras();
  }

  carregarMontadoras(): void {
    this.montadoraService.getMontadoras().subscribe((montadoras) => {
      this.montadoras = montadoras;
    });
  }


}
