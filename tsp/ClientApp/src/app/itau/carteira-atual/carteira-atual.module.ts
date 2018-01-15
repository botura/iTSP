import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DevExtremeModule } from 'devextreme-angular';

import { CarteiraAtualService } from './carteira-atual.service';
import { CarteiraAtualComponent } from './carteira-atual.component';
import { CarteiraAtualGridComponent } from './carteira-atual-grid/carteira-atual-grid.component';
import { CarteiraAtualPivotComponent } from './carteira-atual-pivot/carteira-atual-pivot.component';
import { CarteiraAtualUfComponent } from './carteira-atual-uf/carteira-atual-uf.component';

@NgModule({
  imports: [
    DevExtremeModule,
    CommonModule,
  ],
  declarations: [
    CarteiraAtualComponent,
    CarteiraAtualGridComponent,
    CarteiraAtualPivotComponent,
    CarteiraAtualUfComponent
  ],
  providers: [
    CarteiraAtualService,
  ]

})

export class CarteriaAtualModule {
}
