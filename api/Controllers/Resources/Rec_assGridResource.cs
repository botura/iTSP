using System;

namespace api.Controllers.Resources
{
    public class Rec_assGridResource
    {
        public int id { get; set; }
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
        public Decimal valor_honorarios { get; set; }
        public String operador { get; set; }
        public String cod_gerente { get; set; }
        public String nome_gerente { get; set; }
        public String uf_comer { get; set; }
        public String uf_resid { get; set; }
        public Decimal qtde_parcela_do_acordo { get; set; }
        public Decimal qtde_de_parcelas_em_aberto { get; set; }
        public Decimal parcela_do_acordo { get; set; }
        public String cod_entidade { get; set; }
        public Decimal valor_principal { get; set; }
        public Decimal desconto_aplicado { get; set; }
        public Decimal atraso { get; set; }
        public Decimal nivel_negociacao { get; set; }
        public Decimal divida_atualizada { get; set; }
    }
}