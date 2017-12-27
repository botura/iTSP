using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Tsp.Models;
using Tsp.Models.Itau;

namespace Tsp.Database.Itau
{
    public class CarteiraAtualDB
    {
        // GetCarteiras
        public static IEnumerable<string> GetCarteiras()
        {
            var list = new List<string>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = "SELECT DISTINCT ca.Data_Arquivo FROM carteira_atual AS ca";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    list.Add(MbGet.Date(reader["Data_Arquivo"]).GetValueOrDefault().ToString("dd/MM/yyyy"));
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            return list;
        }


        // GetSomatoriaUf
        public static IEnumerable<MdGrafico> GetSomatoriaUf(string dataArquivo)
        {
            var list = new List<MdGrafico>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = $"CALL carteiraatual_poruf('{dataArquivo}')";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var grafico = new MdGrafico();
                    grafico.groupby = (string)reader["uf_resid"];
                    grafico.soma = MbGet.Dec(reader["soma"]);
                    grafico.valor_em_porc = MbGet.Dec(reader["valor_em_porc"]);
                    grafico.tickets = MbGet.Int(reader["tickets"]);
                    grafico.tickets_em_porc = MbGet.Dec(reader["tickets_em_porc"]);
                    grafico.ticketMedio = MbGet.Dec(reader["ticketMedio"]);
                    grafico.totalRegistros = MbGet.Int(reader["totalRegistros"]);
                    grafico.totalValor = MbGet.Dec(reader["totalValor"]);
                    list.Add(grafico);
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            return list;
        }


        // GetSomatoriaProduto
        public static IEnumerable<MdGrafico> GetSomatoriaEntidade(string dataArquivo)
        {
            var list = new List<MdGrafico>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = $"CALL carteiraatual_porEntidade('{dataArquivo}')";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var grafico = new MdGrafico();
                    grafico.groupby = MbGet.Str(reader["Entidade"]);
                    grafico.soma = MbGet.Dec(reader["soma"]);
                    grafico.valor_em_porc = MbGet.Dec(reader["valor_em_porc"]);
                    grafico.tickets = MbGet.Int(reader["tickets"]);
                    grafico.tickets_em_porc = MbGet.Dec(reader["tickets_em_porc"]);
                    grafico.ticketMedio = MbGet.Dec(reader["ticketMedio"]);
                    grafico.totalRegistros = MbGet.Int(reader["totalRegistros"]);
                    grafico.totalValor = MbGet.Dec(reader["totalValor"]);
                    list.Add(grafico);
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            return list;
        }


        // GetGrid
        public static IEnumerable<MdCarteiraAtual> GetGrid(string dataArquivo)
        {
            var list = new List<MdCarteiraAtual>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = $"SELECT UF_Resid, CIDADE_Resid, Produto_Recup, Atraso, Parcela, PrincipalTotal, Situacao_Descricao," +
                         $" Acordo, Entidade, Falecido, Orgao, SubOrgao, Data_ultimo_desconto, Data_ultimo_pagamento," +
                         $" Plano_parcelas, ValorParcelas_Vencido, ValorParcela, Data_Inicio_Contrato" +
                         $" FROM itsp.carteira_atual" +
                         $" WHERE Data_Arquivo = '{ dataArquivo }'";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var ca = new MdCarteiraAtual();
                    ca.UF_Resid = MbGet.Str(reader["UF_Resid"]);
                    ca.CIDADE_Resid = MbGet.Str(reader["CIDADE_Resid"]);
                    ca.Produto_Recup = MbGet.Str(reader["Produto_Recup"]);
                    ca.Atraso = MbGet.Int(reader["Atraso"]);
                    ca.Parcela = MbGet.Int(reader["Parcela"]);
                    ca.PrincipalTotal = MbGet.Dec(reader["PrincipalTotal"]);
                    ca.Situacao_Descricao = MbGet.Str(reader["Situacao_Descricao"]);
                    ca.Acordo = MbGet.Str(reader["Acordo"]);
                    ca.Entidade = MbGet.Str(reader["Entidade"]);
                    ca.Falecido = MbGet.Str(reader["Falecido"]);
                    ca.Orgao = MbGet.Str(reader["Orgao"]);
                    ca.SubOrgao = MbGet.Str(reader["SubOrgao"]);
                    ca.Data_ultimo_desconto = MbGet.Date(reader["Data_ultimo_desconto"]).GetValueOrDefault().ToString("yyyy/MM/dd");
                    ca.Data_ultimo_pagamento = MbGet.Date(reader["Data_ultimo_pagamento"]).GetValueOrDefault().ToString("yyyy/MM/dd");
                    ca.Plano_parcelas = MbGet.Int(reader["Plano_parcelas"]);
                    ca.ValorParcelas_Vencido = MbGet.Dec(reader["ValorParcelas_Vencido"]);
                    ca.ValorParcela = MbGet.Dec(reader["ValorParcela"]);
                    ca.Data_Inicio_Contrato = MbGet.Date(reader["Data_Inicio_Contrato"]).GetValueOrDefault().ToString("yyyy/MM/dd");
                    list.Add(ca);
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            return list;
        }
    }
}