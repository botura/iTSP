using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tsp.Database;
using Tsp.Models;

namespace Tsp.Controllers
{
    [Route("/api/rec_ass")]
    public class RecAssController : Controller
    {
        private readonly int MAX_BYTES = 100 * 1024 * 1024;
        private readonly IHostingEnvironment host;

        // Construtor
        public RecAssController(IHostingEnvironment host)
        {
            this.host = host;
        }

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
        public IEnumerable<MdGrafico> GetRecAssSomatoriaUf(string dataInicial, string dataFinal)
        {
            Console.WriteLine("");
            Console.WriteLine("/api/rec_ass/somatoriaUf");
            return RecAssDB.GetSomatoriaUf(dataInicial, dataFinal);
        }

        // Grafico Somatoria por produto
        [HttpGet("somatoriaProduto")]
        public IEnumerable<MdGrafico> GetRecAssSomatoriaProduto(string dataInicial, string dataFinal)
        {
            Console.WriteLine("");
            Console.WriteLine("/api/rec_ass/somatoriaProduto");
            return RecAssDB.GetSomatoriaProduto(dataInicial, dataFinal);
        }

        // Grafico Somatoria por produto
        [HttpGet("somatoriaDataPagamento")]
        public IEnumerable<MdGrafico> GetRecAssSomatoriaDataPagto(string dataInicial, string dataFinal)
        {
            Console.WriteLine("");
            Console.WriteLine("/api/rec_ass/somatoriaDataPagamento");
            Console.WriteLine("Data inicial: " + dataInicial);
            Console.WriteLine("Data final: " + dataFinal);
            return RecAssDB.GetSomatoriaDataPagto(dataInicial, dataFinal);
        }

        // Upload do relatório rec_ass
        [HttpPost("upload")]
        public async Task<IActionResult> UploadRec_Ass(IFormFile file)
        {
            if (file == null) return BadRequest("Nenhum arquivo");
            if (file.Length == 0) return BadRequest("Arquivo vazio");
            if (file.Length > MAX_BYTES) return BadRequest("Arquivo muito grande");
            if (Path.GetExtension(file.FileName).ToUpper() != ".TXT") return BadRequest("Tipo de arquivo inválido");

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads/rec_ass");
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var filePath = Path.Combine(uploadsFolderPath, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Le o arquivo na memoria
            string[] AllLines = null;
            AllLines = new string[500000]; //only allocate memory here
            AllLines = System.IO.File.ReadAllLines(filePath, System.Text.Encoding.UTF8);

            DateTime start = DateTime.Now;
            DateTime end;
            Console.WriteLine("");
            Console.WriteLine("/api/rec_ass/upload");
            Console.WriteLine("Started at: " + start.ToLongTimeString());

            RecAssDB.Insert(AllLines, file.FileName);

            end = DateTime.Now;
            Console.WriteLine("Finished at: " + end.ToLongTimeString());
            Console.WriteLine("Time: " + (end - start));
            Console.WriteLine();

            return Ok("Linhas processadas");
        }

        // Teste
        [HttpGet("teste")]
        public bool GetTeste(string filtro)
        {
            Console.WriteLine("/api/rec_ass/teste");
            Console.WriteLine(filtro);
            return true;
        }

    }
}

