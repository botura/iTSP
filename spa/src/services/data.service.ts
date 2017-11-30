import { AuthHttp } from 'angular2-jwt';
import { BadInput } from './../app/common/bad-input';
import { NotFoundError } from './../app/common/not-found-error';
import { AppError } from './../app/common/app-error';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class DataService {
    constructor(private url: string, private http: Http, private authHttp: AuthHttp) {
    }

    getGrid() {
        return this.http.get(this.url + '/grid')
        // return this.authHttp.get(this.url + '/grid')
            .map(res => res.json())
            .catch((this.handleError));
    }

    getDetail(id) {
        return this.http.get(this.url + '/detail/' + id)
            .map(res => res.json())
            .catch((this.handleError));
    }

    getKVP() {
        return this.http.get(this.url + '/kvp')
            .map(res => res.json())
            .catch((this.handleError));
    }

    create(resource) {
        return this.http.post(this.url, resource)
            .map(res => res.json())
            .catch((this.handleError));
    }

    update(resource) {
        return this.http.put(this.url + '/' + resource.id, resource)
            .map(res => res.json())
            .catch((this.handleError));
    }

    delete(id) {
        return this.http.delete(this.url + '/' + id)
            .map(res => res.json())
            .catch((this.handleError));
    }

    private handleError(error: Response) {
        if (error.status === 400) {
            return Observable.throw(new BadInput(error.json()));
        }

        if (error.status === 404) {
            return Observable.throw(new NotFoundError());
        }

        return Observable.throw(new AppError(error))
    }
}
