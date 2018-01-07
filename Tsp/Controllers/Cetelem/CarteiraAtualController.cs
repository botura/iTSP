using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tsp.Database.Cetelem;
using Tsp.Models;
using Tsp.Models.Cetelem;

namespace Tsp.Controllers.Cetelem
{
    [Route("/api/cetelem/carteira")]
    public class CarteiraAtualController : Controller
    {
        // Grafico Somatoria por UF
        [HttpGet("somatoriaUf")]
        public IEnumerable<MdGrafico> GetCarteiraAtualSomatoriaUf()
        {
            DateTime start = DateTime.Now;
            IEnumerable<MdGrafico> result = CarteiraDB.GetSomatoriaUf();
            Console.WriteLine("----------");
            Console.WriteLine("/api/cetelem/carteira/somatoriaUf");
            Console.WriteLine("Executado em: " + (DateTime.Now - start));
            return result;
        }


        // Grid
        [HttpGet("grid")]
        public IEnumerable<MdCarteiraAtual> GetCarteiraAtualGrid()
        {
            DateTime start = DateTime.Now;
            IEnumerable<MdCarteiraAtual> result = CarteiraDB.GetGrid();
            Console.WriteLine("----------");
            Console.WriteLine("/api/cetelem/carteira/grid");
            Console.WriteLine("Executado em: " + (DateTime.Now - start));
            return result;
        }
    }
}
