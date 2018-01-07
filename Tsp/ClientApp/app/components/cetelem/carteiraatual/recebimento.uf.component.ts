import { Component, Input } from '@angular/core';

@Component({
    selector: 'cetelem-recebimento-uf',
    templateUrl: './recebimento.uf.component.html',
})

export class CetelemRecebimentoUfComponent {
    @Input() queryResult: any;

    constructor() {
    }
    
    customizeLabel(arg: any) {
        console.log(arg);
        return arg.valueText + " (" + arg.percentText + ")";
    }

    customizePorc(data: any) {
        return data.value.toFixed(2);
    }
}
