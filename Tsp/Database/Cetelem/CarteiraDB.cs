using Tsp.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using Tsp.Models.Cetelem;

namespace Tsp.Database.Cetelem
{
    public class CarteiraDB
    {
        // GetSomatoriaUf
        public static IEnumerable<MdGrafico> GetSomatoriaUf()
        {
            var list = new List<MdGrafico>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = $"CALL `Cetelem.Carteira.PorUf`()";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var grafico = new MdGrafico();
                    grafico.groupby = (string)reader["uf"];
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
        public static IEnumerable<MdCarteiraAtual> GetGrid()
        {
            var list = new List<MdCarteiraAtual>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = "SELECT * FROM itsp.`Cetelem.VIEW.Carteira`";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var ca = new MdCarteiraAtual();
                    ca.contrato = MbGet.Str(reader["contrato"]);
                    ca.valor_financiado = MbGet.Dec(reader["valor_financiado"]);
                    ca.valor_prestacao = MbGet.Dec(reader["valor_prestacao"]);
                    ca.uf = MbGet.Str(reader["uf"]);
                    ca.nome_loja = MbGet.Str(reader["nome_loja"]);
                    ca.nome_empresa = MbGet.Str(reader["nome_empresa"]);
                    ca.processo = MbGet.Str(reader["processo"]);
                    ca.risco = MbGet.Dec(reader["risco"]);
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