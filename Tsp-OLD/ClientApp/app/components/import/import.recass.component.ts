import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';
import notify from 'devextreme/ui/notify';

@Component({
    selector: 'import-recass',
    templateUrl: './import.recass.component.html',
})

export class ImportRecAssComponent implements OnInit {
    private baseUrl: string;
    private http: Http;
    public queryResult: any = [];
    public loadingVisible = false;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    ngOnInit() {
    }

    onUploadStarted() {
        this.loadingVisible = true;
    }

    onUploaded(e: any) {
        if (e.request.status === 200) {
            notify(e.request.responseText, 'success', 10000);
        } else {
            console.log('ERRO: ', e);
            notify('Alguma coisa deu errado...', 'error', 5000);
        }
        this.loadingVisible = false;
    }

    onUploadError(e: any) {
        console.log('ERRO: ', e);
        notify('Alguma coisa deu errado... Se persistir, avise o Matheus.', 'error', 5000);
        this.loadingVisible = false;
    }

}
