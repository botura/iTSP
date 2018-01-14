import { NgModule } from '@angular/core';
import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CarteiraAtualComponent } from './carteira-atual/carteira-atual.component';

const cetelemRoutes: Routes = [
    { path: 'cetelem-carteira-atual', component: CarteiraAtualComponent },
];

@NgModule({
    imports: [RouterModule.forChild(cetelemRoutes)],
    exports: [RouterModule]
})

export class CetelemRoutingModule {}