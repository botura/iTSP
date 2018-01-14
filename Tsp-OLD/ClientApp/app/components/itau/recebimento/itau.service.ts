import { Http } from '@angular/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class ItauService {
    private URL: string = 'api/itau/recebimento';
    constructor (private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    public GetSomatoriaDataPagamento(filtro: string) {
        return this.http.get(this.URL + '/somatoriaDataPagamento' + '?' + this.toQueryString(filtro))
        .map(res => res.json())
    }

    public GetSomatoriaUf(filtro: string) {
        return this.http.get(this.URL + '/somatoriaUf' + '?' + this.toQueryString(filtro))
        .map(res => res.json())
    }

    public GetSomatoriaProduto(filtro: string) {
        return this.http.get(this.URL + '/somatoriaProduto' + '?' + this.toQueryString(filtro))
        .map(res => res.json())
    }

    public GetGrid(filtro: string) {
        return this.http.get(this.URL + '/grid' + '?' + this.toQueryString(filtro))
        .map(res => res.json())
    }

    private toQueryString(obj: any) {
        var parts = [];
        for (var property in obj) {
            var value = obj[property];
            if (value != null && value != undefined)
                parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
        }
        return parts.join('&');
    }
}

export class filtro {
    dataInicial: string;
    dataFinal: string;
}
