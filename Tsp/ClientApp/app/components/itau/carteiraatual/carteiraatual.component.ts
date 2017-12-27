import * as moment from 'moment';
import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import { and } from '@angular/router/src/utils/collection';

@Component({
    selector: 'itau-carteiraatual',
    templateUrl: './carteiraatual.component.html',
})

export class ItauCarteiraAtualComponent implements OnInit {
    private baseUrl: string;
    private http: Http;
    public carteiras: string[];
    public carteiraSelecionada: any[];
    filtro: any = {
        dataArquivo: ''
    }

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    ngOnInit() {
        this.populateCarteiras();
    }

    populateCarteiras() {
        this.carteiras = [];
        this.http.get(this.baseUrl + 'api/itau/carteiraatualcarteiras').subscribe(result => {
            this.carteiras = result.json();
        }, error => console.error(error));
    }

    btFiltrar() {
        {
            this.filtro = {};
            if (this.carteiraSelecionada && this.carteiraSelecionada[0]) {
                this.filtro.dataArquivo = this.carteiraSelecionada[0];
            }
        }
    }
}
