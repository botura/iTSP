using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tsp.Models
{
    public class MdRecAss
    {
        public String produto { get; set; }
        public String nome_gerente { get; set; }
        public DateTime vencimento_prestacao { get; set; }
        public string data_pagamento { get; set; }
        public Decimal valor_pago { get; set; }
        public String uf_resid { get; set; }
        public Decimal qtde_parcela_do_acordo { get; set; }
        public Decimal qtde_de_parcelas_em_aberto { get; set; }
        public Decimal parcela_do_acordo { get; set; }
        public Decimal valor_principal { get; set; }
        public Decimal desconto_aplicado { get; set; }
        public Decimal atraso { get; set; }
        public Decimal divida_atualizada { get; set; }
    }
}
