using System;
using System.Collections.Generic;

namespace api.Core.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            //Pessoa = new HashSet<Pessoa>();
        }

        public int CidadeId { get; set; }
        public string Cidade1 { get; set; }
        public string Uf { get; set; }

        public string CidadeUF
        {
            get
            {
                string txt = "";
                if (!string.IsNullOrEmpty(Cidade1))
                {
                    txt = Cidade1 + "/" + Uf;
                }
                return txt;
            }
        }

        //public ICollection<Pessoa> Pessoa { get; set; }
    }
}
