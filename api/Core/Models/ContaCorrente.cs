using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Core.Models
{
    [Table("contacorrente")]
    public class ContaCorrente
    {
        [Column("ContaCorrenteID")]
        public int Id { get; set; }

        // [Column("Apelido")]
        public string Apelido { get; set; }
        public string Titular { get; set; }
        public string NomeAgencia { get; set; }
        public string NumeroAgencia { get; set; }
        public string NumeroConta { get; set; }
        public bool Ativa { get; set; }

        public string Contato1 { get; set; }
        public string Contato2 { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }

        public int BancoId { get; set; }
        public Banco Banco { get; set; }

        public string Boleto_CodigoCedente { get; set; }
        public string Boleto_NomeCedente { get; set; }
        public string Boleto_AgenciaCedente { get; set; }
        public string Boleto_DigitoAgenciaCedente { get; set; }
        public string Boleto_ContaCedente { get; set; }
        public string Boleto_DigitoContaCedente { get; set; }
        public Nullable<int> Boleto_EspecieDocumento { get; set; }
        public Nullable<int> Boleto_NumeroBanco { get; set; }
        public string Boleto_Carteira { get; set; }
        public string Boleto_CNPJCedente { get; set; }
        public Nullable<decimal> Boleto_PorcetagemMultaAposAtraso { get; set; }
        public Nullable<decimal> Boleto_PorcentagemJurosAposVencimento { get; set; }
        public string Boleto_CarteiraRemessa { get; set; }
        public string Boleto_CodigoTransmissao240 { get; set; }
        public string Boleto_Complemento { get; set; }
        public Nullable<int> Boleto_NumeroRemessa { get; set; }
        public string PrefixoArquivoRemessa { get; set; }
    }


}