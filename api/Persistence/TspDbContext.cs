using Microsoft.EntityFrameworkCore;
using api.Core.Models;

namespace api.Persistence
{
    public class TspDbContext : DbContext
    {
        public  DbSet<Cidade> Cidades { get; set; }
        public  DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<ContaCorrente> ContaCorrentes { get; set; }
        public DbSet<RelatorioRec_ass> Rec_ass { get; set; }

        public TspDbContext(DbContextOptions<TspDbContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.ToTable("cidade");

                entity.HasIndex(e => e.Cidade1)
                    .HasName("Cidade_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Uf)
                    .HasName("fk_UF_idx");

                entity.HasIndex(e => new { e.Cidade1, e.Uf })
                    .HasName("fk_uf");

                entity.Property(e => e.CidadeId)
                    .HasColumnName("CidadeID")
                    .HasColumnType("int(10)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cidade1)
                    .IsRequired()
                    .HasColumnName("Cidade")
                    .HasMaxLength(45);

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("UF")
                    .HasMaxLength(2);
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("pessoa");

                entity.HasIndex(e => e.CidadeId)
                    .HasName("fk_cidadeid_idx");

                entity.Property(e => e.PessoaId)
                    .HasColumnName("PessoaID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bairro).HasMaxLength(45);

                entity.Property(e => e.Cep)
                    .HasColumnName("CEP")
                    .HasMaxLength(9);

                entity.Property(e => e.CidadeId)
                    .HasColumnName("CidadeID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(18);

                entity.Property(e => e.Complemento).HasMaxLength(20);

                entity.Property(e => e.Cpf)
                    .HasColumnName("CPF")
                    .HasMaxLength(14);

                entity.Property(e => e.Cpfconjuge)
                    .HasColumnName("CPFConjuge")
                    .HasMaxLength(14);

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.EmailConjuge).HasMaxLength(45);

                entity.Property(e => e.EmailContato1).HasMaxLength(45);

                entity.Property(e => e.EmailContato2).HasMaxLength(45);

                entity.Property(e => e.EmailContato3).HasMaxLength(45);

                entity.Property(e => e.Endereco).HasMaxLength(45);

                entity.Property(e => e.EstadoCivil).HasMaxLength(45);

                entity.Property(e => e.FlagCliente)
                    .HasColumnName("flagCliente")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.FlagCorretor)
                    .HasColumnName("flagCorretor")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.FlagFornecedor)
                    .HasColumnName("flagFornecedor")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.FlagPessoaJuridica)
                    .HasColumnName("flagPessoaJuridica")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.FornecedorDe).HasMaxLength(200);

                entity.Property(e => e.Nome).HasMaxLength(45);

                entity.Property(e => e.NomeConjuge).HasMaxLength(45);

                entity.Property(e => e.NomeContato1).HasMaxLength(45);

                entity.Property(e => e.NomeContato2).HasMaxLength(45);

                entity.Property(e => e.NomeContato3).HasMaxLength(45);

                entity.Property(e => e.NomeFantasia).HasMaxLength(45);

                entity.Property(e => e.Numero).HasMaxLength(10);

                entity.Property(e => e.Observacao).HasMaxLength(200);

                entity.Property(e => e.Profissao).HasMaxLength(45);

                entity.Property(e => e.ProfissaoConjuge).HasMaxLength(45);

                entity.Property(e => e.RazaoSocial).HasMaxLength(60);

                entity.Property(e => e.RegimeCasamento).HasMaxLength(45);

                entity.Property(e => e.Rg)
                    .HasColumnName("RG")
                    .HasMaxLength(20);

                entity.Property(e => e.Rgconjuge)
                    .HasColumnName("RGConjuge")
                    .HasMaxLength(20);

                entity.Property(e => e.SexoMasculino)
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.SexoMasculinoConjuge).HasColumnType("tinyint(1)");

                entity.Property(e => e.Telefone1).HasMaxLength(15);

                entity.Property(e => e.Telefone2).HasMaxLength(15);

                entity.Property(e => e.Telefone3).HasMaxLength(15);

                entity.Property(e => e.Telefone4).HasMaxLength(15);

                entity.Property(e => e.TelefoneContato1).HasMaxLength(15);

                entity.Property(e => e.TelefoneContato2).HasMaxLength(15);

                entity.Property(e => e.TelefoneContato3).HasMaxLength(15);

                //entity.HasOne(d => d.Cidade)
                //    .WithMany(p => p.Pessoa)
                //    .HasForeignKey(d => d.CidadeId)
                //    .HasConstraintName("fk_cidadeid");
            });
        }
    }
}
