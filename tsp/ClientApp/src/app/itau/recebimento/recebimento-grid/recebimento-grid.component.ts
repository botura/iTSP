import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-recebimento-grid',
  templateUrl: './recebimento-grid.component.html',
  styleUrls: ['./recebimento-grid.component.css']
})

export class RecebimentoGridComponent implements OnInit {
  @Input() queryResult: any;

  constructor() { }

  ngOnInit() {
  }

}
