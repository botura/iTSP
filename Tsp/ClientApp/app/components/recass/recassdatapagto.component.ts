import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
    selector: 'rec-ass-datapagto',
    templateUrl: './recassdatapagto.component.html',
})

export class RecAssDataPagtoComponent implements OnInit {
    private baseUrl: string;
    private http: Http;
    public queryResult: any = [];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    ngOnInit() {
        this.populate();
    }

    populate() {
        console.log('Inicio api/recass/somatoriaDataPagamento');
        this.queryResult = null;

        this.http.get(this.baseUrl + 'api/rec_ass/somatoriaDataPagamento').subscribe(result => {
            this.queryResult = result.json();
            console.log('Fim api/recass/somatoriaDataPagamento');
        }, error => console.error(error));
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
