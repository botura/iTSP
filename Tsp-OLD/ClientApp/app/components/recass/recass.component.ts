import * as moment from 'moment';
import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
    selector: 'rec-ass',
    templateUrl: './recass.component.html',
})

export class RecAssComponent implements OnInit {
    private baseUrl: string;
    private http: Http;
    public queryResult: any = [];
    dataDe: Date = new Date();
    dataAte: Date = new Date();
    filtro: any = {
        dataInicial: '',
        dataFinal: '',
    }

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.dataDe.setMonth(this.dataDe.getMonth()-1);
    }

    ngOnInit() {
        this.btFiltrar();
    }

    btFiltrar() {
        {
            this.filtro = {};
            this.filtro.dataInicial =  moment(this.dataDe).format("YYYY-MM-DD");
            this.filtro.dataFinal =  moment(this.dataAte).format("YYYY-MM-DD");
            // console.log(this.filtro);
            // notify('Botão filtrar foi pressionado!');
        }
    }
}
