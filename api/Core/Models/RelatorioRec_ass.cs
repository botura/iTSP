using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Core.Models
{
    [Table("rec_ass")]
    public class RelatorioRec_ass
    {
        public int id { get; set; }
        public String tipo_pagamento_ge { get; set; }
        public String tipo_pagamento { get; set; }
        public DateTime processamento { get; set; }
        public String cod_receb { get; set; }
        public String credor { get; set; }
        public String cliente { get; set; }
        public String cpf { get; set; }
        public String nome { get; set; }
        public String cod_produto { get; set; }
        public String produto { get; set; }
        public String contrato { get; set; }
        public DateTime vencimento_prestacao { get; set; }
        public String numero_prestacao { get; set; }
        public DateTime data_pagamento { get; set; }
        public Decimal valor_pago { get; set; }
        public Decimal bonificacao_maxima { get; set; }
        public Decimal bonificacao_a_receber { get; set; }
        public Decimal valor_honorarios { get; set; }
        public Decimal valor_adicional { get; set; }
        public String operador { get; set; }
        public String cod_gerente { get; set; }
        public String nome_gerente { get; set; }
        public String uf_comer { get; set; }
        public String uf_resid { get; set; }
        public String campanha_recebimento { get; set; }
        public String campanha_cinco { get; set; }
        public String campanha_restante { get; set; }
        public String indicador { get; set; }
        public String assessoria { get; set; }
        public String debito_nao_ajuizavel { get; set; }
        public Decimal qtde_parcela_do_acordo { get; set; }
        public Decimal qtde_de_parcelas_em_aberto { get; set; }
        public Decimal parcela_do_acordo { get; set; }
        public String cod_entidade { get; set; }
        public Decimal valor_principal { get; set; }
        public Decimal desconto_aplicado { get; set; }
        public Decimal atraso { get; set; }
        public Decimal nivel_negociacao { get; set; }
        public Decimal divida_atualizada { get; set; }
        public int linhaArquivo { get; set; }
        public string nomeArquivo { get; set; }
    }
}