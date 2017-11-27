import { ContaCorrenteResource } from './../../models/contacorrente';
import { NotFoundError } from '../common/not-found-error';
import { BadInput } from '../common/bad-input';
import { MessageService } from 'primeng/components/common/messageservice';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/Observable/forkJoin';
import { AppError } from './../common/app-error';
import { SelectItem, ConfirmationService, AutoCompleteModule } from 'primeng/primeng';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, EventEmitter, Input, OnChanges, Output } from '@angular/core';
import { BancoService } from './../../services/banco.service';
import { ContaCorrenteService } from './../../services/contacorrente.service';

@Component({
  selector: 'app-contacorrente-form-reactive',
  templateUrl: './contacorrente-form-reactive.component.html',
  providers: [ConfirmationService]
})

////////////////////////////////
export class ContacorrenteFormReactiveComponent implements OnChanges {
  @Input() contaCorrente: ContaCorrenteResource;
  @Output() onSaved = new EventEmitter();
  @Output() onDeleted = new EventEmitter();
  ccForm: FormGroup;
  bancos: SelectItem[];

  ////////////////////////////////
  constructor(
    private fb: FormBuilder,
    private bancoService: BancoService,
    private contacorrenteService: ContaCorrenteService,
    private messageService: MessageService,
    private confirmationService: ConfirmationService) {

    this.createForm();
  }

  ////////////////////////////////
  createForm() {
    this.ccForm = this.fb.group({
      apelido: ['', Validators.required],
      titular: ['', Validators.required],
      bancoId: ['', Validators.required],
      numeroAgencia: ['', Validators.required],
      numeroConta: ['', Validators.required],
      nomeAgencia: [''],
      ativa: [''],
      contato1: [''],
      contato2: [''],
      telefone1: [''],
      telefone2: [''],
      boleto_AgenciaCedente: [''],
      boleto_CNPJCedente: [''],
      boleto_Carteira: [''],
      boleto_CarteiraRemessa: [''],
      boleto_CodigoCedente: [''],
      boleto_CodigoTransmissao240: [''],
      boleto_Complemento: [''],
      boleto_ContaCedente: [''],
      boleto_DigitoAgenciaCedente: [''],
      boleto_DigitoContaCedente: [''],
      boleto_EspecieDocumento: [null],
      boleto_NomeCedente: [''],
      boleto_NumeroBanco: [null],
      boleto_NumeroRemessa: [null],
      boleto_PorcentagemJurosAposVencimento: [null],
      boleto_PorcetagemMultaAposAtraso: [null],
      prefixoArquivoRemessa: ['']
    });

    this.bancoService.getKVP()
      .finally(() => { this.bancos.unshift({ 'value': 0, 'label': 'Banco' }); })
      .subscribe(result => this.bancos = result);
  }

  ////////////////////////////////
  ngOnChanges() {
    if (!this.contaCorrente) {
      this.ccForm.reset();
    } else {
      this.ccForm.reset({
        apelido: this.contaCorrente.apelido,
        titular: this.contaCorrente.titular,
        bancoId: this.contaCorrente.bancoId,
        numeroAgencia: this.contaCorrente.numeroAgencia,
        numeroConta: this.contaCorrente.numeroConta,
        nomeAgencia: this.contaCorrente.nomeAgencia,
        ativa: this.contaCorrente.ativa,
        contato1: this.contaCorrente.contato1,
        contato2: this.contaCorrente.contato2,
        telefone1: this.contaCorrente.telefone1,
        telefone2: this.contaCorrente.telefone2,
        boleto_AgenciaCedente: this.contaCorrente.boleto_AgenciaCedente,
        boleto_CNPJCedente: this.contaCorrente.boleto_CNPJCedente,
        boleto_Carteira: this.contaCorrente.boleto_Carteira,
        boleto_CarteiraRemessa: this.contaCorrente.boleto_CarteiraRemessa,
        boleto_CodigoCedente: this.contaCorrente.boleto_CodigoCedente,
        boleto_CodigoTransmissao240: this.contaCorrente.boleto_CodigoTransmissao240,
        boleto_Complemento: this.contaCorrente.boleto_Complemento,
        boleto_ContaCedente: this.contaCorrente.boleto_ContaCedente,
        boleto_DigitoAgenciaCedente: this.contaCorrente.boleto_DigitoContaCedente,
        boleto_DigitoContaCedente: this.contaCorrente.boleto_DigitoContaCedente,
        boleto_EspecieDocumento: this.contaCorrente.boleto_EspecieDocumento,
        boleto_NomeCedente: this.contaCorrente.boleto_NomeCedente,
        boleto_NumeroBanco: this.contaCorrente.boleto_NumeroBanco,
        boleto_NumeroRemessa: this.contaCorrente.boleto_NumeroRemessa,
        boleto_PorcentagemJurosAposVencimento: this.contaCorrente.boleto_PorcentagemJurosAposVencimento,
        boleto_PorcetagemMultaAposAtraso: this.contaCorrente.boleto_PorcetagemMultaAposAtraso,
        prefixoArquivoRemessa: this.contaCorrente.prefixoArquivoRemessa
      });
    }
  }

  ////////////////////////////////
  save() {
    this.contaCorrente = this.prepareSaveContaCorrente();
    const result$ =
      (this.contaCorrente.id) ? this.contacorrenteService.update(this.contaCorrente) : this.contacorrenteService.create(this.contaCorrente);

    result$
      .finally(() => {
        this.ngOnChanges();
      })
      .subscribe(conta => {
        if (!this.contaCorrente.id) {
          this.contaCorrente.id = conta.id;
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

  ////////////////////////////////
  prepareSaveContaCorrente(): ContaCorrenteResource {
    const formModel = this.ccForm.value;
    const saveContaCorrente: ContaCorrenteResource = {
      apelido: formModel.apelido as string,
      ativa: formModel.ativa as boolean,
      bancoId: formModel.bancoId as number,
      boleto_AgenciaCedente: formModel.boleto_AgenciaCedente as string,
      boleto_Carteira: formModel.boleto_Carteira as string,
      boleto_CarteiraRemessa: formModel.boleto_CarteiraRemessa as string,
      boleto_CNPJCedente: formModel.boleto_CNPJCedente as string,
      boleto_CodigoCedente: formModel.boleto_CodigoCedente as string,
      boleto_CodigoTransmissao240: formModel.boleto_CodigoTransmissao240 as string,
      boleto_Complemento: formModel.boleto_Complemento as string,
      boleto_ContaCedente: formModel.boleto_ContaCedente as string,
      boleto_DigitoAgenciaCedente: formModel.boleto_DigitoAgenciaCedente as string,
      boleto_DigitoContaCedente: formModel.boleto_DigitoContaCedente as string,
      boleto_EspecieDocumento: formModel.boleto_EspecieDocumento as number,
      boleto_NomeCedente: formModel.boleto_NomeCedente as string,
      boleto_NumeroBanco: formModel.boleto_NumeroBanco as number,
      boleto_NumeroRemessa: formModel.boleto_NumeroRemessa as number,
      boleto_PorcentagemJurosAposVencimento: formModel.boleto_PorcentagemJurosAposVencimento as number,
      boleto_PorcetagemMultaAposAtraso: formModel.boleto_PorcetagemMultaAposAtraso as number,
      contato1: formModel.contato1 as string,
      contato2: formModel.contato2 as string,
      id: this.contaCorrente.id,
      nomeAgencia: formModel.nomeAgencia as string,
      numeroAgencia: formModel.numeroAgencia as string,
      numeroConta: formModel.numeroConta as string,
      prefixoArquivoRemessa: formModel.prefixoArquivoRemessa as string,
      telefone1: formModel.telefone1 as string,
      telefone2: formModel.telefone2 as string,
      titular: formModel.titular as string
    };
    return saveContaCorrente;
  }

  ////////////////////////////////
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

  ////////////////////////////////
  delete() {
    this.contacorrenteService.delete(this.contaCorrente.id)
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
