import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { Locadora } from 'src/app/models/Locadora';
import { LocadoraService } from 'src/app/services/locadora.service';
import { takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-locadoras',
  templateUrl: './locadoras.component.html',
  styleUrls: ['./locadoras.component.css']
})
export class LocadorasComponent implements OnInit {

  public locadoras: Locadora[] = [];
  public locadora: Locadora = new Locadora;
  public locadoraForm: FormGroup = new FormGroup({});
  public titulo = 'Lista das locadoras'
  public locadoraSelecionada: Locadora | null = null;
  public modeSave = 'post'
  private unsubscriber: Subject<void> = new Subject<void>();

  constructor(
    private locadoraService: LocadoraService, 
    private fb: FormBuilder,   
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) {
      this.criarForm();
    }

  ngOnInit(): void {
    this.carregarLocadoras();
  }

  carregarLocadoras(): void {
    this.locadoraService.getLocadoras().subscribe((locadoras) => {
      this.locadoras = locadoras;
    });
  }

  criarForm(): void {
    this.locadoraForm = this.fb.group({
      id: [0],
      nomeFantasia: ['', Validators.required],
      razaoSocial: ['', Validators.required],
      cnpj: ['', Validators.required],
      email: ['', Validators.email],
      telefone: ['', Validators.required],
      cep: ['', Validators.required],
      rua: ['', Validators.required],
      numero: ['', Validators.required],
      bairro: ['', Validators.required],
      estado: ['', Validators.required],
      cidade: ['', Validators.required],
    });
  }

  saveLocadora(): void {
    if (this.locadoraForm.valid) {
      const locadoraDto: Locadora = this.locadoraForm.value;

      this.locadoraService.postLocadora(locadoraDto).subscribe(
        () => {
          this.toastr.success('Locadora salva com sucesso!');
        },
        (error) => {
          this.toastr.error(`Erro: Locadora não pode ser salva!`);
          console.error(error);
          this.spinner.hide();
        },
        () => this.spinner.hide()
      );
    }
  }

  locadoraSelect(locadoraCnpj : string) : void {
    this.modeSave ='patch';
    this.locadoraService.getLocadora(locadoraCnpj).subscribe(
      (locadoraReturn) => {
          this.locadoraSelecionada = locadoraReturn
          this.locadoraForm.patchValue(this.locadoraSelecionada)
      },
      (error) => {
        this.toastr.error('Locadoras não carregadas!');
        console.error(error);
        this.spinner.hide();
      },
      () => this.spinner.hide()
    );
  }
  voltar(): void {
    this.locadoraSelecionada = null
  }

  Adicionar(): void{
    this.locadoraSelecionada = this.locadora
  }

  ngOnDestroy(): void {
    this.unsubscriber.next();
    this.unsubscriber.complete();
  }
}
