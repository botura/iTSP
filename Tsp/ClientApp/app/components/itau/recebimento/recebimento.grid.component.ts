import * as moment from 'moment';
import { Component, Inject, Input, OnChanges, ViewChild } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'itau-recebimento-grid',
    templateUrl: './recebimento.grid.component.html',
})

export class ItauRecebimentoGridComponent implements OnChanges {
    @Input() queryResult: any;

    constructor() {
    }

    ngOnChanges() {
        this.populate();
    }

    populate() {
    }
}
