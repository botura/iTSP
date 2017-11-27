using System;
using System.Collections.Generic;

namespace api.Core.Models
{
    public partial class Pessoa
    {
        public int PessoaId { get; set; }
        public bool FlagCliente { get; set; }
        public bool FlagFornecedor { get; set; }
        public bool FlagPessoaJuridica { get; set; }
        public bool FlagCorretor { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        //public int? CidadeId { get; set; }
        public int CidadeId { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Observacao { get; set; }
        public bool? SexoMasculino { get; set; }
        public string Profissao { get; set; }
        public string Email { get; set; }
        public string EstadoCivil { get; set; }
        public string RegimeCasamento { get; set; }
        public string NomeConjuge { get; set; }
        public bool? SexoMasculinoConjuge { get; set; }
        public string Cpfconjuge { get; set; }
        public string Rgconjuge { get; set; }
        public string ProfissaoConjuge { get; set; }
        public string EmailConjuge { get; set; }
        public string Telefone3 { get; set; }
        public string Telefone4 { get; set; }
        public string FornecedorDe { get; set; }
        public string NomeContato1 { get; set; }
        public string EmailContato1 { get; set; }
        public string NomeContato2 { get; set; }
        public string EmailContato2 { get; set; }
        public string NomeContato3 { get; set; }
        public string EmailContato3 { get; set; }
        public string TelefoneContato1 { get; set; }
        public string TelefoneContato2 { get; set; }
        public string TelefoneContato3 { get; set; }

        public Cidade Cidade { get; set; }

        public string EnderecoCompleto()
        {
            string txt = "";
            txt = ConcatenaEndereco(txt, this.Endereco);
            txt = ConcatenaEndereco(txt, this.Numero);
            txt = ConcatenaEndereco(txt, this.Complemento);
            txt = ConcatenaEndereco(txt, this.Bairro);
            txt = ConcatenaEndereco(txt, this.Cidade.CidadeUF);
            txt = ConcatenaEndereco(txt, this.Cep);
            return txt;
        }

        private string ConcatenaEndereco(string str1, string str2)
        {
            string str = "";
            if (!string.IsNullOrEmpty(str2))
            {
                if (!string.IsNullOrEmpty(str1) && str1.Length >= 0)
                {
                    str = str1 + " - ";
                }
                str += str2;
            } else {
                str = str1;
            }

            return str;
        }
    }
}
