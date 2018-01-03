using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Tsp.Models;
using Tsp.Models.Itau;

namespace Tsp.Database.Itau
{
    public class ItauRecebimentoDB
    {
        // GetGrid
        public static IEnumerable<MdRecebimento> GetGrid(string dataInicial, string dataFinal)
        {
            var list = new List<MdRecebimento>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = $"SELECT * FROM itsp.`Itau.VIEW.RecAss_RejMis`" +
                         $" WHERE data_pagamento >= '{ dataInicial }' AND data_pagamento <= '{ dataFinal }'" +
                         $" ORDER BY data_pagamento";
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var rec = new MdRecebimento();
                    rec.uf_resid = MbGet.Str(reader["uf_resid"]);
                    rec.cpf = MbGet.Str(reader["cpf"]);
                    rec.contrato = MbGet.Str(reader["contrato"]);
                    rec.produto = MbGet.Str(reader["produto"]);
                    rec.data_pagamento = MbGet.Date(reader["data_pagamento"]).GetValueOrDefault().ToString("yyyy/MM/dd");
                    rec.valor_pago = MbGet.Dec(reader["valor_pago"]);
                    rec.atraso = MbGet.Int(reader["atraso"]);
                    rec.tabela = MbGet.Str(reader["tabela"]);
                    list.Add(rec);
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            return list;
        }


        // GetSomatoriaUf
        public static IEnumerable<MdGrafico> GetSomatoriaUf(string dataInicial, string dataFinal)
        {
            var list = new List<MdGrafico>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = $"CALL `Itau.RejMis.estatistica_poruf`('{dataInicial}', '{dataFinal}')";

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
        public static IEnumerable<MdGrafico> GetSomatoriaProduto(string dataInicial, string dataFinal)
        {
            var list = new List<MdGrafico>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = $"CALL `Itau.RejMis.estatistica_porproduto`('{dataInicial}', '{dataFinal}')";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var grafico = new MdGrafico();
                    grafico.groupby = (string)reader["produto"];
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


        // GetSomatoriaDataPagto
        public static IEnumerable<MdGrafico> GetSomatoriaDataPagto(string dataInicial, string dataFinal)
        {
            var list = new List<MdGrafico>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = $"CALL `Itau.RejMis.estatistica_pordatapagamento`('{dataInicial}', '{dataFinal}')";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var grafico = new MdGrafico();
                    grafico.groupby = grafico.groupby = MbGet.Date(reader["data_pagamento"]).GetValueOrDefault().ToString("yyyy/MM/dd");
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
    }
}