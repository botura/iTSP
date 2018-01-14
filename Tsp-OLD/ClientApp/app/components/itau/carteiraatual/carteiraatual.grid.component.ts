import { Component, Inject, Input, OnChanges } from '@angular/core';
import { Http } from '@angular/http';
import { DxDataGridModule } from 'devextreme-angular';
import notify from 'devextreme/ui/notify';

@Component({
    selector: 'itau-carteiraatual-grid',
    templateUrl: './carteiraatual.grid.component.html',
})

export class ItauCarteiraAtualGridComponent implements OnChanges {
    @Input() filtro: any;
    private baseUrl: string;
    private http: Http;
    public queryResult: any = [];
    public searching = false;

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
        this.searching = true;
        this.queryResult = null;

        this.http.get(this.baseUrl + 'api/itau/carteiraatualgrid' + '?' + this.toQueryString(this.filtro)).subscribe(result => {
            this.queryResult = result.json();
            this.searching = false;
            console.log('Fim api/itau/carteiraatualgrid');
            notify("Dados atualizados", "success", 3000);
        }, error => {
            console.error(error);
            this.searching = false;
            notify("Erro ao acessar o banco de dados", "error", 3000);
        });
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
