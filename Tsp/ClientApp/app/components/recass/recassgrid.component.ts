import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { DxDataGridModule } from 'devextreme-angular';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
    selector: 'rec-ass-grid',
    templateUrl: './recassgrid.component.html',
})

export class RecAssGridComponent implements OnInit {
    private baseUrl: string;
    private http: Http;
    public queryResult: any = [];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    ngOnInit() {
        this.populateGrid();
    }

    populateGrid() {
        console.log('Inicio api/recass/grid:');
        this.queryResult = null;

        this.http.get(this.baseUrl + 'api/rec_ass/grid').subscribe(result => {
            this.queryResult = result.json();
            console.log('Fim api/recass/grid');
        }, error => console.error(error));
    }

    resetFiltro(dt: any) {
        this.populateGrid();
        dt.reset();
        // this.messageService.add({ severity: 'info', summary: '', detail: 'Filtro resetado<br>Dados atualizados' });
    }

    customizeColumns(columns: any) {
        // columns[0].width = 70;
    }

    onContentReady(e: any) {
        e.component.option('loadPanel.enabled', false);
    }
}
