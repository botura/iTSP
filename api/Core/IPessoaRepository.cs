using System.Threading.Tasks;
using api.Core.Models;
using System.Collections.Generic;

namespace api.Core
{
    public interface IPessoaRepository
    {
        Task<Pessoa> GetPessoaDetail(int id, bool includeRelated = true);
        Task<List<Pessoa>> GetPessoasList();
        //void Add(Vehicle vehicle);
        //void Remove(Vehicle vehicle);
    }
}