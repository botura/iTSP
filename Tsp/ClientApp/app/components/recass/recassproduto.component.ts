import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { DxPieChartModule } from 'devextreme-angular';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
    selector: 'rec-ass-produto',
    templateUrl: './recassproduto.component.html',
})

export class RecAssProdutoComponent implements OnInit {
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
        console.log('Inicio api/recass/somatoriaProduto');
        this.queryResult = null;

        this.http.get(this.baseUrl + 'api/rec_ass/somatoriaProduto').subscribe(result => {
            this.queryResult = result.json();
            console.log('Fim api/recass/somatoriaProduto');
        }, error => console.error(error));
    }

    customizePorc(data: any) {
        return data.value.toFixed(2);
        // return "First: " + new DatePipe("en-US").transform(data.value, 'MMM dd, yyyy');
    }
}
