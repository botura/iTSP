import { BreadcrumbService } from '../breadcrumb.service';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-pessoa',
    templateUrl: './pessoa.component.html'
})

export class PessoaComponent implements OnInit {
    constructor(private breadcrumbService: BreadcrumbService) {
        this.breadcrumbService.setItems([
            { label: 'Cadastro' },
            { label: 'Pessoa' }
        ]);
    }

    ngOnInit() { }
}
