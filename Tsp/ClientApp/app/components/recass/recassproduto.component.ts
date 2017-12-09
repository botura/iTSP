import { Component, Inject, Input, OnChanges } from '@angular/core';
import { Http } from '@angular/http';
import { DxPieChartModule } from 'devextreme-angular';

@Component({
    selector: 'rec-ass-produto',
    templateUrl: './recassproduto.component.html',
})

export class RecAssProdutoComponent implements OnChanges {
    @Input() filtro: any;
    private baseUrl: string;
    private http: Http;
    public queryResult: any = [];
    loadingVisible = false;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    ngOnChanges() {
        this.populate();
    }

    populate() {
        this.loadingVisible = true;
        console.log('Inicio api/recass/somatoriaProduto');
        this.queryResult = null;

        this.http.get(this.baseUrl + 'api/rec_ass/somatoriaProduto' + '?' + this.toQueryString(this.filtro)).subscribe(result => {
            this.queryResult = result.json();
            console.log('Fim api/recass/somatoriaProduto');
            this.loadingVisible = false;
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
}
