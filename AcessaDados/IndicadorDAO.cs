using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TransferenciaObjetos;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 28/07/2014
// ********************************************************************* 
// Entidade AgendamnetoDAO
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace AcessaDados
{
    public class IndicadorDAO:IIndicadorRepositorio
    {
        protected FbConnection _conexao = null;

        public IndicadorDAO(FbConnection conn)
        {
            this._conexao = conn;

            if (conn.State == System.Data.ConnectionState.Closed)
            {
                this._conexao.Open();
            }
        }

        public void Cadastrar(Indicador obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(Indicador obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Indicador obj)
        {
            throw new NotImplementedException();
        }

        public List<Indicador> Listar(string empresa, string filial)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT EMPRESA, FILIAL, CODIGO, DESCRICAO FROM INDICADOR "+
                                         "WHERE ((INDICADOR.EMPRESA = @EMPRESA) OR (INDICADOR.EMPRESA = '**')) "+
                                         "AND ((INDICADOR.FILIAL = @FILIAL) OR (INDICADOR.FILIAL = '**'))";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;
                DataTable dtIndicador = new DataTable();
                sqlAdapter.Fill(dtIndicador);
                return this.ConverteDataTableEmList(dtIndicador).ToList();
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

        public List<Indicador> Pesquisar(string empresa, string filial, int id)
        {
            throw new NotImplementedException();
        }

        public Indicador Consultar(string empresa, string filia, int id)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT EMPRESA, FILIAL, CODIGO, DESCRICAO FROM INDICADOR " +
                                         "WHERE ((INDICADOR.EMPRESA = @EMPRESA) OR (INDICADOR.EMPRESA = '**')) " +
                                         "AND ((INDICADOR.FILIAL = @FILIAL) OR (INDICADOR.FILIAL = '**')) "+
                                         "AND CODIGO = @CODIGO";

                sqlCommand.Parameters.AddWithValue("@CODIGO", id);
                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filia);

                FbDataReader sqlReader = sqlCommand.ExecuteReader();

                int indexEmpresa = sqlReader.GetOrdinal("EMPRESA");
                int indexFilial = sqlReader.GetOrdinal("FILIAL");
                int indexCodigo = sqlReader.GetOrdinal("CODIGO");
                int indexDescricao = sqlReader.GetOrdinal("DESCRICAO");

                Indicador umIndicador = new Indicador();

                while (sqlReader.Read())
                {
                    umIndicador.Empresa = new Empresa();
                    umIndicador.Empresa.Codigo = sqlReader.GetString(indexEmpresa);
                    umIndicador.Filial = new Filial();
                    umIndicador.Filial.Codigo = sqlReader.GetString(indexFilial);
                    umIndicador.Codigo = sqlReader.GetInt32(indexCodigo);
                    umIndicador.Descricao = sqlReader.GetString(indexDescricao);
                }

                return umIndicador;
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

        private IEnumerable<Indicador> ConverteDataTableEmList(DataTable dt)
        {
            int indexEmpresa = dt.Columns["EMPRESA"].Ordinal;
            int indexFilial = dt.Columns["FILIAL"].Ordinal;
            int indexCodigo = dt.Columns["CODIGO"].Ordinal;
            int indexDescricao = dt.Columns["DESCRICAO"].Ordinal;

            foreach (DataRow linha in dt.Rows)
            {
                Indicador umIndicador = new Indicador();
                umIndicador.Empresa = new Empresa();
                umIndicador.Empresa.Codigo = linha[indexEmpresa].ToString();
                umIndicador.Filial = new Filial();
                umIndicador.Filial.Codigo = linha[indexFilial].ToString();
                umIndicador.Codigo = Convert.ToInt32(linha[indexCodigo].ToString());
                umIndicador.Descricao = linha[indexDescricao].ToString();
                yield return umIndicador;
            }
        }
    }
}
