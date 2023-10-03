import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LocadorasComponent } from 'src/app/components/locadoras/locadoras.component'
import { ModelosComponent } from 'src/app/components/modelos/modelos.component'
import { MontadorasComponent } from 'src/app/components/montadoras/montadoras.component';
import { VeiculosComponent } from 'src/app/components/veiculos/veiculos.component';
import { LocadoraModelosComponent } from 'src/app/components/relatorios/locadoraModelos/locadoraModelos.component';
import { LocadoraVeiculosComponent } from 'src/app/components/relatorios/locadoraVeiculos/locadoraVeiculos.component';
import { TituloComponent } from 'src/app/components/shared/titulo/titulo.component';

const routes: Routes = [
  {path: 'locadora', component: LocadorasComponent},
  {path: '', redirectTo:'locadora,',pathMatch:'full'},
  {path: 'modelo', component: ModelosComponent},
  {path: 'montadora', component: MontadorasComponent},
  {path: 'veiculo', component: VeiculosComponent},
  {path:'locadoraModelos', component: LocadoraModelosComponent},
  {path: 'locadoraVeiculos', component: LocadoraVeiculosComponent},
  {path: 'titulo', component: TituloComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
