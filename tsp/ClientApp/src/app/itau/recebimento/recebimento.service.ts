import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class RecebimentoService {
  private URL = 'api/itau/recebimento';

  constructor(private http: Http) { }

  public GetSomatoriaUf(filtro: string) {
    return this.http.get(this.URL + '/somatoriaUf' + '?' + this.toQueryString(filtro))
      .map(res => res.json());
  }

  public GetSomatoriaDataPagamento(filtro: string) {
    return this.http.get(this.URL + '/somatoriaDataPagamento' + '?' + this.toQueryString(filtro))
      .map(res => res.json());
  }

  public GetGrid(filtro: string) {
    return this.http.get(this.URL + '/grid' + '?' + this.toQueryString(filtro))
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
