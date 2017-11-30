using System.Collections.Generic;
using api.Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using api.Core.Models;
using api.Persistence;
using api.Controllers.Resources;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("/api/contacorrente")]
    // [Authorize("read:messages")]
    public class ContaCorrentesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IContaCorrenteRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public ContaCorrentesController(IMapper mapper, IContaCorrenteRepository repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        // Add
        [HttpPost]
        public async Task<IActionResult> AddContaCorrente([FromBody] ContaCorrenteResource ContaCorrenteDetailResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contacorrente = mapper.Map<ContaCorrenteResource, ContaCorrente>(ContaCorrenteDetailResource);

            repository.Add(contacorrente);
            await unitOfWork.CompleteAsync();

            contacorrente = await repository.GetContaCorrente(contacorrente.Id);

            var result = mapper.Map<ContaCorrente, ContaCorrenteResource>(contacorrente);

            return Ok(result);
        }


        // Update
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContaCorrente(int id, [FromBody] ContaCorrenteResource ContaCorrenteDetailResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var contacorrente = await repository.GetContaCorrente(id);

            if (contacorrente == null)
                return NotFound();

            mapper.Map<ContaCorrenteResource, ContaCorrente>(ContaCorrenteDetailResource, contacorrente);

            await unitOfWork.CompleteAsync();

            contacorrente = await repository.GetContaCorrente(contacorrente.Id);
            var result = mapper.Map<ContaCorrente, ContaCorrenteResource>(contacorrente);

            return Ok(result);
        }


        // Detail
        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetContaCorrente(int id)
        {
            var contacorrente = await repository.GetContaCorrente(id);

            if (contacorrente == null)
                return NotFound();

            var contaCorrenteResource = mapper.Map<ContaCorrente, ContaCorrenteResource>(contacorrente);

            return Ok(contaCorrenteResource);
        }


        // Grid
        [HttpGet("grid")]
        public async Task<IEnumerable<ContaCorrenteGridResource>> GetContaCorrenteGrid()
        {
            var list = await repository.GetContaCorrenteGrid();

            var result = mapper.Map<IEnumerable<ContaCorrente>, IEnumerable<ContaCorrenteGridResource>>(list);

            return result;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContaCorrente(int id)
        {
            var contacorrente = await repository.GetContaCorrente(id);

            if (contacorrente == null)
                return NotFound();

            repository.Remove(contacorrente);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}
