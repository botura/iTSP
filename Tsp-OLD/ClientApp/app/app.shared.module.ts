import { CetelemRecebimentoPivotComponent } from './components/cetelem/carteiraatual/recebimento.pivot.component';
import { CetelemRecebimentoGridComponent } from './components/cetelem/carteiraatual/recebimento.grid.component';
import { CetelemRecebimentoUfComponent } from './components/cetelem/carteiraatual/recebimento.uf.component';
import { CetelemCarteiraAtualComponent } from './components/cetelem/carteiraatual/carteiraatual.component';
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
import { NgModule, LOCALE_ID } from '@angular/core';
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
        CetelemCarteiraAtualComponent,
        CetelemRecebimentoUfComponent,
        CetelemRecebimentoGridComponent,
        CetelemRecebimentoPivotComponent,
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
            { path: 'cetelem-carteiraatual', component: CetelemCarteiraAtualComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        { provide: LOCALE_ID, useValue: 'pt-BR' }
    ]
})
export class AppModuleShared {
}
