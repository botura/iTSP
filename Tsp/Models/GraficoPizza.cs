using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tsp.Models
{
    public class MdGrafico
    {
        public String groupby { get; set; }
        public Decimal soma { get; set; }
        public Decimal valor_em_porc { get; set; }
        public int tickets { get; set; }
        public Decimal tickets_em_porc { get; set; }
        public Decimal ticketMedio { get; set; }
        public int totalRegistros { get; set; }
        public decimal totalValor { get; set; }
    }
}
