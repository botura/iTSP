import { AuthHttp } from 'angular2-jwt';
import { DataService } from './data.service';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class ContaCorrenteService extends DataService {
    constructor(http: Http, authHttp: AuthHttp) {
        super('http://localhost:5001/api/contacorrente', http, authHttp);
    }

}
