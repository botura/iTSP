import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-recebimento',
  templateUrl: './recebimento.component.html',
  styleUrls: ['./recebimento.component.css']
})

export class RecebimentoComponent implements OnInit {
  searching = false;
  dataDe: Date = new Date();
  dataAte: Date = new Date();

  constructor() {
  }

  ngOnInit() {
    this.dataDe.setMonth(this.dataDe.getMonth() - 1);
  }

  btFiltrar() {

  }

}
