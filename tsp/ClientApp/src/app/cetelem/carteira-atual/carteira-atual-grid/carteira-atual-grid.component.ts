import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-carteira-atual-grid',
  templateUrl: './carteira-atual-grid.component.html',
  styleUrls: ['./carteira-atual-grid.component.css']
})

export class CarteiraAtualGridComponent implements OnInit {
  @Input() queryResult: any;

  constructor() { }

  ngOnInit() {
  }

}
