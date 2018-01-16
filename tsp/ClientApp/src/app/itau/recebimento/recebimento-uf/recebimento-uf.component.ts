import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-recebimento-uf',
  templateUrl: './recebimento-uf.component.html',
  styleUrls: ['./recebimento-uf.component.css']
})

export class RecebimentoUfComponent implements OnInit {
  @Input() queryResult: any;

  constructor() {
  }

  ngOnInit() {
  }

  customizeLabel(arg: any) {
    console.log(arg);
    return arg.valueText + ' (' + arg.percentText + ')';
  }

  customizePorc(data: any) {
    return data.value.toFixed(2);
  }

}
