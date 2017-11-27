using AutoMapper;
using System.Linq;
using api.Controllers.Resources;
using api.Core.Models;

namespace api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain --> API Resource

            CreateMap<Pessoa, PessoaResource>()
                .ForMember(pr => pr.Id, opt => opt.MapFrom(p => p.PessoaId))
                .ForMember(pr => pr.Endereco, opt => opt.MapFrom(p => new EnderecoResource
                {
                    Endereco = p.Endereco,
                    Bairro = p.Bairro,
                    Numero = p.Numero,
                    Complemento = p.Complemento,
                    Cep = p.Cep,
                    CidadeId = p.CidadeId,
                    Cidade = p.Cidade.Cidade1 + "/" + p.Cidade.Uf
                }));

            CreateMap<Pessoa, PessoasListResource>()
                .ForMember(pr => pr.Id, opt => opt.MapFrom(p => p.PessoaId))
                .ForMember(pr => pr.Endereco, opt => opt.MapFrom(p => p.EnderecoCompleto()));

            CreateMap<Banco, KeyValuePairResource>()
                .ForMember(kvp => kvp.Value, opt => opt.MapFrom(b => b.Id))
                .ForMember(kvp => kvp.Label, opt => opt.MapFrom(b => b.Nome));

            CreateMap<ContaCorrente, ContaCorrenteResource>();

            CreateMap<ContaCorrente, ContaCorrenteGridResource>()
                .ForMember(ccr => ccr.Banco, opt => opt.MapFrom(cc => cc.Banco.Nome));



            // API Resource --> Domain

            CreateMap<ContaCorrenteResource, ContaCorrente>()
                    .ForMember(c => c.Id, opt => opt.Ignore());

        }
    }
}
