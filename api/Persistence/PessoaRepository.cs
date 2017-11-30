using api.Core;
using api.Core.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api.Persistence
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly TspDbContext context;
        public PessoaRepository(TspDbContext context)
        {
            this.context = context;
        }

        public async Task<Pessoa> GetPessoaDetail(int id, bool includeRelated = false)
        {
            //if (!includeRelated)
            //return await context.Pessoas.FindAsync(id);
            return await context.Pessoas.Include(p => p.Cidade).SingleOrDefaultAsync(p => p.PessoaId == id);
        }

        public async Task<List<Pessoa>> GetPessoasList()
        {
            return await context.Pessoas
                .OrderBy(p => p.Nome)
                .Include(p => p.Cidade)
                .ToListAsync();
            // return await context.Pessoas.FromSql("SELECT `p`.`PessoaID`, `p`.`Bairro`, `p`.`CEP`, `p`.`CidadeID`, `p`.`CNPJ`, `p`.`Complemento`, `p`.`CPF`, `p`.`CPFConjuge`, `p`.`Email`, `p`.`EmailConjuge`, `p`.`EmailContato1`, `p`.`EmailContato2`, `p`.`EmailContato3`, `p`.`Endereco`, `p`.`EstadoCivil`, `p`.`flagCliente`, `p`.`flagCorretor`, `p`.`flagFornecedor`, `p`.`flagPessoaJuridica`, `p`.`FornecedorDe`, `p`.`Nome`, `p`.`NomeConjuge`, `p`.`NomeContato1`, `p`.`NomeContato2`, `p`.`NomeContato3`, `p`.`NomeFantasia`, `p`.`Numero`, `p`.`Observacao`, `p`.`Profissao`, `p`.`ProfissaoConjuge`, `p`.`RazaoSocial`, `p`.`RegimeCasamento`, `p`.`RG`, `p`.`RGConjuge`, `p`.`SexoMasculino`, `p`.`SexoMasculinoConjuge`, `p`.`Telefone1`, `p`.`Telefone2`, `p`.`Telefone3`, `p`.`Telefone4`, `p`.`TelefoneContato1`, `p`.`TelefoneContato2`, `p`.`TelefoneContato3`, `p.Cidade`.`CidadeID`, `p.Cidade`.`Cidade`, `p.Cidade`.`UF` FROM `pessoa` AS `p` INNER JOIN `cidade` AS `p.Cidade` ON `p`.`CidadeID` = `p.Cidade`.`CidadeID` ORDER BY `p`.`Nome` ").ToListAsync();

        }
    }
}
