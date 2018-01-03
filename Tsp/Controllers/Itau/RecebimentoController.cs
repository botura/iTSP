using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Tsp.Models.Itau;
using Tsp.Database.Itau;
using Tsp.Models;

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

        // Grafico Somatoria por UF
        [HttpGet("somatoriaUf")]
        public IEnumerable<MdGrafico> GetRecebimentoUF(string dataInicial, string dataFinal)
        {
            DateTime start = DateTime.Now;
            IEnumerable<MdGrafico> result = ItauRecebimentoDB.GetSomatoriaUf(dataInicial, dataFinal);
            Console.WriteLine("----------");
            Console.WriteLine("/api/itau/recebimento/somatoriaUf");
            Console.WriteLine("Executado em: " + (DateTime.Now - start));
            return result;
        }

        // Grafico Somatoria por produto
        [HttpGet("somatoriaProduto")]
        public IEnumerable<MdGrafico> GetRecebimentoProduto(string dataInicial, string dataFinal)
        {
            DateTime start = DateTime.Now;
            IEnumerable<MdGrafico> result = ItauRecebimentoDB.GetSomatoriaProduto(dataInicial, dataFinal);
            Console.WriteLine("----------");
            Console.WriteLine("/api/itau/recebimento/somatoriaProduto");
            Console.WriteLine("Executado em: " + (DateTime.Now - start));
            return result;
        }

        // Grafico Somatoria por data pagamento
        [HttpGet("somatoriaDataPagamento")]
        public IEnumerable<MdGrafico> GetRecebimentoDataPagamento(string dataInicial, string dataFinal)
        {
            DateTime start = DateTime.Now;
            IEnumerable<MdGrafico> result = ItauRecebimentoDB.GetSomatoriaDataPagto(dataInicial, dataFinal);
            Console.WriteLine("----------");
            Console.WriteLine("/api/itau/recebimento/somatoriaDataPagamento");
            Console.WriteLine("Executado em: " + (DateTime.Now - start));
            return result;
        }
    }
}