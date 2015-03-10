using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;
using TransferenciaObjetos.Pessoas;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 14/05/2014
// ********************************************************************* 
// Entidade Funcionario
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace AcessaDados
{
    public class FuncionarioDAO : IRepositorio<Funcionario, int>
    {
        protected FbConnection _conexao = null;

        public FuncionarioDAO(FbConnection conn)
        {
            this._conexao = conn;

            if (this._conexao.State == ConnectionState.Closed)
            {
                this._conexao.Open();
            }
        }

        public void Cadastrar(Funcionario obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(Funcionario obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Funcionario obj)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> Listar(string empresa, string filial)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT FUNCIONARIOS.CODIGO, FUNCIONARIOS.DATACADASTRO, FUNCIONARIOS.DATAADMISSAO, " +
                                        "FUNCIONARIOS.NOME, FUNCIONARIOS.REDUZIDO, FUNCIONARIOS.STATUS, SYS_COMPANY.EMPRESA, " +
                                        "FUNCIONARIOS.OBSERVACAO, FUNCIONARIOS.DATACRIACAO, " +
                                        "SYS_USERS.EMAIL AS EMAILUSUARIO, " +
                                        "SYS_BRANCH.FILIAL FROM FUNCIONARIOS LEFT JOIN SYS_COMPANY ON " +
                                        "SYS_COMPANY.EMPRESA = FUNCIONARIOS.EMPRESA " +
                                        "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = FUNCIONARIOS.FILIAL " +
                                        "INNER JOIN SYS_USERS ON SYS_USERS.CODIGO = FUNCIONARIOS.USUARIO " +
                                        "WHERE ((FUNCIONARIOS.EMPRESA = @EMPRESA) OR (FUNCIONARIOS.EMPRESA = '**')) " +
                                        "AND ((FUNCIONARIOS.FILIAL = @FILIAL) OR (FUNCIONARIOS.FILIAL = '**'))";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;
                DataTable dtFuncionario = new DataTable();
                sqlAdapter.Fill(dtFuncionario);
                return this.ConverteDataTableEmList(dtFuncionario).ToList();
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

        public List<Funcionario> Pesquisar(string empresa, string filial, int id)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT FUNCIONARIOS.CODIGO, FUNCIONARIOS.DATACADASTRO, FUNCIONARIOS.DATAADMISSAO, " +
                                         "FUNCIONARIOS.NOME, FUNCIONARIOS.REDUZIDO, SYS_COMPANY.EMPRESA, SYS_BRANCH.FILIAL, " +
                                         "FUNCIONARIOS.OBSERVACAO, FUNCIONARIOS.DATACRIACAO, FUNCIONARIOS.STATUS " +
                                         "FROM FUNCIONARIOS LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = FUNCIONARIOS.EMPRESA " +
                                         "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = FUNCIONARIOS.FILIAL " +
                                         "WHERE ((FUNCIONARIOS.EMPRESA = @EMPRESA) OR (FUNCIONARIOS.EMPRESA = '**')) " +
                                         "AND ((FUNCIONARIOS.FILIAL = @FILIAL) OR (FUNCIONARIOS.FILIAL = '**')) " +
                                         "AND FUNCIONARIOS.CODIGO LIKE '%@CODIGO%'";

                sqlCommand.Parameters.AddWithValue("@CODIGO", id);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;
                DataTable dtFuncionario = new DataTable();
                sqlAdapter.Fill(dtFuncionario);
                return this.ConverteDataTableEmList(dtFuncionario).ToList();
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

        public Funcionario Consultar(string empresa, string filial, int id)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT FUNCIONARIOS.CODIGO, FUNCIONARIOS.DATACADASTRO, FUNCIONARIOS.DATAADMISSAO, "+
                                         "FUNCIONARIOS.NOME, FUNCIONARIOS.REDUZIDO, FUNCIONARIOS.STATUS, SYS_COMPANY.EMPRESA, "+
                                         "FUNCIONARIOS.OBSERVACAO, FUNCIONARIOS.DATACRIACAO, "+
                                         "SYS_USERS.EMAIL AS EMAILUSUARIO, "+
                                         "SYS_BRANCH.FILIAL FROM FUNCIONARIOS LEFT JOIN SYS_COMPANY ON "+
                                         "SYS_COMPANY.EMPRESA = FUNCIONARIOS.EMPRESA "+
                                         "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = FUNCIONARIOS.FILIAL "+
                                         "INNER JOIN SYS_USERS ON SYS_USERS.CODIGO = FUNCIONARIOS.USUARIO "+
                                         "WHERE  ((FUNCIONARIOS.EMPRESA = @EMPRESA) OR (FUNCIONARIOS.EMPRESA = '**')) " +
                                         "AND ((FUNCIONARIOS.FILIAL = @FILIAL) OR (FUNCIONARIOS.FILIAL = '**')) AND " +
                                         "FUNCIONARIOS.CODIGO = @CODIGO";

                sqlCommand.Parameters.AddWithValue("@CODIGO", id);
                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);

                FbDataReader sqlReader = sqlCommand.ExecuteReader();

                int indexCodigo = sqlReader.GetOrdinal("CODIGO");
                int indexDataCadastro = sqlReader.GetOrdinal("DATACADASTRO");
                int indexDataAdmissao = sqlReader.GetOrdinal("DATAADMISSAO");
                int indexNome = sqlReader.GetOrdinal("NOME");
                int indexReduzido = sqlReader.GetOrdinal("REDUZIDO");
                int indexEmpresa = sqlReader.GetOrdinal("EMPRESA");
                int indexFilial = sqlReader.GetOrdinal("FILIAL");
                int indexStatus = sqlReader.GetOrdinal("STATUS");
                int indexObservacao = sqlReader.GetOrdinal("OBSERVACAO");
                int indexDataCriacao = sqlReader.GetOrdinal("DATACRIACAO");
                int indexEmail = sqlReader.GetOrdinal("EMAILUSUARIO");

                Funcionario umFuncionario = null;

                while (sqlReader.Read())
                {
                    umFuncionario = new Funcionario();
                    umFuncionario.Codigo = sqlReader.GetInt32(indexCodigo);
                    umFuncionario.DataCadastro = sqlReader.GetDateTime(indexDataCadastro);
                    umFuncionario.DataAdmissao = sqlReader.GetDateTime(indexDataAdmissao);
                    umFuncionario.Nome = sqlReader.GetString(indexNome);
                    umFuncionario.Status = sqlReader.GetInt32(indexStatus) != 0 ? "Ativo" : "Inativo";
                    umFuncionario.Reduzido = sqlReader.GetString(indexReduzido);
                    umFuncionario.Observacao = sqlReader.GetString(indexObservacao);
                    umFuncionario.DataCriacao = sqlReader.GetDateTime(indexDataCriacao);
                    umFuncionario.Empresa = new Empresa();
                    umFuncionario.Empresa.Codigo = sqlReader.GetString(indexEmpresa);
                    umFuncionario.Filial = new Filial();
                    umFuncionario.Filial.Codigo = sqlReader.GetString(indexFilial);
                    umFuncionario.Email = new Email();
                    umFuncionario.Email.WebMail = sqlReader.GetString(indexEmail);
                }

                return umFuncionario;
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

        protected IEnumerable<Funcionario> ConverteDataTableEmList(DataTable dt)
        {
            int indexCodigo = dt.Columns["CODIGO"].Ordinal;
            int indexDataCadastro = dt.Columns["DATACADASTRO"].Ordinal;
            int indexDataAdmissao = dt.Columns["DATAADMISSAO"].Ordinal;
            int indexNome = dt.Columns["NOME"].Ordinal;
            int indexReduzido = dt.Columns["REDUZIDO"].Ordinal;
            int indexEmpresa = dt.Columns["EMPRESA"].Ordinal;
            int indexFilial = dt.Columns["FILIAL"].Ordinal;
            int indexStatus = dt.Columns["STATUS"].Ordinal;
            int indexObservacao = dt.Columns["OBSERVACAO"].Ordinal;
            int indexDataCriacao = dt.Columns["DATACRIACAO"].Ordinal;
            int indexEmail = dt.Columns["EMAILUSUARIO"].Ordinal;

            foreach (DataRow linha in dt.Rows)
            {
                Funcionario umFuncionario = new Funcionario();
                umFuncionario.Codigo = Convert.ToInt32(linha[indexCodigo].ToString());
                umFuncionario.DataCadastro = Convert.ToDateTime(linha[indexDataCadastro].ToString());
                umFuncionario.DataAdmissao = Convert.ToDateTime(linha[indexDataAdmissao].ToString());
                umFuncionario.Nome = linha[indexNome].ToString();
                umFuncionario.Reduzido = linha[indexReduzido].ToString();
                umFuncionario.Status = linha[indexStatus].ToString() != "0" ? "Ativo" : "Inativo";
                umFuncionario.Observacao = linha[indexObservacao].ToString();
                umFuncionario.DataCriacao = Convert.ToDateTime(linha[indexDataCriacao].ToString());
                umFuncionario.Empresa = new Empresa();
                umFuncionario.Empresa.Codigo = linha[indexEmpresa].ToString();
                umFuncionario.Filial = new Filial();
                umFuncionario.Filial.Codigo = linha[indexFilial].ToString();
                umFuncionario.Email = new Email();
                umFuncionario.Email.WebMail = linha[indexEmail].ToString();
                yield return umFuncionario;
            }
        }
    }
}
