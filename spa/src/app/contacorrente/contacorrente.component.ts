import { BreadcrumbService } from '../breadcrumb.service';
import { ContaCorrenteResource } from './../../models/contacorrente';
import { BoundCallbackObservable } from 'rxjs/observable/BoundCallbackObservable';
import { ContacorrenteFormComponent } from './contacorrente-form.component';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ContaCorrenteService } from './../../services/contacorrente.service';
import { MessageService } from 'primeng/components/common/messageservice';
import { SelectItem } from 'primeng/primeng';

@Component({
  selector: 'app-contacorrente',
  templateUrl: './contacorrente.component.html',
  styleUrls: ['./contacorrente.component.scss'],
  encapsulation: ViewEncapsulation.None
})

export class ContacorrenteComponent implements OnInit {
  queryResult: any = [];
  simnao: SelectItem[];
  selectedRow: any;
  selectedContaCorrente: ContaCorrenteResource;

  constructor(
    private breadcrumbService: BreadcrumbService,
    private contacorrenteService: ContaCorrenteService,
    private messageService: MessageService) {

    this.breadcrumbService.setItems([
      { label: 'Cadastro' },
      { label: 'Conta corrente' }
    ]);

    this.simnao = [];
    this.simnao.push({ label: 'Selecione', value: null });
    this.simnao.push({ label: 'Sim', value: 'true' });
    this.simnao.push({ label: 'Não', value: 'false' });
  }

  ngOnInit() {
    this.populateContaCorrente();
  }

  populateContaCorrente() {
    this.contacorrenteService.getGrid()
      .subscribe(result => this.queryResult = result);
  }

  edit() {
    this.contacorrenteService.getDetail(this.selectedRow.id).subscribe(result => this.selectedContaCorrente = result);
  }

  add() {
    this.selectedContaCorrente = <ContaCorrenteResource>{};
    this.selectedContaCorrente.ativa = true;
  }

  onDeleted() {
    this.selectedContaCorrente = null;
    this.populateContaCorrente();
  }

  onSaved() {
    this.populateContaCorrente();
  }

  resetFiltro(dt) {
    this.populateContaCorrente();
    dt.reset();
    this.messageService.add({ severity: 'info', summary: '', detail: 'Filtro resetado<br>Dados atualizados' });
  }

}
