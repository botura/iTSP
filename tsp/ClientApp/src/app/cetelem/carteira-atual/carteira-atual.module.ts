import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DxChartModule, DxDataGridModule, DxPivotGridModule, DxTabPanelModule, DxLoadPanelModule } from 'devextreme-angular';

import { CarteiraAtualService } from './carteira-atual.service';
import { CarteiraAtualComponent } from './carteira-atual.component';
import { CarteiraAtualGridComponent } from './carteira-atual-grid/carteira-atual-grid.component';
import { CarteiraAtualUfComponent } from './carteira-atual-uf/carteira-atual-uf.component';
import { CarteiraAtualPivotComponent } from './carteira-atual-pivot/carteira-atual-pivot.component';

@NgModule({
  imports: [
    DxTabPanelModule,
    DxLoadPanelModule,
    DxChartModule,
    DxDataGridModule,
    DxPivotGridModule,
    CommonModule,
  ],
  declarations: [
    CarteiraAtualComponent,
    CarteiraAtualGridComponent,
    CarteiraAtualUfComponent,
    CarteiraAtualPivotComponent
  ],
  providers: [
    CarteiraAtualService,
  ]
})

export class CarteiraAtualModule { }
