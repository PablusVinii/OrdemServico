using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TransferenciaObjetos;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 20/06/2014
// ********************************************************************* 
// Entidade TipoHora
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace AcessaDados
{
    public class TipoHoraDAO :ITipoHoraRepositorio
    {
        protected FbConnection _conexao = null;

        public TipoHoraDAO(FbConnection conn)
        {
            this._conexao = conn;

            if (this._conexao.State == ConnectionState.Closed)
            {
                this._conexao.Open();
            }
        }

        public void Cadastrar(TipoHora obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(TipoHora obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(TipoHora obj)
        {
            throw new NotImplementedException();
        }

        public List<TipoHora> Listar(string empresa, string filial)
        {
            FbCommand comando = new FbCommand();

            try
            {
                comando.Connection = this._conexao;
                comando.CommandText = "SELECT TIPOHORAS.CODIGO, TIPOHORAS.DESCRICAO, " +
                                      "SYS_COMPANY.EMPRESA AS CODEMPRESA, SYS_COMPANY.NOME AS NOMEEMPRESA, " +
                                      "SYS_BRANCH.FILIAL AS CODFILIAL, SYS_BRANCH.NOME AS NOMEFILIAL FROM TIPOHORAS " +
                                      "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = TIPOHORAS.EMPRESA " +
                                      "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = TIPOHORAS.FILIAL " +
                                      "WHERE ((TIPOHORAS.EMPRESA = @EMPRESA) OR (TIPOHORAS.EMPRESA = '**')) " +
                                      "AND ((TIPOHORAS.FILIAL = @FILIAL) OR (TIPOHORAS.FILIAL = '**') )";

                comando.Parameters.AddWithValue("@EMPRESA", empresa);
                comando.Parameters.AddWithValue("@FILIAL", filial);

                FbDataAdapter adaptador = new FbDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable dtHoraData = new DataTable();
                adaptador.Fill(dtHoraData);
                return this.ConverteDataTableEmList(dtHoraData).ToList();
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
                comando.Dispose();
            }
        }

        public List<TipoHora> Pesquisar(string empresa, string filial, int id)
        {
            throw new NotImplementedException();
        }

        public TipoHora Consultar(string empresa, string filia, int id)
        {
            FbCommand comando = new FbCommand();

            try
            {
                comando.Connection = this._conexao;
                comando.CommandText = "SELECT TIPOHORAS.CODIGO, TIPOHORAS.DESCRICAO, "+
                                      "SYS_COMPANY.EMPRESA AS CODEMPRESA, SYS_COMPANY.NOME AS NOMEEMPRESA, "+
                                      "SYS_BRANCH.FILIAL AS CODFILIAL, SYS_BRANCH.NOME AS NOMEFILIAL FROM TIPOHORAS "+
                                      "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = TIPOHORAS.EMPRESA "+
                                      "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = TIPOHORAS.FILIAL "+
                                      "WHERE ((TIPOHORAS.EMPRESA = @EMPRESA) OR (TIPOHORAS.EMPRESA = '**')) "+
                                      "AND ((TIPOHORAS.FILIAL = @FILIAL) OR (TIPOHORAS.FILIAL = '**') )"+
                                      "AND TIPOHORAS.CODIGO = @CODIGO";

                comando.Parameters.AddWithValue("@EMPRESA", empresa);
                comando.Parameters.AddWithValue("@FILIAL", filia);
                comando.Parameters.AddWithValue("@CODIGO", id);

                FbDataReader leitor = comando.ExecuteReader();

                TipoHora umTipoHora = new TipoHora();

                int indexCodigo = leitor.GetOrdinal("CODIGO");
                int indexDescricao = leitor.GetOrdinal("DESCRICAO");
                int indexCodEmpresa = leitor.GetOrdinal("CODEMPRESA");
                int indexNomeEmpresa = leitor.GetOrdinal("NOMEEMPRESA");
                int indexCodFilial = leitor.GetOrdinal("CODFILIAL");
                int indexNomeFilial = leitor.GetOrdinal("NOMEFILIAL");

                while (leitor.Read())
                {
                    umTipoHora.Codigo = leitor.GetInt32(indexCodigo);
                    umTipoHora.Descricao = leitor.GetString(indexDescricao);
                    umTipoHora.Empresa = new Empresa();
                    umTipoHora.Empresa.Codigo = leitor.GetString(indexCodEmpresa);
                    umTipoHora.Empresa.Nome = leitor.GetString(indexNomeEmpresa);
                    umTipoHora.Filial = new Filial();
                    umTipoHora.Filial.Codigo = leitor.GetString(indexCodFilial);
                    umTipoHora.Filial.Nome = leitor.GetString(indexNomeFilial);
                }

                return umTipoHora;
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
                comando.Dispose();
            }
        }

        protected List<FbParameter> ParametrizarComando(TipoHoraDAO obj)
        {
            throw new NotImplementedException();
        }

        protected IEnumerable<TipoHora> ConverteDataTableEmList(DataTable dt)
        {
            int indexCodigo = dt.Columns["CODIGO"].Ordinal;
            int indexDescricao = dt.Columns["DESCRICAO"].Ordinal;
            int indexCodEmpresa = dt.Columns["CODEMPRESA"].Ordinal;
            int indexNomeEmpresa = dt.Columns["NOMEEMPRESA"].Ordinal;
            int indexCodFilial = dt.Columns["CODFILIAL"].Ordinal;
            int indexNomeFilial = dt.Columns["NOMEFILIAL"].Ordinal;

            foreach (DataRow linha in dt.Rows)
            {
                TipoHora umTipoHora = new TipoHora();
                umTipoHora.Codigo = Convert.ToInt32(linha[indexCodigo].ToString());
                umTipoHora.Descricao = linha[indexDescricao].ToString();
                umTipoHora.Empresa = new Empresa();
                umTipoHora.Empresa.Codigo = linha[indexCodEmpresa].ToString();
                umTipoHora.Empresa.Nome = linha[indexNomeEmpresa].ToString();
                umTipoHora.Filial = new Filial();
                umTipoHora.Filial.Codigo = linha[indexCodFilial].ToString();
                umTipoHora.Filial.Nome = linha[indexNomeFilial].ToString();
                yield return umTipoHora;
            }
        }
    }
}
