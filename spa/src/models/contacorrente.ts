import { strictEqual } from 'assert';

import { KeyValuePair } from './keyvaluepair';

export interface ContaCorrenteList {
    id: number;
    apelido: string;
    numeroAgencia: string;
    numeroConta: string;
    ativa: boolean;
    telefone1: string;
    telefone2: string;
    banco: KeyValuePair;
}


export interface ContaCorrenteResource {
    id: number;
    apelido: string;
    titular: string;
    bancoId: number;
    nomeAgencia: string;
    numeroAgencia: string;
    numeroConta: string;
    ativa: boolean;
    contato1: string;
    contato2: string;
    telefone1: string;
    telefone2: string;
    boleto_AgenciaCedente: string;
    boleto_CNPJCedente: string;
    boleto_Carteira: string;
    boleto_CarteiraRemessa: string;
    boleto_CodigoCedente: string;
    boleto_CodigoTransmissao240: string;
    boleto_Complemento: string;
    boleto_ContaCedente: string;
    boleto_DigitoAgenciaCedente: string;
    boleto_DigitoContaCedente: string;
    boleto_EspecieDocumento: number;
    boleto_NomeCedente: string;
    boleto_NumeroBanco: number;
    boleto_NumeroRemessa: number;
    boleto_PorcentagemJurosAposVencimento: number;
    boleto_PorcetagemMultaAposAtraso: number;
    prefixoArquivoRemessa: string;
}
