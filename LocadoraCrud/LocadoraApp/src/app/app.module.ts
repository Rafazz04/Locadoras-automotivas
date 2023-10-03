import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { LocadorasComponent } from 'src/app/components/locadoras/locadoras.component'
import { ModelosComponent } from 'src/app/components/modelos/modelos.component'
import { MontadorasComponent } from 'src/app/components/montadoras/montadoras.component';
import { VeiculosComponent } from 'src/app/components/veiculos/veiculos.component';
import { LocadoraModelosComponent } from 'src/app/components/relatorios/locadoraModelos/locadoraModelos.component';
import { LocadoraVeiculosComponent } from 'src/app/components/relatorios/locadoraVeiculos/locadoraVeiculos.component';
import { TituloComponent } from 'src/app/components/shared/titulo/titulo.component';
import { NavComponent } from './components/shared/nav/nav.component';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { PaginationModule } from 'ngx-bootstrap/pagination';

@NgModule({
  declarations: [
    AppComponent,
    LocadorasComponent,
    ModelosComponent,
    MontadorasComponent,
    VeiculosComponent,
    TituloComponent,
    NavComponent,
    LocadoraModelosComponent,
    LocadoraVeiculosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ModalModule.forRoot(),
    BsDropdownModule.forRoot(),
    PaginationModule.forRoot(),
    BrowserAnimationsModule,
    NgxSpinnerModule,
    ToastrModule.forRoot({
      timeOut: 3500,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true,
      closeButton: true
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
