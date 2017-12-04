import {
    DxChartModule,
    DxDataGridModule,
    DxPieChartModule,
    DxTabPanelModule,
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
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        DxDataGridModule,
        DxPieChartModule,
        DxTabPanelModule,
        DxChartModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'rec-ass', component: RecAssComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
