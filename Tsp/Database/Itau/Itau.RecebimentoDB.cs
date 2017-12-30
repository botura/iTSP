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
    }
}