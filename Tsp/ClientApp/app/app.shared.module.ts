import { CurrencyPipe } from '@angular/common/src/pipes/number_pipe';
import { ItauCarteiraAtualUfComponent } from './components/itau/carteiraatual/carteiraatual.uf.component';
import { ItauCarteiraAtualComponent } from './components/itau/carteiraatual/carteiraatual.component';
import {
    DxButtonModule,
    DxChartModule,
    DxDataGridModule,
    DxDateBoxModule,
    DxFileUploaderModule,
    DxLoadPanelModule,
    DxPivotGridModule,
    DxTabPanelModule,
    DxTagBoxModule,
    DxToolbarModule,
} from 'devextreme-angular';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { RecAssComponent } from './components/recass/recass.component';
import { RecAssGridComponent } from './components/recass/recassgrid.component';
import { RecAssProdutoComponent } from './components/recass/recassproduto.component';
import { RecAssUfComponent } from './components/recass/recassuf.component';
import { RecAssDataPagtoComponent } from './components/recass/recassdatapagto.component';
import { ImportComponent } from './components/import/import.component';
import { ImportRecAssComponent } from './components/import/import.recass.component';
import { ItauCarteiraAtualEntidadeComponent } from './components/itau/carteiraatual/carteiraatual.entidade.component';
import { ItauCarteiraAtualGridComponent } from './components/itau/carteiraatual/carteiraatual.grid.component';
import { ItauCarteiraAtualPivotComponent } from './components/itau/carteiraatual/carteiraatual.pivot.component';
import { ItauRecebimentoComponent } from './components/itau/recebimento/recebimento.component';
import { ItauRecebimentoGridComponent } from './components/itau/recebimento/recebimento.grid.component';
import { ItauRecebimentoPivotComponent } from './components/itau/recebimento/recebimento.pivot.component';
import { ItauRecebimentoUfComponent } from './components/itau/recebimento/recebimento.uf.component';
import { ItauRecebimentoProdutoComponent } from './components/itau/recebimento/recebimento.produto.component';
import { ItauRecebimentoDataComponent } from './components/itau/recebimento/recebimento.data.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        RecAssComponent,
        RecAssGridComponent,
        RecAssUfComponent,
        RecAssProdutoComponent,
        RecAssDataPagtoComponent,
        ImportComponent,
        ImportRecAssComponent,
        ItauCarteiraAtualComponent,
        ItauCarteiraAtualUfComponent,
        ItauCarteiraAtualEntidadeComponent,
        ItauCarteiraAtualGridComponent,
        ItauCarteiraAtualPivotComponent,
        ItauRecebimentoComponent,
        ItauRecebimentoGridComponent,
        ItauRecebimentoPivotComponent,
        ItauRecebimentoUfComponent,
        ItauRecebimentoProdutoComponent,
        ItauRecebimentoDataComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        DxDataGridModule,
        DxTabPanelModule,
        DxChartModule,
        DxFileUploaderModule,
        DxDateBoxModule,
        DxButtonModule,
        DxToolbarModule,
        DxLoadPanelModule,
        DxTagBoxModule,
        DxPivotGridModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'rec-ass', component: RecAssComponent },
            { path: 'importar', component: ImportComponent },
            { path: 'itau-carteiraatual', component: ItauCarteiraAtualComponent },
            { path: 'itau-recebimento', component: ItauRecebimentoComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
})
export class AppModuleShared {
}
