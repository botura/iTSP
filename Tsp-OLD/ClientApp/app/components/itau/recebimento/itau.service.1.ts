// import { Http } from '@angular/http';
// import { Inject, Injectable } from '@angular/core';

// import notify from 'devextreme/ui/notify';

// @Injectable()
// export class ItauService {
//     // private baseUrl: string;

//     constructor (private http: Http, @Inject('BASE_URL') private baseUrl: string) {
//     }

//     public SomatoriaDataPagamento(filtro: string) {
//         let teste = this.CallApi('api/itau/recebimento/somatoriaDataPagamento' + '?' + this.toQueryString(filtro));
//         console.log(teste); 
//         return teste;
//     }

//     public SomatoriaUf(filtro: string) {
//         return this.CallApi('api/itau/recebimento/somatoriaUf' + '?' + this.toQueryString(filtro));
//     }

//     public SomatoriaProduto(filtro: string) {
//         return this.CallApi('api/itau/recebimento/somatoriaProduto' + '?' + this.toQueryString(filtro));
//     }

//     private  CallApi(url: string) {
//         let resultado: any
//         this.http.get(this.baseUrl + url).subscribe(result => {
//             resultado = result.json();
//             console.log('Fim: ', url);
//             console.log('Resultado: ', resultado);
//             notify("Dados atualizados", "success", 1000);
//             return resultado;
//         }, error => {
//             console.error(error);
//             notify("Erro ao acessar o banco de dados", "error", 1000);
//             return "erro";
//         });
        
//     }

//     private toQueryString(obj: any) {
//         var parts = [];
//         for (var property in obj) {
//             var value = obj[property];
//             if (value != null && value != undefined)
//                 parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
//         }
//         return parts.join('&');
//     }

// }


// export class filtro {
//     dataInicial: string;
//     dataFinal: string;
// }
