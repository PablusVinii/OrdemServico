using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TransferenciaObjetos;
using TransferenciaObjetos.Pessoas;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 28/07/2014
// ********************************************************************* 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace Negocio
{
    public interface IMetaNegocio : INegocio<Meta, int>
    {
        List<Meta> Listar(int funcionario);
        List<Meta> Listar(Projeto projeto);
        double ApurarMetasPorMes(int ano, int mes, Funcionario funcionario, Projeto projeto, Indicador indicador);
        DataTable GerarRelatorio(string query, IEnumerable<FbParameter> parametros);
    }
}
