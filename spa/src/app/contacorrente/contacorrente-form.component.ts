import { BadInput } from './../common/bad-input';
import { NotFoundError } from './../common/not-found-error';
import { AppError } from './../common/app-error';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MessageService } from 'primeng/components/common/messageservice';
import { Observable } from 'rxjs/Observable';
import { SelectItem, ConfirmationService } from 'primeng/primeng';
import 'rxjs/add/Observable/forkJoin';
import 'rxjs/add/operator/finally';
import { ContaCorrenteService } from './../../services/contacorrente.service';
import { BancoService } from './../../services/banco.service';

@Component({
  selector: 'app-contacorrente-form',
  templateUrl: './contacorrente-form.component.html',
  providers: [ConfirmationService],
})
export class ContacorrenteFormComponent implements OnInit {
  private _id: number;
  @Input()
  set id(id: number) {
    this._id = id;
    this.loadDetails();
  }
  get id(): number { return this._id };

  @Output() onDeleted = new EventEmitter();
  @Output() onSaved = new EventEmitter();
  bancos: SelectItem[];
  cc: any = {
    ativa: true,
    id: 0,
    apelido: '',
    titular: '',
    bancoId: 0,
    nomeAgencia: '',
    numeroAgencia: '',
    numeroConta: '',
    contato1: '',
    contato2: '',
    telefone1: '',
    telefone2: '',
    boleto_CodigoCedente: '',
    boleto_NomeCedente: '',
    boleto_AgenciaCedente: '',
    boleto_DigitoAgenciaCedente: '',
    boleto_ContaCedente: '',
    boleto_DigitoContaCedente: '',
    boleto_EspecieDocumento: '',
    boleto_NumeroBanco: '',
    boleto_Carteira: '',
    boleto_CNPJCedente: '',
    boleto_PorcetagemMultaAposAtraso: '',
    boleto_PorcentagemJurosAposVencimento: '',
    boleto_CarteiraRemessa: '',
    boleto_CodigoTransmissao240: '',
    boleto_Complemento: '',
    boleto_NumeroRemessa: 0,
    prefixoArquivoRemessa: ''
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private contacorrenteService: ContaCorrenteService,
    private bancoService: BancoService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {
  };

  ngOnInit() {
  }

  loadDetails() {
    this.cc = {
      id: 0,
      ativa: true
    };
    this.cc.id = +this._id || 0;

    const sources = [
      this.bancoService.getKVP(),
    ];

    if (this.cc.id) {
      sources.push(this.contacorrenteService.getDetail(this.cc.id));
    }

    Observable.forkJoin(sources).subscribe(data => {
      this.bancos = data[0];
      this.bancos.unshift({ 'value': 0, 'label': 'Banco' });
      if (this.cc.id) {
        this.cc = data[1];
      }
      //  window.scrollTo(0, 0);
    });
  }

  save() {
    const result$ = (this.cc.id) ? this.contacorrenteService.update(this.cc) : this.contacorrenteService.create(this.cc);
    result$
      .finally(() => { })
      .subscribe(conta => {
        if (!this.cc.id) {
          this.cc.id = conta.id;
        }
        this.messageService.add({ severity: 'success', summary: '', detail: 'Registro salvo' });
        this.onSaved.emit()
      },
      (error: AppError) => {
        if (error instanceof BadInput) {
          this.messageService.add({ severity: 'error', summary: '', detail: 'Dados inválidos' });
        } else {
          throw error;
        }
      });
  }

  confirmDelete() {
    this.confirmationService.confirm({
      message: 'Deseja mesmo apagar essa conta corrente?',
      header: 'ATENÇÃO',
      icon: 'fa fa-trash',
      accept: () => {
        this.delete();
      },
      reject: () => {
      }
    });
  }

  delete() {
    this.contacorrenteService.delete(this.cc.id)
      .finally(() => { })
      .subscribe(() => {
        this.onDeleted.emit();
        this.messageService.add({ severity: 'info', summary: '', detail: 'Registro apagado' });
      },
      (error: AppError) => {
        if (error instanceof NotFoundError) {
          this.messageService.add({ severity: 'error', summary: '', detail: 'Registro não encontrado' });
        } else {
          throw error;
        }
      });
}

}
