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
    [Route("/api/pessoa")]
    // [Authorize]
    public class PessoasController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPessoaRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public PessoasController(IMapper mapper, IPessoaRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        [Route("/api/pessoa/{id}")]
        [HttpGet]
        //[HttpGet("{id}")]
        public async Task<IActionResult> GetPessoaDetail(int id)
        {
            var pessoa = await repository.GetPessoaDetail(id);

            if (pessoa == null)
                return NotFound();

            var pessoaResource = mapper.Map<Pessoa, PessoaResource>(pessoa);

            return Ok(pessoaResource);
        }

        // Grid
        // [Route("/api/pessoa/list")]
        [HttpGet("grid")]
        public async Task<IEnumerable<PessoasListResource>> GetPessoasList()
        {
            var pessoas = await repository.GetPessoasList();

            return mapper.Map<List<Pessoa>, List<PessoasListResource>>(pessoas);
        }
    }
}
