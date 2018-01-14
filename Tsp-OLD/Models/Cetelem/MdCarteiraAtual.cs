using System;

namespace Tsp.Models.Cetelem
{
    public class MdCarteiraAtual
    {
        public string contrato { get; set; }
        public decimal valor_financiado { get; set; }
        public decimal valor_prestacao { get; set; }
        public string uf { get; set; }
        public string nome_loja { get; set; }
        public string nome_empresa { get; set; }
        public string processo { get; set; }
        public decimal risco { get; set; }
    }
}