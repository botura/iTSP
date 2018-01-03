import { Component, Inject, Input, OnChanges } from '@angular/core';
import { Http } from '@angular/http';
import { DxPieChartModule } from 'devextreme-angular';
import notify from 'devextreme/ui/notify';

@Component({
    selector: 'itau-carteiraatual-uf',
    templateUrl: './carteiraatual.uf.component.html',
})

export class ItauCarteiraAtualUfComponent implements OnChanges {
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
        console.log('Inicio api/itau/carteiraatualuf');
        this.searching = true;
        this.queryResult = null;

        this.http.get(this.baseUrl + 'api/itau/carteiraatualuf' + '?' + this.toQueryString(this.filtro)).subscribe(result => {
            this.queryResult = result.json();
            this.searching = false;
            console.log('Fim api/itau/carteiraatualuf');
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
