import { RecAssService } from './../../services/rec_ass.service';
import { BreadcrumbService } from '../breadcrumb.service';
import { BoundCallbackObservable } from 'rxjs/observable/BoundCallbackObservable';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MessageService } from 'primeng/components/common/messageservice';
import { SelectItem } from 'primeng/primeng';

@Component({
  selector: 'app-recass',
  templateUrl: './rec_ass.component.html',
  styleUrls: ['./rec_ass.component.scss'],
  encapsulation: ViewEncapsulation.None
})

export class RecAssComponent implements OnInit {
  queryResult: any = [];

  constructor(
    private breadcrumbService: BreadcrumbService,
    private RecAssService: RecAssService,
    private messageService: MessageService) {

    this.breadcrumbService.setItems([
      { label: 'Relatórios' },
      { label: 'Rec_ass' }
    ]);

  }

  ngOnInit() {
    this.populateGrid();
  }

  populateGrid() {
    console.log('Inicio getGrid');
    this.RecAssService.getGrid()
      .subscribe(result => {
        this.queryResult = result;
        console.log('Fim getGrid');
      });


  }

  resetFiltro(dt) {
    this.populateGrid();
    dt.reset();
    this.messageService.add({ severity: 'info', summary: '', detail: 'Filtro resetado<br>Dados atualizados' });
  }

}
