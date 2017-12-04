
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using Tsp.Models;

namespace Tsp.Database
{
    public class RecAssDB
    {
        // GetGrid
        public static IEnumerable<MdRecAss> GetGrid()
        {
            var list = new List<MdRecAss>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = "SELECT * FROM rec_ass";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var recAss = new MdRecAss();
                    recAss.produto = (string)reader["produto"];
                    recAss.data_pagamento = (DateTime)reader["data_pagamento"];
                    recAss.valor_pago = (decimal)reader["valor_pago"];
                    recAss.uf_resid = (string)reader["uf_resid"];
                    list.Add(recAss);
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            return list;
        }

        // GetSomatoriaUf
        public static IEnumerable<MdGrafico> GetSomatoriaUf()
        {
            var list = new List<MdGrafico>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = "CALL estatistica_poruf()";

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
        public static IEnumerable<MdGrafico> GetSomatoriaProduto()
        {
            var list = new List<MdGrafico>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = "CALL estatistica_porproduto()";

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
        public static IEnumerable<MdGrafico> GetSomatoriaDataPagto()
        {
            var list = new List<MdGrafico>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = "CALL estatistica_pordatapagamento()";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var grafico = new MdGrafico();
                    grafico.groupby = MbGet.Date(reader["data_pagamento"]).GetValueOrDefault().ToString("d");
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
