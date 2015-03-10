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
// Entidade AgendamnetoDAO
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace AcessaDados
{
    public class MetaDAO : IMetaRepositorio
    {
        FbConnection _conexao = null;

        public MetaDAO(FbConnection conn)
        {
            this._conexao = conn;

            if (this._conexao.State == System.Data.ConnectionState.Closed)
            {
                this._conexao.Open();
            }
        }

        public void Cadastrar(Meta obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "INSERT INTO META (EMPRESA, FILIAL, DESCRICAO, DATACADASTRO, INDICADOR, FUNCIONARIO) " +
                                         "VALUES (@EMPRESA, @FILIAL, @DESCRICAO, @DATACADASTRO, @INDICADOR, @FUNCIONARIO)";

                sqlCommand.Parameters.AddRange(this.ParametrizarComando(obj));
                sqlCommand.ExecuteNonQuery();
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

        public void Editar(Meta obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "UPDATE META SET EMPRESA = @EMPRESA, FILIAL = @FILIAL, " +
                                         "INDICADOR = @INDICADOR, FUNCIONARIO = @FUNCIONARIO, DESCRICAO = @DESCRICAO  WHERE CODIGO = @CODIGO";

                sqlCommand.Parameters.AddRange(this.ParametrizarComando(obj));
                sqlCommand.ExecuteNonQuery();
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

        public void Excluir(Meta obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "DELETE FROM META WHERE CODIGO = @CODIGO";
                sqlCommand.Parameters.AddWithValue("@CODIGO", obj.Codigo);
                sqlCommand.ExecuteNonQuery();
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

        public List<Meta> Listar(string empresa, string filial)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT META.EMPRESA, META.FILIAL, META.CODIGO, META.DESCRICAO, META.DATACADASTRO, " +
                                            "INDICADOR.CODIGO AS CODINDICADOR, INDICADOR.DESCRICAO AS DESCINDICADOR, " +
                                            "FUNCIONARIOS.CODIGO AS CODFUNC, FUNCIONARIOS.NOME AS NOMEFUNC, "+
                                            "PROJETOS.CODIGO AS CODPROJETO, PROJETOS.DESCRICAO AS DESCPROJETO " +
                                            "FROM META " +
                                            "INNER JOIN INDICADOR ON INDICADOR.CODIGO = META.INDICADOR " +
                                            "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = META.FUNCIONARIO " +
                                            "LEFT JOIN PROJETOS ON PROJETOS.META = META.CODIGO " +
                                            "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = META.EMPRESA " +
                                            "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = META.FILIAL " +
                                            "WHERE ((META.EMPRESA = @EMPRESA) OR (META.EMPRESA = '**')) AND " +
                                            "((META.FILIAL = @FILIAL) OR (META.FILIAL = '**'))";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);

                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;

                DataTable dtMeta = new DataTable();
                sqlAdapter.Fill(dtMeta);
                return this.ColetarPeriodos(this.ConverteDataTableEmList(dtMeta).ToList());
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

        public List<Meta> Listar(string empresa, string filial, int funcionario)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT META.EMPRESA, META.FILIAL, META.CODIGO, META.DESCRICAO, META.DATACADASTRO, " +
                                            "INDICADOR.CODIGO AS CODINDICADOR, INDICADOR.DESCRICAO AS DESCINDICADOR, " +
                                            "FUNCIONARIOS.CODIGO AS CODFUNC, FUNCIONARIOS.NOME AS NOMEFUNC, " +
                                            "PROJETOS.CODIGO AS CODPROJETO, PROJETOS.DESCRICAO AS DESCPROJETO " +
                                            "FROM META " +
                                            "INNER JOIN INDICADOR ON INDICADOR.CODIGO = META.INDICADOR " +
                                            "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = META.FUNCIONARIO " +
                                            "LEFT JOIN PROJETOS ON PROJETOS.META = META.CODIGO " +
                                            "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = META.EMPRESA " +
                                            "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = META.FILIAL " +
                                            "WHERE ((META.EMPRESA = @EMPRESA) OR (META.EMPRESA = '**')) AND " +
                                            "((META.FILIAL = @FILIAL) OR (META.FILIAL = '**')) AND FUNCIONARIOS.CODIGO = @FUNCIONARIO";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                sqlCommand.Parameters.AddWithValue("@FUNCIONARIO", funcionario);

                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;

                DataTable dtMeta = new DataTable();
                sqlAdapter.Fill(dtMeta);
                return this.ColetarPeriodos(this.ConverteDataTableEmList(dtMeta).ToList());
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

        public List<Meta> Listar(string empresa, string filial, Projeto projeto)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT META.EMPRESA, META.FILIAL, META.CODIGO, META.DESCRICAO, META.DATACADASTRO, " +
                                            "INDICADOR.CODIGO AS CODINDICADOR, INDICADOR.DESCRICAO AS DESCINDICADOR, " +
                                            "FUNCIONARIOS.CODIGO AS CODFUNC, FUNCIONARIOS.NOME AS NOMEFUNC, " +
                                            "PROJETOS.CODIGO AS CODPROJETO, PROJETOS.DESCRICAO AS DESCPROJETO " +
                                            "FROM META " +
                                            "INNER JOIN INDICADOR ON INDICADOR.CODIGO = META.INDICADOR " +
                                            "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = META.FUNCIONARIO " +
                                            "LEFT JOIN PROJETOS ON PROJETOS.META = META.CODIGO " +
                                            "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = META.EMPRESA " +
                                            "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = META.FILIAL " +
                                            "WHERE ((META.EMPRESA = @EMPRESA) OR (META.EMPRESA = '**')) AND " +
                                            "((META.FILIAL = @FILIAL) OR (META.FILIAL = '**')) AND PROJETOS.CODIGO = @PROJETO";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                sqlCommand.Parameters.AddWithValue("@PROJETO", projeto.Codigo);

                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;

                DataTable dtMeta = new DataTable();
                sqlAdapter.Fill(dtMeta);
                return this.ColetarPeriodos(this.ConverteDataTableEmList(dtMeta).ToList());
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

        public List<Meta> Pesquisar(string empresa, string filial, int id)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT META.EMPRESA, META.FILIAL, META.CODIGO, META.DESCRICAO, META.DATACADASTRO, " +
                                         "INDICADOR.CODIGO AS CODINDICADOR, INDICADOR.DESCRICAO AS DESCINDICADOR, " +
                                         "FUNCIONARIOS.CODIGO AS CODFUNC, FUNCIONARIOS.NOME AS NOMEFUNC, "+
                                         "PROJETOS.CODIGO AS CODPROJETO, PROJETOS.DESCRICAO AS DESCPROJETO " +
                                         "FROM META " +
                                         "INNER JOIN INDICADOR ON INDICADOR.CODIGO = META.INDICADOR " +
                                         "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = META.FUNCIONARIO " +
                                         "LEFT JOIN PROJETOS ON PROJETOS.META = META.CODIGO " +
                                         "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = META.EMPRESA " +
                                         "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = META.FILIAL " +
                                         "WHERE ((META.EMPRESA = @EMPRESA) OR (META.EMPRESA = '**')) AND " +
                                         "((META.FILIAL = @FILIAL) OR (META.FILIAL = '**')) AND META.CODIGO LIKE @CODIGO";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                sqlCommand.Parameters.AddWithValue("@CODIGO", id);

                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;

                DataTable dtMeta = new DataTable();
                sqlAdapter.Fill(dtMeta);
                return this.ColetarPeriodos(this.ConverteDataTableEmList(dtMeta).ToList());
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

        public Meta Consultar(string empresa, string filia, int id)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT META.EMPRESA, META.FILIAL, META.CODIGO, META.DESCRICAO, META.DATACADASTRO, " +
                                         "INDICADOR.CODIGO AS CODINDICADOR, INDICADOR.DESCRICAO AS DESCINDICADOR, " +
                                         "FUNCIONARIOS.CODIGO AS CODFUNC, FUNCIONARIOS.NOME AS NOMEFUNC, "+
                                         "PROJETOS.CODIGO AS CODPROJETO, PROJETOS.DESCRICAO AS DESCPROJETO " +
                                         "FROM META " +
                                         "INNER JOIN INDICADOR ON INDICADOR.CODIGO = META.INDICADOR " +
                                         "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = META.FUNCIONARIO " +
                                         "LEFT JOIN PROJETOS ON PROJETOS.META = META.CODIGO " +
                                         "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = META.EMPRESA " +
                                         "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = META.FILIAL " +
                                         "WHERE ((META.EMPRESA = @EMPRESA) OR (META.EMPRESA = '**')) AND " +
                                         "((META.FILIAL = @FILIAL) OR (META.FILIAL = '**')) AND META.CODIGO = @CODIGO";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filia);
                sqlCommand.Parameters.AddWithValue("@CODIGO", id);

                FbDataReader sqlReader = sqlCommand.ExecuteReader();

                Meta umaMeta = new Meta();

                int indexEmpresa = sqlReader.GetOrdinal("EMPRESA");
                int indexFilial = sqlReader.GetOrdinal("FILIAL");
                int indexCodigo = sqlReader.GetOrdinal("CODIGO");
                int indexDescricao = sqlReader.GetOrdinal("DESCRICAO");
                int indexDataCadastro = sqlReader.GetOrdinal("DATACADASTRO");
                int indexCodIndicador = sqlReader.GetOrdinal("CODINDICADOR");
                int indexDescIndicador = sqlReader.GetOrdinal("DESCINDICADOR");
                int indexCodFuncionario = sqlReader.GetOrdinal("CODFUNC");
                int indexDescFuncioanrio = sqlReader.GetOrdinal("NOMEFUNC");
                int indexCodProjeto = sqlReader.GetOrdinal("CODPROJETO");
                int indexDescProjeto = sqlReader.GetOrdinal("DESCPROJETO");

                while (sqlReader.Read())
                {
                    umaMeta.Empresa = new Empresa();
                    umaMeta.Empresa.Codigo = sqlReader.GetString(indexEmpresa);
                    umaMeta.Filial = new Filial();
                    umaMeta.Filial.Codigo = sqlReader.GetString(indexFilial);
                    umaMeta.Codigo = sqlReader.GetInt32(indexCodigo);
                    umaMeta.Descricao = sqlReader.GetString(indexDescricao);
                    umaMeta.DataCadastro = sqlReader.GetDateTime(indexDataCadastro);
                    umaMeta.Indicador = new Indicador();
                    umaMeta.Indicador.Codigo = sqlReader.GetInt32(indexCodIndicador);
                    umaMeta.Indicador.Descricao = sqlReader.GetString(indexDescIndicador);
                    umaMeta.Funcionario = new Funcionario();
                    umaMeta.Funcionario.Codigo = sqlReader.GetInt32(indexCodFuncionario);
                    umaMeta.Funcionario.Nome = sqlReader.GetString(indexDescFuncioanrio);
                    umaMeta.Projeto = new Projeto();
                    umaMeta.Projeto.Codigo = sqlReader[indexCodProjeto] != DBNull.Value ? sqlReader.GetInt32(indexCodProjeto) : 0;
                    umaMeta.Projeto.Descricao = sqlReader[indexDescProjeto] != DBNull.Value ? sqlReader.GetString(indexDescProjeto) : "0";
                }

                return this.ColetarPeriodos(umaMeta);
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

        protected List<FbParameter> ParametrizarComando(Meta obj)
        {
            List<FbParameter> lista = new List<FbParameter>();

            FbParameter sqlpEmpresa = new FbParameter();
            sqlpEmpresa.ParameterName = "@EMPRESA";
            sqlpEmpresa.Value = obj.Empresa.Codigo;
            lista.Add(sqlpEmpresa);

            FbParameter sqlpFilial = new FbParameter();
            sqlpFilial.ParameterName = "@FILIAL";
            sqlpFilial.Value = obj.Filial.Codigo;
            lista.Add(sqlpFilial);

            FbParameter sqlpCodigo = new FbParameter();
            sqlpCodigo.ParameterName = "@CODIGO";
            sqlpCodigo.Value = obj.Codigo;
            lista.Add(sqlpCodigo);

            FbParameter sqlpDescricao = new FbParameter();
            sqlpDescricao.ParameterName = "@DESCRICAO";
            sqlpDescricao.Value = obj.Descricao;
            lista.Add(sqlpDescricao);

            FbParameter sqlpIndicador = new FbParameter();
            sqlpIndicador.ParameterName = "@INDICADOR";
            sqlpIndicador.Value = obj.Indicador.Codigo;
            lista.Add(sqlpIndicador);

            FbParameter sqlpFuncionario = new FbParameter();
            sqlpFuncionario.ParameterName = "@FUNCIONARIO";
            sqlpFuncionario.Value = obj.Funcionario.Codigo;
            lista.Add(sqlpFuncionario);

            if (obj.Codigo == 0)
            {
                FbParameter sqlpDataCadastro = new FbParameter();
                sqlpDataCadastro.ParameterName = "@DATACADASTRO";
                sqlpDataCadastro.Value = obj.DataCadastro;
                lista.Add(sqlpDataCadastro);
            }

            return lista;
        }

        protected IEnumerable<Meta> ConverteDataTableEmList(DataTable dt)
        {
            int indexEmpresa = dt.Columns["EMPRESA"].Ordinal;
            int indexFilial = dt.Columns["FILIAL"].Ordinal;
            int indexCodigo = dt.Columns["CODIGO"].Ordinal;
            int indexDescricao = dt.Columns["DESCRICAO"].Ordinal;
            int indexDataCadastro = dt.Columns["DATACADASTRO"].Ordinal;
            int indexCodIndicador = dt.Columns["CODINDICADOR"].Ordinal;
            int indexDescIndicador = dt.Columns["DESCINDICADOR"].Ordinal;
            int indexCodFuncionario = dt.Columns["CODFUNC"].Ordinal;
            int indexDescFuncioanrio = dt.Columns["NOMEFUNC"].Ordinal;
            int indexCodProjeto = dt.Columns["CODPROJETO"].Ordinal;
            int indexDescProjeto = dt.Columns["DESCPROJETO"].Ordinal;

            foreach (DataRow linha in dt.Rows)
            {
                Meta umaMeta = new Meta();
                umaMeta.Empresa = new Empresa();
                umaMeta.Empresa.Codigo = linha[indexEmpresa].ToString();
                umaMeta.Filial = new Filial();
                umaMeta.Filial.Codigo = linha[indexFilial].ToString();
                umaMeta.Codigo = Convert.ToInt32(linha[indexCodigo].ToString());
                umaMeta.Descricao = linha[indexDescricao].ToString();
                umaMeta.DataCadastro = Convert.ToDateTime(linha[indexDataCadastro].ToString());
                umaMeta.Indicador = new Indicador();
                umaMeta.Indicador.Codigo = Convert.ToInt32(linha[indexCodIndicador].ToString());
                umaMeta.Indicador.Descricao = linha[indexDescIndicador].ToString();
                umaMeta.Funcionario = new Funcionario();
                umaMeta.Funcionario.Codigo = Convert.ToInt32(linha[indexCodFuncionario].ToString());
                umaMeta.Funcionario.Nome = linha[indexDescFuncioanrio].ToString();
                umaMeta.Projeto = new Projeto();
                umaMeta.Projeto.Codigo = linha[indexCodProjeto].ToString() != "" ? Convert.ToInt32(linha[indexCodProjeto].ToString()) : 0;
                umaMeta.Projeto.Descricao = linha[indexDescProjeto].ToString() != "" ? linha[indexDescProjeto].ToString() : "";
                yield return umaMeta;
            }
        }

        public List<Meta> ColetarPeriodos(List<Meta> listaDeMetas)
        {
            foreach (var meta in listaDeMetas)
            {
                meta.Periodos = new List<Periodo>();

                IPeriodoRepositorio umPeriodoDAO = new PeriodoDAO(this._conexao);

                for (int i = 1; i <= 12; i++)
                {
                    Periodo umPeriodo = umPeriodoDAO.Consultar(meta.Empresa.Codigo, meta.Filial.Codigo, DateTime.Now.Year, i, meta.Codigo, meta.Funcionario.Codigo);

                    if (umPeriodo != null)
                    {
                        meta.Periodos.Add(umPeriodo);
                    }
                }
            }

            return listaDeMetas;
        }

        public Meta ColetarPeriodos(Meta meta)
        {
            meta.Periodos = new List<Periodo>();

            IPeriodoRepositorio umPeriodoDAO = new PeriodoDAO(this._conexao);

            Dictionary<int, string> meses = TRS.Apoio.Meses.PegarMeses();

            for (int i = 1; i <= 12; i++)
            {
                Periodo umPeriodo = umPeriodoDAO.Consultar(meta.Empresa.Codigo, meta.Filial.Codigo, DateTime.Now.Year, i, meta.Codigo, meta.Funcionario.Codigo);
                umPeriodo.NomeMes = meses[i];

                if (umPeriodo != null)
                {
                    meta.Periodos.Add(umPeriodo);
                }
            }

            return meta;
        }

        public int UltimoId()
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT MAX(CODIGO) FROM META";

                FbDataReader sqlReader = sqlCommand.ExecuteReader();

                int id = 0;

                while (sqlReader.Read())
                {
                    id = sqlReader.GetInt32(0);
                }

                return id;
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

        public DataTable GerarRelatorio(string query, IEnumerable<FbParameter> parametros)
        {
            FbCommand comando = new FbCommand();

            try
            {
                comando.Connection = this._conexao;
                comando.CommandText = query;

                if (parametros != null)
                {

                    foreach (FbParameter par in parametros)
                    {
                        if (par != null)
                        {
                            comando.Parameters.Add(par);
                        }
                    }

                }

                FbDataAdapter adaptador = new FbDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable dtConsulta = new DataTable();
                adaptador.Fill(dtConsulta);
                return dtConsulta;
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
    }
}
