using System.Threading.Tasks;
using api.Core.Models;
using System.Collections.Generic;

namespace api.Core
{
    public interface IBancoRepository
    {
        Task<List<Banco>> GetList();
    }
}