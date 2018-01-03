import * as moment from 'moment';
import { Component, Inject, ViewChild } from '@angular/core';
import { Http } from '@angular/http';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import notify from 'devextreme/ui/notify';

@Component({
    selector: 'itau-recebimento',
    templateUrl: './recebimento.component.html',
})

export class ItauRecebimentoComponent implements OnInit {
    private baseUrl: string;
    private http: Http;
    public queryResult: any = [];
    public queryResultUf: any = [];
    public queryResultProduto: any = [];
    public queryResultDataPagamento: any = [];
    public searching = false;
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
        this.searching = true;
        this.queryResult = null;
        this.queryResultDataPagamento = null;
        this.queryResultUf = null;
        this.queryResultProduto = null;
        this.queryResultUf = null;

        this.http.get(this.baseUrl + 'api/itau/recebimento/somatoriaDataPagamento' + '?' + this.toQueryString(this.filtro)).subscribe(result => {
            this.queryResultDataPagamento = result.json();
            this.searching = false;
            console.log('Fim api/itau/recebimento/somatoriaDataPagamento');
            notify("Dados atualizados", "success", 1000);
        }, error => {
            console.error(error);
            this.searching = false;
            notify("Erro ao acessar o banco de dados", "error", 1000);
        });
        
        this.http.get(this.baseUrl + 'api/itau/recebimento/somatoriaUf' + '?' + this.toQueryString(this.filtro)).subscribe(result => {
            this.queryResultUf = result.json();
            this.searching = false;
            console.log('Fim api/itau/recebimento/somatoriaUf');
            notify("Dados atualizados", "success", 1000);
        }, error => {
            console.error(error);
            this.searching = false;
            notify("Erro ao acessar o banco de dados", "error", 1000);
        });
        
        this.http.get(this.baseUrl + 'api/itau/recebimento/somatoriaProduto' + '?' + this.toQueryString(this.filtro)).subscribe(result => {
            this.queryResultProduto = result.json();
            this.searching = false;
            console.log('Fim api/itau/recebimento/somatoriaProduto');
            notify("Dados atualizados", "success", 1000);
        }, error => {
            console.error(error);
            this.searching = false;
            notify("Erro ao acessar o banco de dados", "error", 1000);
        });

        this.http.get(this.baseUrl + 'api/itau/recebimento/grid' + '?' + this.toQueryString(this.filtro)).subscribe(result => {
            this.queryResult = result.json();
            this.searching = false;
            console.log('Fim api/itau/recebimento/grid');
            notify("Dados atualizados", "success", 1000);
        }, error => {
            console.error(error);
            this.searching = false;
            notify("Erro ao acessar o banco de dados", "error", 1000);
        });
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
