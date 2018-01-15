import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-carteira-atual-uf',
  templateUrl: './carteira-atual-uf.component.html',
  styleUrls: ['./carteira-atual-uf.component.css']
})

export class CarteiraAtualUfComponent implements OnInit {
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
