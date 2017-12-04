using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tsp.Database;
using Tsp.Models;

namespace Tsp.Controllers
{
    [Route("/api/rec_ass")]
    public class RecAssController : Controller
    {
        // Construtor
        public RecAssController() { }

        // Grid
        [HttpGet("grid")]
        public IEnumerable<MdRecAss> GetRecAssGrid()
        {
            Console.WriteLine("");
            Console.WriteLine("/api/rec_ass/grid");
            return RecAssDB.GetGrid();
        }

        // Grafico Somatoria por UF
        [HttpGet("somatoriaUf")]
        public IEnumerable<MdGrafico> GetRecAssSomatoriaUf()
        {
            Console.WriteLine("");
            Console.WriteLine("/api/rec_ass/somatoriaUf");
            return RecAssDB.GetSomatoriaUf();
        }

        // Grafico Somatoria por produto
        [HttpGet("somatoriaProduto")]
        public IEnumerable<MdGrafico> GetRecAssSomatoriaProduto()
        {
            Console.WriteLine("");
            Console.WriteLine("/api/rec_ass/somatoriaProduto");
            return RecAssDB.GetSomatoriaProduto();
        }
        
        // Grafico Somatoria por produto
        [HttpGet("somatoriaDataPagamento")]
        public IEnumerable<MdGrafico> GetRecAssSomatoriaDataPagto()
        {
            Console.WriteLine("");
            Console.WriteLine("/api/rec_ass/somatoriaDataPagamento");
            return RecAssDB.GetSomatoriaDataPagto();
        }
    }
}

