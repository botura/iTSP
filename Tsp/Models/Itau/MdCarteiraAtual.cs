using System;

namespace Tsp.Models.Itau
{
    public class MdCarteiraAtual
    {
        public string UF_Resid { get; set; }
        public string CIDADE_Resid { get; set; }
        public string Produto_Recup { get; set; }
        public int Atraso { get; set; }
        public int Parcela { get; set; }
        public decimal PrincipalTotal { get; set; }
        public string Situacao_Descricao { get; set; }
        public string Acordo { get; set; }
        public string Entidade { get; set; }
        public string Falecido { get; set; }
        public string Orgao { get; set; }
        public string SubOrgao { get; set; }
        public string Data_ultimo_desconto { get; set; }
        public string Data_ultimo_pagamento { get; set; }
        public int Plano_parcelas { get; set; }
        public decimal ValorParcelas_Vencido { get; set; }
        public decimal ValorParcela { get; set; }
        public string Data_Inicio_Contrato { get; set; }
    }
}