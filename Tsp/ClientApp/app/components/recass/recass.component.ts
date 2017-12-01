import { RecAssService } from '../../../services/rec_ass.service';
import { BoundCallbackObservable } from 'rxjs/observable/BoundCallbackObservable';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { DxDataGridModule } from 'devextreme-angular';

@Component({
    selector: 'rec-ass',
    templateUrl: './recass.component.html',
    // styleUrls: ['./rec_ass.component.scss'],
    encapsulation: ViewEncapsulation.None
})

export class RecAssComponent implements OnInit {
    queryResult: any = [];

    constructor(private RecAssService: RecAssService) {
    }

    ngOnInit() {
        this.populateGrid();
    }

    populateGrid() {
        console.log('Inicio getGrid');
        this.RecAssService.getGrid()
            .subscribe(result => {
                this.queryResult = result;
                console.log('Fim getGrid');
            });
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
