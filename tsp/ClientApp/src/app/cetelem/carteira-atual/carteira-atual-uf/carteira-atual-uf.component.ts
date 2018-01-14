import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-carteira-atual-uf',
  templateUrl: './carteira-atual-uf.component.html',
  styleUrls: ['./carteira-atual-uf.component.css']
})

export class CarteiraAtualUfComponent {
  @Input() queryResult: any;

  constructor() {
  }

  customizeLabel(arg: any) {
      console.log(arg);
      return arg.valueText + ' (' + arg.percentText + ')';
  }

  customizePorc(data: any) {
      return data.value.toFixed(2);
  }

}
