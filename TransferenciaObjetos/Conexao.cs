using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 12/05/2014
// ********************************************************************* 
// Entidade Conexao
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace TransferenciaObjetos
{

    public class Conexao
    {
        static FbConnection _conexao;
        static string _connectionString;
        public static FbConnection Instacia
        {
            get
            {
                return _conexao;
            }
        }
        public static string StringConnection
        {
            set
            {
                _connectionString = value;
            }

            get
            {
                return _connectionString;
            }
        }
        public static bool Ativar(bool act)
        {
            if (act)
            {
                _conexao = new FbConnection(_connectionString);
                _conexao.Open();
                return true;
            }
            else
            {
                if((_conexao != null) && (_conexao.State == ConnectionState.Open))
                {
                    _conexao.Close();
                }
                return false;
            }
        }
    }
}
