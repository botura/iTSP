import { RecebimentoService } from './recebimento.service';
import { Component, OnInit } from '@angular/core';
import * as moment from 'moment';

@Component({
  selector: 'app-recebimento',
  templateUrl: './recebimento.component.html',
  styleUrls: ['./recebimento.component.css']
})

export class RecebimentoComponent implements OnInit {
  queryResultDataPagamento: any = [];
  queryResultUf: any = [];
  queryResult: any = [];
  searching = false;
  queryFiltro: any = {
    dataInicial: '',
    dataFinal: '',
  }
  dataDe: Date = new Date();
  dataAte: Date = new Date();

  constructor(private dbService: RecebimentoService) {
  }

  ngOnInit() {
    this.dataDe.setMonth(this.dataDe.getMonth() - 1);
    this.btFiltrar();
  }

  btFiltrar() {
    const filtro: any = {};
    this.queryFiltro.dataInicial = moment(this.dataDe).format('YYYY-MM-DD');
    this.queryFiltro.dataFinal = moment(this.dataAte).format('YYYY-MM-DD');
    this.populate();
  }

  populate() {
    this.searching = true;

    this.dbService.GetSomatoriaDataPagamento(this.queryFiltro)
      .subscribe(result => this.queryResultDataPagamento = result);

    this.dbService.GetSomatoriaUf(this.queryFiltro)
      .subscribe(result => this.queryResultUf = result);

    this.dbService.GetGrid(this.queryFiltro)
      .finally(() => {
        this.searching = false;
      })
      .subscribe(result => this.queryResult = result);
  }

}
