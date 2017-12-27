import { Component, Inject, Input, OnChanges } from '@angular/core';
import { Http } from '@angular/http';
import { DxDataGridModule } from 'devextreme-angular';

@Component({
    selector: 'itau-carteiraatual-pivot',
    templateUrl: './carteiraatual.pivot.component.html',
})

export class ItauCarteiraAtualPivotComponent implements OnChanges {
    @Input() filtro: any;
    private baseUrl: string;
    private http: Http;
    public queryResult: any = [];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    ngOnChanges() {
        if (this.filtro.dataArquivo) {
            this.populate();
        }
    }

    populate() {
        console.log('Inicio api/itau/carteiraatualgrid');
        this.queryResult = null;

        this.http.get(this.baseUrl + 'api/itau/carteiraatualgrid' + '?' + this.toQueryString(this.filtro)).subscribe(result => {
            this.queryResult = result.json();
            console.log('Fim api/itau/carteiraatualgrid');
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
