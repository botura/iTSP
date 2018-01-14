import { Component, Input } from '@angular/core';

@Component({
    selector: 'itau-recebimento-produto',
    templateUrl: './recebimento.produto.component.html',
})

export class ItauRecebimentoProdutoComponent {
    @Input() queryResult: any;

    constructor() {
    }
    
    customizePorc(data: any) {
        return data.value.toFixed(2);
    }
}
