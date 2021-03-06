import { Http } from '@angular/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/finally';
import 'rxjs/add/observable/throw';

@Injectable()
export class CetelemService {
    private URL: string = 'api/cetelem/carteira';
    constructor (private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    public GetSomatoriaUf() {
        return this.http.get(this.URL + '/somatoriaUf')
        .map(res => res.json())
    }

    public GetGrid() {
        return this.http.get(this.URL + '/grid')
        .map(res => res.json())
    }
}
