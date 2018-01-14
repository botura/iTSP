import * as moment from 'moment';
import { Component, Inject, ViewChild } from '@angular/core';
import { Http } from '@angular/http';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import notify from 'devextreme/ui/notify';
import { ItauService } from './itau.service';

@Component({
    selector: 'itau-recebimento',
    templateUrl: './recebimento.component.html',
    providers: [ItauService]
})

export class ItauRecebimentoComponent implements OnInit {
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

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private itauService: ItauService) {
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
        this.searching = true;
        this.queryResultDataPagamento = null;
        this.queryResultProduto = null;
        this.queryResultUf = null;
        this.queryResult = null;

        this.itauService.GetSomatoriaDataPagamento(this.filtro)
            .subscribe(result => this.queryResultDataPagamento = result);

        this.itauService.GetSomatoriaProduto(this.filtro)
            .subscribe(result => this.queryResultProduto = result);

        this.itauService.GetSomatoriaUf(this.filtro)
            .subscribe(result => this.queryResultUf = result);

        this.itauService.GetGrid(this.filtro)
            .subscribe(result => this.queryResult = result);

        this.searching = false;
    }
}
