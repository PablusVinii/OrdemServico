using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
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
// Data: 06/06/2014
// ********************************************************************* 
// Entidade StatusOS 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace AcessaDados
{
    public class StatusOrdemServicoDAO : ISituacaoOrdemServicoRepositorio
    {
        protected FbConnection _conexao = null;

        public StatusOrdemServicoDAO(FbConnection conn)
        {
            this._conexao = conn;

            if (this._conexao.State == System.Data.ConnectionState.Closed)
            {
                this._conexao.Open();
            }
        }

        public void Cadastrar(StatusOS obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(StatusOS obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(StatusOS obj)
        {
            throw new NotImplementedException();
        }

        public List<StatusOS> Listar(string empresa, string filial)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT SITUACAO_OS.CODIGO, SITUACAO_OS.DESCRICAO, "+
                                         "SITUACAO_OS.EMPRESA,  SITUACAO_OS.FILIAL "+
                                         "FROM  SITUACAO_OS "+
                                         "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = SITUACAO_OS.EMPRESA "+
                                         "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = SITUACAO_OS.FILIAL "+
                                         "WHERE ((SITUACAO_OS.EMPRESA = @EMPRESA) OR (SITUACAO_OS.EMPRESA = '**')) "+
                                         "AND ((SITUACAO_OS.FILIAL = @FILIAL) OR (SITUACAO_OS.FILIAL = '**'))";

                sqlCommand.Parameters.Add("@EMPRESA", empresa);
                sqlCommand.Parameters.Add("@FILIAL", filial);

                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;

                DataTable dtSituacao = new DataTable();
                sqlAdapter.Fill(dtSituacao);

                return ConverteDataTableEmList(dtSituacao).ToList();
            }
            catch (FbException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlCommand.Dispose();
            }
        }

        protected IEnumerable<StatusOS> ConverteDataTableEmList(DataTable dtSituacao)
        {
            int indexCodigo = dtSituacao.Columns["CODIGO"].Ordinal;
            int indexDescricao = dtSituacao.Columns["DESCRICAO"].Ordinal;

            foreach (DataRow linha in dtSituacao.Rows)
            {
                StatusOS umStatusOS = new StatusOS();
                umStatusOS.Codigo = Convert.ToInt32(linha[indexCodigo].ToString());
                umStatusOS.Descricao = linha[indexDescricao].ToString();
                yield return umStatusOS;
            }
        }

        public List<StatusOS> Pesquisar(string empresa, string filial, int id)
        {
            throw new NotImplementedException();
        }

        public StatusOS Consultar(string empresa, string filia, int id)
        {
            throw new NotImplementedException();
        }
    }
}
