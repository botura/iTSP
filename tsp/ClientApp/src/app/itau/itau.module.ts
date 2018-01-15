import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RoutingModule } from './itau.routing.module';
import { CarteriaAtualModule } from './carteira-atual/carteira-atual.module';
import { RecebimentoModule } from './recebimento/recebimento.module';

@NgModule({
  imports: [
    CommonModule,
    RoutingModule,
    CarteriaAtualModule,
    RecebimentoModule
  ],
  declarations: [
  ],
  providers: [
  ]

})

export class ItauModule {
}
