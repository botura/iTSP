import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { OnInit } from '@angular/core/src/metadata/lifecycle_hooks';

@Component({
    selector: 'import-recass',
    templateUrl: './import.recass.component.html',
})

export class ImportRecAssComponent implements OnInit {
    private baseUrl: string;
    private http: Http;
    public queryResult: any = [];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    ngOnInit() {
    }

}
