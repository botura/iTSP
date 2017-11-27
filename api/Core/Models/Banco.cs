using System.ComponentModel.DataAnnotations.Schema;

namespace api.Core.Models
{
    [Table("banco")]
    public class Banco
    {
        [Column("BancoID")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int NumeroFebraban { get; set; }
    }
}