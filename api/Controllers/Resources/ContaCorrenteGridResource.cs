using System;

namespace api.Controllers.Resources
{
    public class ContaCorrenteGridResource
    {
        public int Id { get; set; }
        public string Apelido { get; set; }
        public string NumeroAgencia { get; set; }
        public string NumeroConta { get; set; }
        public bool Ativa { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Banco { get; set; }
    }
}