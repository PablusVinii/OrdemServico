using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;


// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 21/05/2014
// ********************************************************************* 
// 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//

namespace AcessaDados
{
    public class ProprietarioEntidade
    {
        protected static Dictionary<string, string> dicionario = new Dictionary<string, string>();

        protected static void ConfigurarDicionario()
        {
            dicionario.Clear();
            dicionario.Add("Agendamento", "AGENDAMENTO");
            dicionario.Add("Usuario", "SYS_USERS");
            dicionario.Add("Funcionario", "FUNCIONARIOS");
            dicionario.Add("OrdemServico", "ORDEM_SERVICO");
            dicionario.Add("Cliente", "CLIENTES");
            dicionario.Add("TipoHora", "TIPOHORAS");
            dicionario.Add("Projeto", "PROJETOS");
        }

        //1 - exclusivo 0 - compartilhado
        public static void VerificaProprietario(string nomeEntidade, FbConnection conn, ref bool empresa, ref bool filial)
        {
            ConfigurarDicionario();

            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            using(FbCommand comando = conn.CreateCommand())
            {
                string nomeTabela = dicionario[nomeEntidade];

                comando.CommandText = "SELECT ACESSOEMPRESA, ACESSOFILIAL FROM SYS_TABLES WHERE ENTIDADE = @ENTIDADE";
                comando.Parameters.AddWithValue("@ENTIDADE", nomeTabela);

                using (FbDataReader leitor = comando.ExecuteReader())
                {
                    if (leitor.HasRows)
                    {
                        int indexEmpresa = leitor.GetOrdinal("ACESSOEMPRESA");
                        int indexFilial = leitor.GetOrdinal("ACESSOFILIAL");

                        while (leitor.Read())
                        {
                            empresa = Convert.ToBoolean(leitor.GetInt32(indexEmpresa));
                            filial = Convert.ToBoolean(leitor.GetInt32(indexFilial));
                        }   
                    }
                }
            }
        }
    }
}
