import { Component, Inject, Input, OnChanges } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'rec-ass-datapagto',
    templateUrl: './recassdatapagto.component.html',
})

export class RecAssDataPagtoComponent implements OnChanges {
    @Input() filtro: any;
    private baseUrl: string;
    private http: Http;
    public queryResult: any = [];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    ngOnChanges() {
        this.populate();
    }

    populate() {
        console.log('Inicio api/recass/somatoriaDataPagamento');
        this.queryResult = null;

        this.http.get(this.baseUrl + 'api/rec_ass/somatoriaDataPagamento' + '?' + this.toQueryString(this.filtro)).subscribe(result => {
            this.queryResult = result.json();
            console.log('Fim api/recass/somatoriaDataPagamento');
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


    customizePorc(data: any) {
        return data.value.toFixed(2);
    }

    customizeTooltip(arg: any) {
        return {
            text: arg.argumentText + "<br/>" + new Intl.NumberFormat('pt', { style: 'currency', currency: 'BRL' }).format(arg.value)

        };
    }
}
