
namespace api.Controllers.Resources
{
    public class PessoaResource
    {
        public int Id { get; set; }
        public sbyte FlagCliente { get; set; }
        public sbyte FlagFornecedor { get; set; }
        public sbyte FlagPessoaJuridica { get; set; }
        public sbyte FlagCorretor { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public EnderecoResource Endereco { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Email { get; set; }
    }
}
