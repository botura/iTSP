import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CetelemRoutingModule } from './cetelem.routing.module';
import { CarteiraAtualModule } from './carteira-atual/carteira-atual.module';

@NgModule({
  imports: [
    CommonModule,
    CetelemRoutingModule,
    CarteiraAtualModule
  ],
  declarations: [
  ],
  providers: [
  ]
})

export class CetelemModule { }
