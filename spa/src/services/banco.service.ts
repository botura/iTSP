import { AuthService } from './auth/auth.service';
import { AuthHttp } from 'angular2-jwt';
import { DataService } from './data.service';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class BancoService extends DataService {
    constructor(http: Http, authHttp: AuthHttp) {
        super('http://localhost:5001/api/banco', http, authHttp);
    }
}
