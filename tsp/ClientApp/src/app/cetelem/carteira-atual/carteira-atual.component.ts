import { Component, OnInit, Inject } from '@angular/core';
import { Http } from '@angular/http';

import { CetelemService } from '../cetelem.service';

@Component({
  selector: 'app-carteira-atual',
  templateUrl: './carteira-atual.component.html',
  styleUrls: ['./carteira-atual.component.css']
})

export class CarteiraAtualComponent implements OnInit {
  public queryResult: any = [];
  public queryResultUf: any = [];
  public searching = false;

  constructor(private dbService: CetelemService) {
  }

  ngOnInit() {
    this.populate();
  }

  populate() {
    this.searching = true;
    this.queryResultUf = null;
    this.queryResult = null;

    this.dbService.GetSomatoriaUf()
      .subscribe(result => this.queryResultUf = result);

    this.dbService.GetGrid()
      .finally(() => {
        // notify("Dados atualizados", "success", 3000);
        this.searching = false;
      })
      .subscribe(result => this.queryResult = result)
  }

}
