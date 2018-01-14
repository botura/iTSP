using System;

namespace Tsp.Models.Itau
{
    public class MdRecebimento
    {
        public string uf_resid { get; set; }
        public string cpf { get; set; }
        public string contrato { get; set; }
        public string produto { get; set; }
        public string data_pagamento { get; set; }
        public decimal valor_pago { get; set; }
        public int atraso { get; set; }
        public string tabela { get; set; }
    }
}