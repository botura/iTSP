import * as moment from 'moment';
import { Component, Inject, ViewChild } from '@angular/core';
import { Http } from '@angular/http';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
    selector: 'itau-recebimento',
    templateUrl: './recebimento.component.html',
})

export class ItauRecebimentoComponent implements OnInit {
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
        this.dataDe.setMonth(this.dataDe.getMonth() - 1);
    }

    ngOnInit() {
        this.btFiltrar();
    }

    btFiltrar() {
        {
            this.filtro = {};
            this.filtro.dataInicial = moment(this.dataDe).format("YYYY-MM-DD");
            this.filtro.dataFinal = moment(this.dataAte).format("YYYY-MM-DD");
            this.populate();
        }
    }

    populate() {
        console.log('Inicio api/itau/recebimento/grid:');
        this.queryResult = null;

        this.http.get(this.baseUrl + 'api/itau/recebimento/grid' + '?' + this.toQueryString(this.filtro)).subscribe(result => {
            this.queryResult = result.json();
            console.log('Fim api/itau/recebimento/grid');
        }, error => console.error(error));
    }

    toQueryString(obj: any) {
        var parts = [];
        for (var property in obj) {
            var value = obj[property];
            if (value != null && value != undefined)
                parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
        }
        return parts.join('&');
    }
}
