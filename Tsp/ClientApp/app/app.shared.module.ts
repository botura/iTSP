import { RecAssComponent } from './components/recass/recass.component';
import { RecAssService } from '../services/rec_ass.service';
import { AppErrorHandler } from './common/app.error-handler';
import { ErrorHandler, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { DxDataGridModule } from 'devextreme-angular';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        RecAssComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        DxDataGridModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'rec-ass', component: RecAssComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],

    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        RecAssService,
    ],
})
export class AppModuleShared {
}
