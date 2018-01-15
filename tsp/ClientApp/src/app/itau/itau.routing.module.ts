import { NgModule } from '@angular/core';
import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CarteiraAtualComponent } from './carteira-atual/carteira-atual.component';
import { RecebimentoComponent } from './recebimento/recebimento.component';

const itauRoutes: Routes = [
    { path: 'itau-carteira-atual', component: CarteiraAtualComponent },
    { path: 'itau-recebimento', component: RecebimentoComponent },
];

@NgModule({
    imports: [RouterModule.forChild(itauRoutes)],
    exports: [RouterModule]
})

export class RoutingModule {}
