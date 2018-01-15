import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DevExtremeModule } from 'devextreme-angular';

import { RecebimentoService } from './recebimento.service';
import { RecebimentoComponent } from './recebimento.component';
import { RecebimentoDataComponent } from './recebimento-data/recebimento-data.component';
import { RecebimentoUfComponent } from './recebimento-uf/recebimento-uf.component';
import { RecebimentoGridComponent } from './recebimento-grid/recebimento-grid.component';
import { RecebimentoPivotComponent } from './recebimento-pivot/recebimento-pivot.component';


@NgModule({
  imports: [
    DevExtremeModule,
    CommonModule,
  ],
  declarations: [
    RecebimentoComponent,
    RecebimentoDataComponent,
    RecebimentoUfComponent,
    RecebimentoGridComponent,
    RecebimentoPivotComponent,
  ],
  providers: [
    RecebimentoService
  ]

})

export class RecebimentoModule {
}
