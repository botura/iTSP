import { Component, Inject, Input, OnChanges } from '@angular/core';
import { Http } from '@angular/http';
import { DxDataGridModule } from 'devextreme-angular';

@Component({
    selector: 'rec-ass-grid',
    templateUrl: './recassgrid.component.html',
})

export class RecAssGridComponent implements OnChanges {
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
        console.log('Inicio api/recass/grid:');
        this.queryResult = null;

        this.http.get(this.baseUrl + 'api/rec_ass/grid'+ '?' + this.toQueryString(this.filtro)).subscribe(result => {
            this.queryResult = result.json();
            console.log('Fim api/recass/grid');
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
    
    onContentReady(e: any) {
        e.component.option('loadPanel.enabled', false);
    }
}
