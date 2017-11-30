using System.Collections.Generic;
using api.Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using api.Core.Models;
using api.Controllers.Resources;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("/api/banco/")]
    // [Authorize("read:messages")]
    public class BancosController : Controller
    {
        private readonly IMapper mapper;
        private readonly IBancoRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public BancosController(IMapper mapper, IBancoRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("/api/banco/kvp")]
        public async Task<IEnumerable<KeyValuePairResource>> GetBancosKeyValuePair()
        {
            var list = await repository.GetList();
            var result = mapper.Map<IEnumerable<Banco>, IEnumerable<KeyValuePairResource>>(list);

            return result;
        }
    }
}
