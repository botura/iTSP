import { Component, Input } from '@angular/core';

@Component({
    selector: 'itau-recebimento-data',
    templateUrl: './recebimento.data.component.html',
})

export class ItauRecebimentoDataComponent {
    @Input() queryResult: any;

    constructor() {
    }
    
    customizePorc(data: any) {
        return data.value.toFixed(2);
    }

    customizeTooltip(arg: any) {
        return {
            text: arg.argumentText + "<br/>" + new Intl.NumberFormat('pt', { style: 'currency', currency: 'BRL' }).format(arg.value)

        };
    }
}
