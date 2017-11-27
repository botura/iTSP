
namespace api.Controllers.Resources
{
    public class PessoasListResource
    {
        public int Id { get; set; }
        public bool FlagCliente { get; set; }
        public bool FlagFornecedor { get; set; }
        public bool FlagCorretor { get; set; }
        public string Nome { get; set; }
        public string CpfCNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone1 { get; set; }
        public string Email { get; set; }
    }
}
