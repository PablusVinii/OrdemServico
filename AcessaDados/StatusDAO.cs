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
// Data: 02/06/2014
// ********************************************************************* 
// Entidade Status
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace AcessaDados
{
    public class StatusDAO : IStatusRepositorio
    {
        protected FbConnection _conexao = null;

        public StatusDAO(FbConnection conn)
        {
            this._conexao = conn;

            if (this._conexao.State == ConnectionState.Closed)
            {
                this._conexao.Open();
            }
        }

        public void Cadastrar(Status obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(Status obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Status obj)
        {
            throw new NotImplementedException();
        }

        public List<Status> Listar(string empresa, string filial)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT SITUACAO.EMPRESA, SITUACAO.FILIAL, SITUACAO.CODIGO, SITUACAO.DESCRICAO "+
                                         "FROM SITUACAO LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = SITUACAO.EMPRESA "+
                                         "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = SITUACAO.FILIAL WHERE "+
                                         "((SITUACAO.EMPRESA  = '99') OR (SITUACAO.EMPRESA = '**')) AND "+
                                         "((SITUACAO.FILIAL = '99') OR (SITUACAO.FILIAL = '**'))";
                sqlCommand.Parameters.Add("@EMPRESA", empresa);
                sqlCommand.Parameters.Add("@FILIAL", filial);

                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;

                DataTable dtSituacao = new DataTable();
                sqlAdapter.Fill(dtSituacao);

                return this.ConverteDataTableEmList(dtSituacao).ToList();
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

        public List<Status> Pesquisar(string empresa, string filial, int id)
        {
            throw new NotImplementedException();
        }

        public Status Consultar(string empresa, string filia, int id)
        {
            throw new NotImplementedException();
        }

        protected IEnumerable<Status> ConverteDataTableEmList(DataTable dtSituacao)
        {
            int indexEmpresa = dtSituacao.Columns["EMPRESA"].Ordinal;
            int indexFilial = dtSituacao.Columns["FILIAL"].Ordinal;
            int indexCodigoStatus = dtSituacao.Columns["CODIGO"].Ordinal;
            int indexDescricaoStatus = dtSituacao.Columns["DESCRICAO"].Ordinal;

            foreach (DataRow linha in dtSituacao.Rows)
            {
                Status umStatus = new Status();
                umStatus.Codigo = Convert.ToInt32(linha[indexCodigoStatus].ToString());
                umStatus.Descricao = linha[indexDescricaoStatus].ToString();
                umStatus.Empresa = new Empresa();
                umStatus.Empresa.Codigo = linha[indexEmpresa].ToString();
                umStatus.Filial = new Filial();
                umStatus.Filial.Codigo = linha[indexFilial].ToString();
                yield return umStatus;
            }
        }
    }
}
