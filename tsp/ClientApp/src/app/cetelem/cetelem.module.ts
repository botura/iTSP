import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DxChartModule, DxDataGridModule, DxPivotGridModule, DxTabPanelModule, DxLoadPanelModule } from 'devextreme-angular';

import { CetelemRoutingModule } from './cetelem.routing.module';
import { CetelemService } from './cetelem.service';
import { CarteiraAtualComponent } from './carteira-atual/carteira-atual.component';
import { CarteiraAtualGridComponent } from './carteira-atual/carteira-atual-grid/carteira-atual-grid.component';
import { CarteiraAtualUfComponent } from './carteira-atual/carteira-atual-uf/carteira-atual-uf.component';
import { CarteiraAtualPivotComponent } from './carteira-atual/carteira-atual-pivot/carteira-atual-pivot.component';

@NgModule({
  imports: [
    DxTabPanelModule,
    DxLoadPanelModule,
    DxChartModule,
    DxDataGridModule,
    DxPivotGridModule,
    CommonModule,
    CetelemRoutingModule
  ],
  declarations: [
    CarteiraAtualComponent,
    CarteiraAtualGridComponent,
    CarteiraAtualUfComponent,
    CarteiraAtualPivotComponent
  ],
  providers: [
    CetelemService,
  ]
})

export class CetelemModule { }
