using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Tsp.Models.Itau;
using Tsp.Database.Itau;

namespace Tsp.Controllers.Itau
{
        [Route("/api/itau/recebimento")]
    public class RecebimentoController : Controller
    {

        // Grid
        [HttpGet("grid")]
        public IEnumerable<MdRecebimento> GetRecebimentoGrid(string dataInicial, string dataFinal)
        {
            DateTime start = DateTime.Now;
            IEnumerable<MdRecebimento> result = ItauRecebimentoDB.GetGrid(dataInicial, dataFinal);
            Console.WriteLine("----------");
            Console.WriteLine("/api/itau/recebimento/grid");
            Console.WriteLine("Executado em: " + (DateTime.Now - start));
            return result;
        }
    }
}