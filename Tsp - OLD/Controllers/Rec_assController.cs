using System.Collections.Generic;
using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Tsp.Controllers.Resources;
using Tsp.Core;
using Tsp.Core.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tsp.Controllers
{
    [Route("/api/rec_ass")]
    public class Rec_assController : Controller
    {
        private readonly int MAX_BYTES = 100 * 1024 * 1024;
        private readonly IMapper mapper;
        private readonly IRec_assRepository repository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHostingEnvironment host;

        public Rec_assController(IHostingEnvironment host, IMapper mapper, IRec_assRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.host = host;
        }

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

            for (int i = 1; i < AllLines.Length; i++)
            {
                repository.Add(ProcessaLinhaRec_ass(AllLines[i], i, file.FileName));
                // Console.WriteLine(i);
            }

            Console.WriteLine("Fim do loop, agora vou gravar no banco");
            await unitOfWork.CompleteAsync();

            end = DateTime.Now;
            Console.WriteLine("Finished at: " + end.ToLongTimeString());
            Console.WriteLine("Time: " + (end - start));
            Console.WriteLine();

            return Ok("Linhas processadas");
        }

        private RelatorioRec_ass ProcessaLinhaRec_ass(string linha, int numeroLinha, string nomeArquivo)
        {
            var rec_ass = new RelatorioRec_ass();
            decimal val;
            string[] campos;
            campos = linha.Split("|");
            rec_ass.tipo_pagamento_ge = campos[0];
            rec_ass.tipo_pagamento = campos[1];
            rec_ass.processamento = DateTime.ParseExact(campos[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            rec_ass.cod_receb = campos[3];
            rec_ass.credor = campos[4];
            rec_ass.cliente = campos[5];
            rec_ass.cpf = campos[6];
            rec_ass.nome = campos[7];
            rec_ass.cod_produto = campos[8];
            rec_ass.produto = campos[9];
            rec_ass.contrato = campos[10];
            rec_ass.vencimento_prestacao = DateTime.ParseExact(campos[11], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            rec_ass.numero_prestacao = campos[12];
            rec_ass.data_pagamento = DateTime.ParseExact(campos[13], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            rec_ass.valor_pago = Decimal.Parse(campos[14].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.bonificacao_maxima = Decimal.Parse(campos[15].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.bonificacao_a_receber = Decimal.Parse(campos[16].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.valor_honorarios = Decimal.Parse(campos[17].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.valor_adicional = (Decimal.TryParse(campos[18].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            rec_ass.operador = campos[19];
            rec_ass.cod_gerente = campos[20];
            rec_ass.nome_gerente = campos[21];
            rec_ass.uf_comer = campos[22];
            rec_ass.uf_resid = campos[23];
            rec_ass.campanha_recebimento = campos[24];
            rec_ass.campanha_cinco = campos[25];
            rec_ass.campanha_restante = campos[26];
            rec_ass.indicador = campos[27];
            rec_ass.assessoria = campos[28];
            rec_ass.debito_nao_ajuizavel = campos[29];
            rec_ass.qtde_parcela_do_acordo = (Decimal.TryParse(campos[30].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            rec_ass.qtde_de_parcelas_em_aberto = (Decimal.TryParse(campos[31].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            rec_ass.parcela_do_acordo = (Decimal.TryParse(campos[32].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture, out val) ? val : 0);
            rec_ass.cod_entidade = campos[33];
            rec_ass.valor_principal = Decimal.Parse(campos[34].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.desconto_aplicado = Decimal.Parse(campos[35].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.atraso = Decimal.Parse(campos[36].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.nivel_negociacao = Decimal.Parse(campos[37].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.divida_atualizada = Decimal.Parse(campos[38].Replace(",", "."), NumberStyles.Number, CultureInfo.InvariantCulture);
            rec_ass.linhaArquivo = numeroLinha;
            rec_ass.nomeArquivo = nomeArquivo;
            return rec_ass;
        }

        // Grid
        [HttpGet("grid")]
        public async Task<IEnumerable<Rec_assGridResource>> GetRec_assGrid()
        {
            DateTime start = DateTime.Now;
            DateTime end;
            Console.WriteLine("");
            Console.WriteLine("/api/rec_ass/grid");
            Console.WriteLine("Started at: " + start.ToLongTimeString());

            var list = await repository.GetRec_assGrid();

            Console.WriteLine("Mapping...");
            // var result = mapper.Map<IEnumerable<RelatorioRec_ass>, IEnumerable<Rec_assGridResource>>(list);

            // end = DateTime.Now;
            // Console.WriteLine("Finished at: " + end.ToLongTimeString());
            // Console.WriteLine("Time: " + (end - start));
            // Console.WriteLine();

            // return result;

            return mapper.Map<IEnumerable<RelatorioRec_ass>, IEnumerable<Rec_assGridResource>>(list);
        }

        [HttpGet("grafico-uf")]
        public async Task<IEnumerable<Rec_assGrafico>> GetRec_assGraficoUF()
        {
            return await repository.GetRec_assGraficoUF();
        }
    }

}
