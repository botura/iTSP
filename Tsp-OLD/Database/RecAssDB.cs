
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using Tsp.Models;
using System.Globalization;
using System.Threading.Tasks;
using System.Text;

namespace Tsp.Database
{
    public class RecAssDB
    {
        // GetGrid
        public static IEnumerable<MdRecAss> GetGrid(string dataInicial, string dataFinal)
        {
            var list = new List<MdRecAss>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = $"SELECT * FROM rec_ass WHERE data_pagamento >= '{ dataInicial }' AND data_pagamento <= '{ dataFinal }'";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var recAss = new MdRecAss();
                    recAss.produto = (string)reader["produto"];
                    recAss.nome_gerente = (string)reader["nome_gerente"];
                    recAss.data_pagamento = MbGet.Date(reader["data_pagamento"]).GetValueOrDefault().ToString("yyyy/MM/dd");
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
        public static IEnumerable<MdGrafico> GetSomatoriaUf(string dataInicial, string dataFinal)
        {
            var list = new List<MdGrafico>();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            string sql = $"CALL estatistica_poruf('{dataInicial}', '{dataFinal}')";

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
            string sql = $"CALL estatistica_porproduto('{dataInicial}', '{dataFinal}')";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var grafico = new MdGrafico();
                    grafico.groupby = (string)reader["produto"] + " || " + (string)reader["nome_gerente"];
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
            string sql = $"CALL estatistica_pordatapagamento('{dataInicial}', '{dataFinal}')";

            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    var grafico = new MdGrafico();
                    grafico.groupby = MbGet.Date(reader["data_pagamento"]).GetValueOrDefault().ToString("yyyy/MM/dd");
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

        public static bool InsertV3(string[] AllLines, string fileName)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            MdUploadRecAss reg = new MdUploadRecAss();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            Console.WriteLine("Vai iniciar o For");
            query.Append($"INSERT INTO rec_ass" +
                    " (`tipo_pagamento_ge`, `tipo_pagamento`, `processamento`," +
                    " `cod_receb`, `credor`, `cliente`, `cpf`," +
                    " `nome`, `cod_produto`, `produto`," +
                    " `contrato`, `vencimento_prestacao`, `numero_prestacao`, `data_pagamento`," +
                    " `valor_pago`, `bonificacao_maxima`, `bonificacao_a_receber`, `valor_honorarios`," +
                    " `valor_adicional`, `operador`, `cod_gerente`, `nome_gerente`, `uf_comer`," +
                    " `uf_resid`, `campanha_recebimento`, `campanha_cinco`, `campanha_restante`," +
                    " `indicador`, `assessoria`, `debito_nao_ajuizavel`, `qtde_parcela_do_acordo`," +
                    " `qtde_de_parcelas_em_aberto`, `parcela_do_acordo`, `cod_entidade`," +
                    " `valor_principal`, `desconto_aplicado`, `atraso`, `nivel_negociacao`," +
                    " `divida_atualizada`, `linhaArquivo`, `nomeArquivo`)" +
                    " VALUES ");
            for (int i = 1; i < AllLines.Length; i++)
            {
                reg = ProcessaLinhaRec_ass(AllLines[i]);
                reg.linhaArquivo = i;
                reg.nomeArquivo = fileName;
                query.Append($"('{reg.tipo_pagamento_ge}', '{reg.tipo_pagamento}', '{reg.processamento.ToString("yyyy-MM-dd")}'," +
                $" '{reg.cod_receb}', '{reg.credor}', '{reg.cliente}', '{reg.cpf}'," +
                $" '{reg.nome}', '{reg.cod_produto}', '{reg.produto}'," +
                $" '{reg.contrato}', '{reg.vencimento_prestacao.ToString("yyyy-MM-dd")}', '{reg.numero_prestacao}', '{reg.data_pagamento.ToString("yyyy-MM-dd")}'," +
                $" '{reg.valor_pago.ToString("F", CultureInfo.InvariantCulture)}', '{reg.bonificacao_maxima.ToString("F", CultureInfo.InvariantCulture)}', '{reg.bonificacao_a_receber.ToString("F", CultureInfo.InvariantCulture)}', '{reg.valor_honorarios.ToString("F", CultureInfo.InvariantCulture)}'," +
                $" '{reg.valor_adicional.ToString("F", CultureInfo.InvariantCulture)}', '{reg.operador}', '{reg.cod_gerente}', '{reg.nome_gerente}', '{reg.uf_comer}'," +
                $" '{reg.uf_resid}', '{reg.campanha_recebimento}', '{reg.campanha_cinco}', '{reg.campanha_restante}'," +
                $" '{reg.indicador}', '{reg.assessoria}', '{reg.debito_nao_ajuizavel}', '{reg.qtde_parcela_do_acordo.ToString("F0", CultureInfo.InvariantCulture)}'," +
                $" '{reg.qtde_de_parcelas_em_aberto.ToString("F0", CultureInfo.InvariantCulture)}', '{reg.parcela_do_acordo.ToString("F0", CultureInfo.InvariantCulture)}', '{reg.cod_entidade}'," +
                $" '{reg.valor_principal.ToString("F", CultureInfo.InvariantCulture)}', '{reg.desconto_aplicado.ToString("F", CultureInfo.InvariantCulture)}', '{reg.atraso.ToString("F", CultureInfo.InvariantCulture)}', '{reg.nivel_negociacao.ToString("F", CultureInfo.InvariantCulture)}'," +
                $" '{reg.divida_atualizada.ToString("F", CultureInfo.InvariantCulture)}', '{reg.linhaArquivo}', '{reg.nomeArquivo}')");
                if (i < AllLines.Length - 1)
                {
                    query.Append(", ");
                }
            }
            query.Append(" ON DUPLICATE KEY UPDATE id=id");
            Console.WriteLine("Acabou o for, agora vai converter pra string.");
            cmd.CommandText = query.ToString();
            Console.WriteLine("Agora vai salvar no banco.");
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"**********ERRO: " + ex);
                // Console.WriteLine($"**********ERRO: " + cmd.CommandText);
            }
            finally
            {
                con.Close();
            }

            return true;
        }

        public static bool InsertV2(string[] AllLines, string fileName)
        {
            System.Text.StringBuilder query = new System.Text.StringBuilder();
            MdUploadRecAss reg = new MdUploadRecAss();
            MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            Console.WriteLine("Vai iniciar o For");
            for (int i = 1; i < AllLines.Length; i++)
            {
                reg = ProcessaLinhaRec_ass(AllLines[i]);
                reg.linhaArquivo = i;
                reg.nomeArquivo = fileName;
                query.Append($"INSERT INTO rec_ass" +
                        " (`tipo_pagamento_ge`, `tipo_pagamento`, `processamento`," +
                        " `cod_receb`, `credor`, `cliente`, `cpf`," +
                        " `nome`, `cod_produto`, `produto`," +
                        " `contrato`, `vencimento_prestacao`, `numero_prestacao`, `data_pagamento`," +
                        " `valor_pago`, `bonificacao_maxima`, `bonificacao_a_receber`, `valor_honorarios`," +
                        " `valor_adicional`, `operador`, `cod_gerente`, `nome_gerente`, `uf_comer`," +
                        " `uf_resid`, `campanha_recebimento`, `campanha_cinco`, `campanha_restante`," +
                        " `indicador`, `assessoria`, `debito_nao_ajuizavel`, `qtde_parcela_do_acordo`," +
                        " `qtde_de_parcelas_em_aberto`, `parcela_do_acordo`, `cod_entidade`," +
                        " `valor_principal`, `desconto_aplicado`, `atraso`, `nivel_negociacao`," +
                        " `divida_atualizada`, `linhaArquivo`, `nomeArquivo`)" +
                        " VALUES" +
                        $" ('{reg.tipo_pagamento_ge}', '{reg.tipo_pagamento}', '{reg.processamento.ToString("yyyy-MM-dd")}'," +
                        $" '{reg.cod_receb}', '{reg.credor}', '{reg.cliente}', '{reg.cpf}'," +
                        $" '{reg.nome}', '{reg.cod_produto}', '{reg.produto}'," +
                        $" '{reg.contrato}', '{reg.vencimento_prestacao.ToString("yyyy-MM-dd")}', '{reg.numero_prestacao}', '{reg.data_pagamento.ToString("yyyy-MM-dd")}'," +
                        $" '{reg.valor_pago.ToString("F", CultureInfo.InvariantCulture)}', '{reg.bonificacao_maxima.ToString("F", CultureInfo.InvariantCulture)}', '{reg.bonificacao_a_receber.ToString("F", CultureInfo.InvariantCulture)}', '{reg.valor_honorarios.ToString("F", CultureInfo.InvariantCulture)}'," +
                        $" '{reg.valor_adicional.ToString("F", CultureInfo.InvariantCulture)}', '{reg.operador}', '{reg.cod_gerente}', '{reg.nome_gerente}', '{reg.uf_comer}'," +
                        $" '{reg.uf_resid}', '{reg.campanha_recebimento}', '{reg.campanha_cinco}', '{reg.campanha_restante}'," +
                        $" '{reg.indicador}', '{reg.assessoria}', '{reg.debito_nao_ajuizavel}', '{reg.qtde_parcela_do_acordo.ToString("F0", CultureInfo.InvariantCulture)}'," +
                        $" '{reg.qtde_de_parcelas_em_aberto.ToString("F0", CultureInfo.InvariantCulture)}', '{reg.parcela_do_acordo.ToString("F0", CultureInfo.InvariantCulture)}', '{reg.cod_entidade}'," +
                        $" '{reg.valor_principal.ToString("F", CultureInfo.InvariantCulture)}', '{reg.desconto_aplicado.ToString("F", CultureInfo.InvariantCulture)}', '{reg.atraso.ToString("F", CultureInfo.InvariantCulture)}', '{reg.nivel_negociacao.ToString("F", CultureInfo.InvariantCulture)}'," +
                        $" '{reg.divida_atualizada.ToString("F", CultureInfo.InvariantCulture)}', '{reg.linhaArquivo}', '{reg.nomeArquivo}');");
            }
            Console.WriteLine("Acabou o for, agora vai converter pra string.");
            cmd.CommandText = query.ToString();
            Console.WriteLine("Agora vai salvar no banco.");
            try
            {
                con.Open();

                cmd.ExecuteNonQuery();
            }
            catch
            {
                // Console.WriteLine($"**********ERRO NA LINHA: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            return true;
        }

        public static bool Insert(string[] AllLines, string fileName)
        {
            Parallel.For(1, AllLines.Length, i =>
            {
                string query = "";
                MdUploadRecAss reg = new MdUploadRecAss();
                reg = ProcessaLinhaRec_ass(AllLines[i]);
                reg.linhaArquivo = i;
                reg.nomeArquivo = fileName;
                query = $"INSERT INTO rec_ass" +
                        " (`tipo_pagamento_ge`, `tipo_pagamento`, `processamento`," +
                        " `cod_receb`, `credor`, `cliente`, `cpf`," +
                        " `nome`, `cod_produto`, `produto`," +
                        " `contrato`, `vencimento_prestacao`, `numero_prestacao`, `data_pagamento`," +
                        " `valor_pago`, `bonificacao_maxima`, `bonificacao_a_receber`, `valor_honorarios`," +
                        " `valor_adicional`, `operador`, `cod_gerente`, `nome_gerente`, `uf_comer`," +
                        " `uf_resid`, `campanha_recebimento`, `campanha_cinco`, `campanha_restante`," +
                        " `indicador`, `assessoria`, `debito_nao_ajuizavel`, `qtde_parcela_do_acordo`," +
                        " `qtde_de_parcelas_em_aberto`, `parcela_do_acordo`, `cod_entidade`," +
                        " `valor_principal`, `desconto_aplicado`, `atraso`, `nivel_negociacao`," +
                        " `divida_atualizada`, `linhaArquivo`, `nomeArquivo`)" +
                        " VALUES" +
                        $" ('{reg.tipo_pagamento_ge}', '{reg.tipo_pagamento}', '{reg.processamento.ToString("yyyy-MM-dd")}'," +
                        $" '{reg.cod_receb}', '{reg.credor}', '{reg.cliente}', '{reg.cpf}'," +
                        $" '{reg.nome}', '{reg.cod_produto}', '{reg.produto}'," +
                        $" '{reg.contrato}', '{reg.vencimento_prestacao.ToString("yyyy-MM-dd")}', '{reg.numero_prestacao}', '{reg.data_pagamento.ToString("yyyy-MM-dd")}'," +
                        $" '{reg.valor_pago.ToString("F", CultureInfo.InvariantCulture)}', '{reg.bonificacao_maxima.ToString("F", CultureInfo.InvariantCulture)}', '{reg.bonificacao_a_receber.ToString("F", CultureInfo.InvariantCulture)}', '{reg.valor_honorarios.ToString("F", CultureInfo.InvariantCulture)}'," +
                        $" '{reg.valor_adicional.ToString("F", CultureInfo.InvariantCulture)}', '{reg.operador}', '{reg.cod_gerente}', '{reg.nome_gerente}', '{reg.uf_comer}'," +
                        $" '{reg.uf_resid}', '{reg.campanha_recebimento}', '{reg.campanha_cinco}', '{reg.campanha_restante}'," +
                        $" '{reg.indicador}', '{reg.assessoria}', '{reg.debito_nao_ajuizavel}', '{reg.qtde_parcela_do_acordo.ToString("F0", CultureInfo.InvariantCulture)}'," +
                        $" '{reg.qtde_de_parcelas_em_aberto.ToString("F0", CultureInfo.InvariantCulture)}', '{reg.parcela_do_acordo.ToString("F0", CultureInfo.InvariantCulture)}', '{reg.cod_entidade}'," +
                        $" '{reg.valor_principal.ToString("F", CultureInfo.InvariantCulture)}', '{reg.desconto_aplicado.ToString("F", CultureInfo.InvariantCulture)}', '{reg.atraso.ToString("F", CultureInfo.InvariantCulture)}', '{reg.nivel_negociacao.ToString("F", CultureInfo.InvariantCulture)}'," +
                        $" '{reg.divida_atualizada.ToString("F", CultureInfo.InvariantCulture)}', '{reg.linhaArquivo}', '{reg.nomeArquivo}')";
                MySqlConnection con = new MySqlConnection(_Global.ConnectionString);
                MySqlCommand cmd = new MySqlCommand(query, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"**********ERRO NA LINHA { i }: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            });

            return true;
        }


        private static MdUploadRecAss ProcessaLinhaRec_ass(string linha)
        {
            var rec_ass = new MdUploadRecAss();
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
            return rec_ass;
        }
    }
}
