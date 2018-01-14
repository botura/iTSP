using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tsp.Database.Itau;
using Tsp.Models;
using Tsp.Models.Itau;

namespace Tsp.Controllers.Itau
{
    [Route("/api/itau")]
    public class CarteiraAtualController : Controller
    {
        // Carteiras
        [HttpGet("carteiraatualcarteiras")]
        public IEnumerable<string> GetCarteiraAtualCarteiras()
        {
            DateTime start = DateTime.Now;
            IEnumerable<string> result = CarteiraAtualDB.GetCarteiras();
            Console.WriteLine("----------");
            Console.WriteLine("/api/itau/carteiraatualcarteiras");
            Console.WriteLine("Executado em: " + (DateTime.Now - start));
            return result;
        }


        // Grafico Somatoria por UF
        [HttpGet("carteiraatualuf")]
        public IEnumerable<MdGrafico> GetCarteiraAtualSomatoriaUf(string dataArquivo)
        {
            DateTime start = DateTime.Now;
            string data = dataArquivo.Substring(6, 4) + "-" + dataArquivo.Substring(3, 2) + "-" + dataArquivo.Substring(0, 2);
            IEnumerable<MdGrafico> result = CarteiraAtualDB.GetSomatoriaUf(data);
            Console.WriteLine("----------");
            Console.WriteLine("/api/itau/carteiraatualuf");
            Console.WriteLine("Executado em: " + (DateTime.Now - start));
            return result;
        }


        // Grafico Somatoria por Produto
        [HttpGet("carteiraatualentidade")]
        public IEnumerable<MdGrafico> GetCarteiraAtualSomatoriaEntidade(string dataArquivo)
        {
            DateTime start = DateTime.Now;
            string data = dataArquivo.Substring(6, 4) + "-" + dataArquivo.Substring(3, 2) + "-" + dataArquivo.Substring(0, 2);
            IEnumerable<MdGrafico> result = CarteiraAtualDB.GetSomatoriaEntidade(data);
            Console.WriteLine("----------");
            Console.WriteLine("/api/itau/carteiraatualentidade");
            Console.WriteLine("Executado em: " + (DateTime.Now - start));
            return result;
        }


        // Grid
        [HttpGet("carteiraatualgrid")]
        public IEnumerable<MdCarteiraAtual> GetCarteiraAtualGrid(string dataArquivo)
        {
            DateTime start = DateTime.Now;
            string data = dataArquivo.Substring(6, 4) + "-" + dataArquivo.Substring(3, 2) + "-" + dataArquivo.Substring(0, 2);
            IEnumerable<MdCarteiraAtual> result = CarteiraAtualDB.GetGrid(data);
            Console.WriteLine("----------");
            Console.WriteLine("/api/itau/carteiraatualgrid");
            Console.WriteLine("Executado em: " + (DateTime.Now - start));
            return result;
        }
    }
}
