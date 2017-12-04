using AutoMapper;
using System.Linq;
using Tsp.Controllers.Resources;
using Tsp.Core.Models;

namespace api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain --> API Resource

            CreateMap<RelatorioRec_ass, Rec_assGridResource>();


            // API Resource --> Domain

        }
    }
}
