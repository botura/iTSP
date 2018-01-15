import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class CarteiraAtualService {
  private URL = 'api/itau';

  constructor(private http: Http) {
  }

  public GetCarteiras() {
    return this.http.get(this.URL + '/carteiraatualcarteiras')
      .map(res => res.json());
  }

  public GetGrid(filtro: string) {
    return this.http.get(this.URL + '/carteiraatualgrid' + '?' + this.toQueryString(filtro))
      .map(res => res.json());
  }

  public GetSomatoriaUf(filtro: string) {
    return this.http.get(this.URL + '/carteiraatualuf' + '?' + this.toQueryString(filtro))
      .map(res => res.json());
  }

  private toQueryString(obj: any) {
    const parts = [];
    for (const property of Object.keys(obj)) {
      const value = obj[property];
      if (value !== null && value !== undefined) {
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
      }
    }
    return parts.join('&');
  }

}
