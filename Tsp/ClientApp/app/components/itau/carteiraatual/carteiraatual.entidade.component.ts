import { Component, Inject, Input, OnChanges } from '@angular/core';
import { Http } from '@angular/http';
import { DxPieChartModule } from 'devextreme-angular';

@Component({
    selector: 'itau-carteiraatual-entidade',
    templateUrl: './carteiraatual.entidade.component.html',
})

export class ItauCarteiraAtualEntidadeComponent implements OnChanges {
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
        console.log('Inicio api/itau/carteiraatualentidade');
        this.queryResult = null;

        this.http.get(this.baseUrl + 'api/itau/carteiraatualentidade' + '?' + this.toQueryString(this.filtro)).subscribe(result => {
            this.queryResult = result.json();
            console.log('Fim api/itau/carteiraatualentidade');
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

    pointClickHandler(e: any) {
        this.toggleVisibility(e.target);
    }

    legendClickHandler(e: any) {
        let arg = e.target,
            item = e.component.getAllSeries()[0].getPointsByArg(arg)[0];

        this.toggleVisibility(item);
    }

    toggleVisibility(item: any) {
        if (item.isVisible()) {
            item.hide();
        } else {
            item.show();
        }
    }

    customizeLabel(arg: any) {
        console.log(arg);
        return arg.valueText + " (" + arg.percentText + ")";
    }

    customizePorc(data: any) {
        return data.value.toFixed(2);
    }
}
