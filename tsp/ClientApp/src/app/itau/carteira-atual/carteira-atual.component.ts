import { Component, OnInit } from '@angular/core';

import { CarteiraAtualService } from './carteira-atual.service';

@Component({
  selector: 'app-carteira-atual',
  templateUrl: './carteira-atual.component.html',
  styleUrls: ['./carteira-atual.component.css']
})

export class CarteiraAtualComponent implements OnInit {
  searching = false;
  queryResult: any = [];
  queryResultUf: any = [];
  carteiras: string[];
  carteiraSelecionada: any[];
  queryFiltro: any = {
    dataArquivo: ''
  }

  constructor(private dbService: CarteiraAtualService) { }

  ngOnInit() {
    this.populateCarteiras();
  }

  populateCarteiras() {
    this.searching = true;
    this.carteiras = [];
    this.dbService.GetCarteiras()
      .finally(() => {
        this.searching = false;
      })
      .subscribe(result => this.carteiras = result);
  }

  btFiltrar() {
    {
      this.queryFiltro = {};
      if (this.carteiraSelecionada && this.carteiraSelecionada[0]) {
        this.queryFiltro.dataArquivo = this.carteiraSelecionada[0];
        this.populate();
      }
    }
  }

  populate() {
    this.searching = true;

    this.dbService.GetGrid(this.queryFiltro)
      .finally(() => {
        this.searching = false;
      })
      .subscribe(result => this.queryResult = result);

      this.dbService.GetSomatoriaUf(this.queryFiltro)
      .subscribe(result => this.queryResultUf = result);
  }

}
