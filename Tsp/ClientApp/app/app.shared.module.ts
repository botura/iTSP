import {
    DxButtonModule,
    DxChartModule,
    DxDataGridModule,
    DxDateBoxModule,
    DxFileUploaderModule,
    DxLoadPanelModule,
    DxTabPanelModule,
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
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'rec-ass', component: RecAssComponent },
            { path: 'importar', component: ImportComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
