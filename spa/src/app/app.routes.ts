import { RecAssComponent } from './rec_ass/rec_ass.component';
import { ImportarComponent } from './rec_ass/importar/importar.component';
import { ContacorrenteFormReactiveComponent } from './contacorrente/contacorrente-form-reactive.component';
import { ContacorrenteFormComponent } from './contacorrente/contacorrente-form.component';
import { ContacorrenteComponent } from './contacorrente/contacorrente.component';
import {Routes, RouterModule} from '@angular/router';
import {ModuleWithProviders} from '@angular/core';
import {DashboardComponent} from './demo/view/dashboard.component';
import {SampleDemoComponent} from './demo/view/sampledemo.component';
import {FormsDemoComponent} from './demo/view/formsdemo.component';
import {DataDemoComponent} from './demo/view/datademo.component';
import {PanelsDemoComponent} from './demo/view/panelsdemo.component';
import {OverlaysDemoComponent} from './demo/view/overlaysdemo.component';
import {MenusDemoComponent} from './demo/view/menusdemo.component';
import {MessagesDemoComponent} from './demo/view/messagesdemo.component';
import {MiscDemoComponent} from './demo/view/miscdemo.component';
import {EmptyDemoComponent} from './demo/view/emptydemo.component';
import {ChartsDemoComponent} from './demo/view/chartsdemo.component';
import {FileDemoComponent} from './demo/view/filedemo.component';
import {UtilsDemoComponent} from './demo/view/utilsdemo.component';
import {DocumentationComponent} from './demo/view/documentation.component';
import { PessoaComponent } from './pessoa/pessoa.component';

export const routes: Routes = [
    {path: '', component: DashboardComponent},
    {path: 'sample', component: SampleDemoComponent},
    {path: 'forms', component: FormsDemoComponent},
    {path: 'data', component: DataDemoComponent},
    {path: 'panels', component: PanelsDemoComponent},
    {path: 'overlays', component: OverlaysDemoComponent},
    {path: 'menus', component: MenusDemoComponent},
    {path: 'messages', component: MessagesDemoComponent},
    {path: 'misc', component: MiscDemoComponent},
    {path: 'empty', component: EmptyDemoComponent},
    {path: 'charts', component: ChartsDemoComponent},
    {path: 'file', component: FileDemoComponent},
    {path: 'utils', component: UtilsDemoComponent},
    {path: 'documentation', component: DocumentationComponent},
    {path: 'contacorrente', component: ContacorrenteComponent},
    // {path: 'contacorrente/new', component: ContacorrenteFormComponent},
    // {path: 'contacorrente/detail/:id', component: ContacorrenteFormComponent}
    {path: 'teste/:id', component: ContacorrenteFormReactiveComponent},
    {path: 'pessoa', component: PessoaComponent},
    {path: 'rec_ass/importar', component: ImportarComponent},
    {path: 'rec_ass/grid', component: RecAssComponent}
];

export const AppRoutes: ModuleWithProviders = RouterModule.forRoot(routes);
