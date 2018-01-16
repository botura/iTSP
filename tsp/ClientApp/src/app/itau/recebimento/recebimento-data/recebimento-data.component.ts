import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-recebimento-data',
  templateUrl: './recebimento-data.component.html',
  styleUrls: ['./recebimento-data.component.css']
})

export class RecebimentoDataComponent implements OnInit {
  @Input() queryResult: any;

  constructor() { }

  ngOnInit() {
  }

  customizePorc(data: any) {
    return data.value.toFixed(2);
}

customizeTooltip(arg: any) {
    return {
        text: arg.argumentText + '<br/>' + new Intl.NumberFormat('pt', { style: 'currency', currency: 'BRL' }).format(arg.value)

    };
}

}
