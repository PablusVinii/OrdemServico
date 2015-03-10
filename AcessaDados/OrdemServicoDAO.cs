using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
// Data: 12/05/2014
// ********************************************************************* 
// Entidade OrdemServico
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace AcessaDados
{
    public class OrdemServicoDAO : IOrdemServicoRepositorio
    {
        protected FbConnection _conexao = null;

        public OrdemServicoDAO(FbConnection conn)
        {
            this._conexao = conn;

            if (this._conexao.State == ConnectionState.Closed)
            {
                this._conexao.Open();
            }
        }

        public void Cadastrar(OrdemServico obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "INSERT INTO ORDEM_SERVICO (EMPRESA, FILIAL, CLIENTE, FUNCIONARIO, DATA, INICIO, FIM, TRANSLADO, ATIVIDADE, "+
                                          "FATURADO, STATUS, OBSERVACAO, PROJETO, TIPOHORA) " +
                                          "VALUES (@EMPRESA, @FILIAL, @CLIENTE, @FUNCIONARIO, @DATA, @INICIO, @FIM, @TRANSLADO, @ATIVIDADE, "+
                                          "@FATURADO, @SITUACAO, @OBSERVACAO, @PROJETO, @TIPOHORA)";
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

        public void Editar(OrdemServico obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "UPDATE ORDEM_SERVICO SET EMPRESA = @EMPRESA, FILIAL = @FILIAL, CLIENTE = @CLIENTE, " +
                                         "FUNCIONARIO = @FUNCIONARIO, DATA = @DATA, INICIO = @INICIO, FIM = @FIM, " +
                                         "TRANSLADO = @TRANSLADO, ATIVIDADE = @ATIVIDADE, FATURADO = @FATURADO, STATUS = @SITUACAO, " +
                                         "OBSERVACAO = @OBSERVACAO, PROJETO = @PROJETO, TIPOHORA =  @TIPOHORA " +
                                         "WHERE CODIGO = @CODIGO";
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

        public void Excluir(OrdemServico obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "DELETE FROM ORDEM_SERVICO WHERE CODIGO = @CODIGO";
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

        public List<OrdemServico> Listar(string empresa, string filial)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT ORDEM_SERVICO.CODIGO, ORDEM_SERVICO.DATA, ORDEM_SERVICO.INICIO, " +
                                            "ORDEM_SERVICO.FIM, ORDEM_SERVICO.TRANSLADO, ORDEM_SERVICO.ATIVIDADE, ORDEM_SERVICO.FATURADO, " +
                                            "ORDEM_SERVICO.OBSERVACAO, " +
                                            "SYS_COMPANY.EMPRESA AS CODEMPRESA, SYS_COMPANY.NOME AS NOMEEMPRESA, " +
                                            "SYS_BRANCH.FILIAL AS CODFILIAL, SYS_BRANCH.NOME AS NOMEFILIAL, " +
                                            "CLIENTES.CODIGO AS CODCLIENTE, CLIENTES.REDUZIDO AS NOMECLIENTE, " +
                                            "FUNCIONARIOS.CODIGO AS CODFUNCIONARIO, FUNCIONARIOS.NOME AS NOMEFUNCIONARIO, " +
                                            "SITUACAO_OS.CODIGO AS CODSITUACAO, SITUACAO_OS.DESCRICAO AS NOMESITUACAO, " +
                                            "PROJETOS.CODIGO AS CODPROJETO, PROJETOS.DESCRICAO AS NOMEPROJETO, " +
                                            "TIPOHORAS.CODIGO AS CODTIPOHORA, TIPOHORAS.DESCRICAO AS DESCTIPOHORA " +
                                            "FROM ORDEM_SERVICO INNER JOIN CLIENTES ON CLIENTES.CODIGO = ORDEM_SERVICO.CLIENTE " +
                                            "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = ORDEM_SERVICO.FUNCIONARIO " +
                                            "INNER JOIN SITUACAO_OS ON SITUACAO_OS.CODIGO = ORDEM_SERVICO.STATUS " +
                                            "LEFT JOIN PROJETOS ON PROJETOS.CODIGO = ORDEM_SERVICO.PROJETO " +
                                            "LEFT JOIN TIPOHORAS ON TIPOHORAS.CODIGO = ORDEM_SERVICO.TIPOHORA " +
                                            "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = ORDEM_SERVICO.EMPRESA " +
                                            "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = ORDEM_SERVICO.FILIAL " +
                                            "WHERE ((ORDEM_SERVICO.EMPRESA = @EMPRESA) OR (ORDEM_SERVICO.EMPRESA = '**')) " +
                                            "AND ((ORDEM_SERVICO.FILIAL = @FILIAL) OR (ORDEM_SERVICO.FILIAL = '**')) ";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);

                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;
                DataTable dtOrdemServico = new DataTable();
                sqlAdapter.Fill(dtOrdemServico);
                return this.ConverteDataTableEmList(dtOrdemServico).ToList();
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

        public List<OrdemServico> Listar(string empresa, string filial, string idFuncionario)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT ORDEM_SERVICO.CODIGO, ORDEM_SERVICO.DATA, ORDEM_SERVICO.INICIO, " +
                                            "ORDEM_SERVICO.FIM, ORDEM_SERVICO.TRANSLADO, ORDEM_SERVICO.ATIVIDADE, ORDEM_SERVICO.FATURADO, " +
                                            "ORDEM_SERVICO.OBSERVACAO, " +
                                            "SYS_COMPANY.EMPRESA AS CODEMPRESA, SYS_COMPANY.NOME AS NOMEEMPRESA, " +
                                            "SYS_BRANCH.FILIAL AS CODFILIAL, SYS_BRANCH.NOME AS NOMEFILIAL, " +
                                            "CLIENTES.CODIGO AS CODCLIENTE, CLIENTES.REDUZIDO AS NOMECLIENTE, " +
                                            "FUNCIONARIOS.CODIGO AS CODFUNCIONARIO, FUNCIONARIOS.NOME AS NOMEFUNCIONARIO, " +
                                            "SITUACAO_OS.CODIGO AS CODSITUACAO, SITUACAO_OS.DESCRICAO AS NOMESITUACAO, " +
                                            "PROJETOS.CODIGO AS CODPROJETO, PROJETOS.DESCRICAO AS NOMEPROJETO, " +
                                            "TIPOHORAS.CODIGO AS CODTIPOHORA, TIPOHORAS.DESCRICAO AS DESCTIPOHORA " +
                                            "FROM ORDEM_SERVICO INNER JOIN CLIENTES ON CLIENTES.CODIGO = ORDEM_SERVICO.CLIENTE " +
                                            "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = ORDEM_SERVICO.FUNCIONARIO " +
                                            "INNER JOIN SITUACAO_OS ON SITUACAO_OS.CODIGO = ORDEM_SERVICO.STATUS " +
                                            "LEFT JOIN PROJETOS ON PROJETOS.CODIGO = ORDEM_SERVICO.PROJETO " +
                                            "LEFT JOIN TIPOHORAS ON TIPOHORAS.CODIGO = ORDEM_SERVICO.TIPOHORA " +
                                            "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = ORDEM_SERVICO.EMPRESA " +
                                            "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = ORDEM_SERVICO.FILIAL " +
                                            "WHERE ((ORDEM_SERVICO.EMPRESA = @EMPRESA) OR (ORDEM_SERVICO.EMPRESA = '**')) " +
                                            "AND ((ORDEM_SERVICO.FILIAL = @FILIAL) OR (ORDEM_SERVICO.FILIAL = '**')) "+
                                            "AND ORDEM_SERVICO.FUNCIONARIO = @FUNCIONARIO";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                sqlCommand.Parameters.AddWithValue("@FUNCIONARIO", idFuncionario);

                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;
                DataTable dtOrdemServico = new DataTable();
                sqlAdapter.Fill(dtOrdemServico);
                return this.ConverteDataTableEmList(dtOrdemServico).ToList();
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

        public List<OrdemServico> Pesquisar(string empresa, string filial, int id)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT ORDEM_SERVICO.CODIGO, ORDEM_SERVICO.DATA, ORDEM_SERVICO.INICIO, " +
                                            "ORDEM_SERVICO.FIM, ORDEM_SERVICO.TRANSLADO, ORDEM_SERVICO.ATIVIDADE, ORDEM_SERVICO.FATURADO, " +
                                            "ORDEM_SERVICO.OBSERVACAO, " +
                                            "SYS_COMPANY.EMPRESA AS CODEMPRESA, SYS_COMPANY.NOME AS NOMEEMPRESA, " +
                                            "SYS_BRANCH.FILIAL AS CODFILIAL, SYS_BRANCH.NOME AS NOMEFILIAL, " +
                                            "CLIENTES.CODIGO AS CODCLIENTE, CLIENTES.REDUZIDO AS NOMECLIENTE, " +
                                            "FUNCIONARIOS.CODIGO AS CODFUNCIONARIO, FUNCIONARIOS.NOME AS NOMEFUNCIONARIO, " +
                                            "SITUACAO_OS.CODIGO AS CODSITUACAO, SITUACAO_OS.DESCRICAO AS NOMESITUACAO, " +
                                            "PROJETOS.CODIGO AS CODPROJETO, PROJETOS.DESCRICAO AS NOMEPROJETO, " +
                                            "TIPOHORAS.CODIGO AS CODTIPOHORA, TIPOHORAS.DESCRICAO AS DESCTIPOHORA " +
                                            "FROM ORDEM_SERVICO INNER JOIN CLIENTES ON CLIENTES.CODIGO = ORDEM_SERVICO.CLIENTE " +
                                            "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = ORDEM_SERVICO.FUNCIONARIO " +
                                            "INNER JOIN SITUACAO_OS ON SITUACAO_OS.CODIGO = ORDEM_SERVICO.STATUS " +
                                            "LEFT JOIN PROJETOS ON PROJETOS.CODIGO = ORDEM_SERVICO.PROJETO " +
                                            "LEFT JOIN TIPOHORAS ON TIPOHORAS.CODIGO = ORDEM_SERVICO.TIPOHORA " +
                                            "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = ORDEM_SERVICO.EMPRESA " +
                                            "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = ORDEM_SERVICO.FILIAL " +
                                            "WHERE ORDEM_SERVICO.CODIGO LIKE '%@CODIGO%'";

                sqlCommand.Parameters.AddWithValue("@CODIGO", id);
                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;
                DataTable dtPesquisa = new DataTable();
                sqlAdapter.Fill(dtPesquisa);
                return this.ConverteDataTableEmList(dtPesquisa).ToList();
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

        public List<OrdemServico> Pesquisar(string empresa, string filial, OrdemServico os)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT ORDEM_SERVICO.CODIGO, ORDEM_SERVICO.DATA, ORDEM_SERVICO.INICIO, " +
                                            "ORDEM_SERVICO.FIM, ORDEM_SERVICO.TRANSLADO, ORDEM_SERVICO.ATIVIDADE, ORDEM_SERVICO.FATURADO, " +
                                            "ORDEM_SERVICO.OBSERVACAO, " +
                                            "SYS_COMPANY.EMPRESA AS CODEMPRESA, SYS_COMPANY.NOME AS NOMEEMPRESA, " +
                                            "SYS_BRANCH.FILIAL AS CODFILIAL, SYS_BRANCH.NOME AS NOMEFILIAL, " +
                                            "CLIENTES.CODIGO AS CODCLIENTE, CLIENTES.REDUZIDO AS NOMECLIENTE, " +
                                            "FUNCIONARIOS.CODIGO AS CODFUNCIONARIO, FUNCIONARIOS.NOME AS NOMEFUNCIONARIO, " +
                                            "SITUACAO_OS.CODIGO AS CODSITUACAO, SITUACAO_OS.DESCRICAO AS NOMESITUACAO, " +
                                            "PROJETOS.CODIGO AS CODPROJETO, PROJETOS.DESCRICAO AS NOMEPROJETO, " +
                                            "TIPOHORAS.CODIGO AS CODTIPOHORA, TIPOHORAS.DESCRICAO AS DESCTIPOHORA " +
                                            "FROM ORDEM_SERVICO INNER JOIN CLIENTES ON CLIENTES.CODIGO = ORDEM_SERVICO.CLIENTE " +
                                            "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = ORDEM_SERVICO.FUNCIONARIO " +
                                            "INNER JOIN SITUACAO_OS ON SITUACAO_OS.CODIGO = ORDEM_SERVICO.STATUS " +
                                            "LEFT JOIN PROJETOS ON PROJETOS.CODIGO = ORDEM_SERVICO.PROJETO " +
                                            "LEFT JOIN TIPOHORAS ON TIPOHORAS.CODIGO = ORDEM_SERVICO.TIPOHORA " +
                                            "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = ORDEM_SERVICO.EMPRESA " +
                                            "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = ORDEM_SERVICO.FILIAL " +
                                            "WHERE ((ORDEM_SERVICO.EMPRESA = @EMPRESA) OR (ORDEM_SERVICO.EMPRESA = '**')) " +
                                            "AND ((ORDEM_SERVICO.FILIAL = @FILIAL) OR (ORDEM_SERVICO.FILIAL = '**')) " +
                                            "AND ORDEM_SERVICO.DATA BETWEEN @DATADE AND @DATAATE ";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                sqlCommand.Parameters.AddWithValue("@DATADE", Convert.ToDateTime(os.DataDe));
                sqlCommand.Parameters.AddWithValue("@DATAATE", Convert.ToDateTime(os.DataAte));

                if (os.Cliente.Codigo != 0)
                {
                    sqlCommand.CommandText += "AND ORDEM_SERVICO.CLIENTE = @CLIENTE ";
                    sqlCommand.Parameters.AddWithValue("@CLIENTE", os.Cliente.Codigo);
                }

                if (os.Funcionario.Codigo != 0)
                {
                    sqlCommand.CommandText += "AND ORDEM_SERVICO.FUNCIONARIO = @FUNCIONARIO ";
                    sqlCommand.Parameters.AddWithValue("@FUNCIONARIO", os.Funcionario.Codigo);
                }

                if ((os.Projeto != null) && (os.Projeto.Codigo != 0))
                {
                    sqlCommand.CommandText += "AND PROJETOS.CODIGO = @PROJETO ";
                    sqlCommand.Parameters.AddWithValue("@PROJETO", os.Projeto.Codigo);
                }

                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;
                DataTable dtOrdensServico = new DataTable();
                sqlAdapter.Fill(dtOrdensServico);
                return this.ConverteDataTableEmList(dtOrdensServico).ToList();
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

        public OrdemServico Consultar(string empresa, string filial, int id)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;

                sqlCommand.CommandText =  "SELECT ORDEM_SERVICO.CODIGO, ORDEM_SERVICO.DATA, ORDEM_SERVICO.INICIO, "+
                                            "ORDEM_SERVICO.FIM, ORDEM_SERVICO.TRANSLADO, ORDEM_SERVICO.ATIVIDADE, ORDEM_SERVICO.FATURADO, " +
                                            "ORDEM_SERVICO.OBSERVACAO, " +
                                            "SYS_COMPANY.EMPRESA AS CODEMPRESA, SYS_COMPANY.NOME AS NOMEEMPRESA, " +
                                            "SYS_BRANCH.FILIAL AS CODFILIAL, SYS_BRANCH.NOME AS NOMEFILIAL, " +
                                            "CLIENTES.CODIGO AS CODCLIENTE, CLIENTES.REDUZIDO AS NOMECLIENTE, " +
                                            "FUNCIONARIOS.CODIGO AS CODFUNCIONARIO, FUNCIONARIOS.NOME AS NOMEFUNCIONARIO, " +
                                            "SITUACAO_OS.CODIGO AS CODSITUACAO, SITUACAO_OS.DESCRICAO AS NOMESITUACAO, " +
                                            "PROJETOS.CODIGO AS CODPROJETO, PROJETOS.DESCRICAO AS NOMEPROJETO, " +
                                            "TIPOHORAS.CODIGO AS CODTIPOHORA, TIPOHORAS.DESCRICAO AS DESCTIPOHORA " +
                                            "FROM ORDEM_SERVICO INNER JOIN CLIENTES ON CLIENTES.CODIGO = ORDEM_SERVICO.CLIENTE " +
                                            "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = ORDEM_SERVICO.FUNCIONARIO " +
                                            "INNER JOIN SITUACAO_OS ON SITUACAO_OS.CODIGO = ORDEM_SERVICO.STATUS " +
                                            "LEFT JOIN PROJETOS ON PROJETOS.CODIGO = ORDEM_SERVICO.PROJETO " +
                                            "LEFT JOIN TIPOHORAS ON TIPOHORAS.CODIGO = ORDEM_SERVICO.TIPOHORA " +
                                            "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = ORDEM_SERVICO.EMPRESA " +
                                            "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = ORDEM_SERVICO.FILIAL " +
                                            "WHERE ((ORDEM_SERVICO.EMPRESA = @EMPRESA) OR (ORDEM_SERVICO.EMPRESA = '**')) " +
                                            "AND ((ORDEM_SERVICO.FILIAL = @FILIAL) OR (ORDEM_SERVICO.FILIAL = '**')) " +
                                            "AND ORDEM_SERVICO.CODIGO = @CODIGO";

                sqlCommand.Parameters.AddWithValue("@CODIGO", id);
                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);

                FbDataReader sqlReader = sqlCommand.ExecuteReader();

                int indexCodigo = sqlReader.GetOrdinal("CODIGO");
                int indexData = sqlReader.GetOrdinal("DATA");
                int indexInicio = sqlReader.GetOrdinal("INICIO");
                int indexFim = sqlReader.GetOrdinal("FIM");
                int indexTraslado = sqlReader.GetOrdinal("TRANSLADO");
                int indexAtividade = sqlReader.GetOrdinal("ATIVIDADE");
                int indexCodEmpresa = sqlReader.GetOrdinal("CODEMPRESA");
                int indexNomeEmpresa = sqlReader.GetOrdinal("NOMEEMPRESA");
                int indexCodFilial = sqlReader.GetOrdinal("CODFILIAL");
                int indexNomeFilial = sqlReader.GetOrdinal("NOMEFILIAL");
                int indexCodCliente = sqlReader.GetOrdinal("CODCLIENTE");
                int indexNomeCliente = sqlReader.GetOrdinal("NOMECLIENTE");
                int indexFaturado = sqlReader.GetOrdinal("FATURADO");
                int indexCodFuncionario = sqlReader.GetOrdinal("CODFUNCIONARIO");
                int indexNomeFucnionario = sqlReader.GetOrdinal("NOMEFUNCIONARIO");
                int indexCodigoSituacao = sqlReader.GetOrdinal("CODSITUACAO");
                int indexDescricaoSituacao = sqlReader.GetOrdinal("NOMESITUACAO");
                int indexObservacao = sqlReader.GetOrdinal("OBSERVACAO");
                int indexCodProjeto = sqlReader.GetOrdinal("CODPROJETO");
                int indexNomeProjeto = sqlReader.GetOrdinal("NOMEPROJETO");
                int indexCodTipoHora = sqlReader.GetOrdinal("CODTIPOHORA");
                int indexDescTipoHora = sqlReader.GetOrdinal("DESCTIPOHORA");

                OrdemServico umaOrdemServico = null;

                while (sqlReader.Read())
                {
                    umaOrdemServico = new OrdemServico();
                    umaOrdemServico.Codigo = sqlReader.GetInt32(indexCodigo);
                    umaOrdemServico.Data = sqlReader.GetDateTime(indexData).ToString("dd/MM/yyyy");
                    umaOrdemServico.Inicio = sqlReader.GetString(indexInicio).ToString().Insert(2, ":"); ;
                    umaOrdemServico.Fim = sqlReader.GetString(indexFim).ToString().Insert(2, ":");

                    if (Convert.ToInt32(sqlReader.GetString(indexTraslado)) == 0)
                    {
                        umaOrdemServico.Traslado = "00:00";
                    }
                    else
                    {
                        if (sqlReader.GetString(indexTraslado).ToString().Length <= 4)
                        {

                            umaOrdemServico.Traslado = "0" + Convert.ToInt32(sqlReader.GetString(indexTraslado)).ToString().Insert(Convert.ToInt32(sqlReader.GetString(indexTraslado)).ToString().Length - 2, ":");    
                        }
                        else
                        {
                            umaOrdemServico.Traslado = Convert.ToInt32(sqlReader.GetString(indexTraslado)).ToString().Insert(Convert.ToInt32(sqlReader.GetString(indexTraslado)).ToString().Length - 2, ":");
                        }

                    }

                    umaOrdemServico.Atividade = sqlReader.GetString(indexAtividade);
                    umaOrdemServico.Faturado = sqlReader.GetString(indexFaturado) == "1" ? true : false;
                    umaOrdemServico.Empresa = new Empresa();
                    umaOrdemServico.Empresa.Codigo = sqlReader.GetString(indexCodEmpresa);
                    umaOrdemServico.Empresa.Nome = sqlReader.GetString(indexNomeEmpresa);
                    umaOrdemServico.Filial = new Filial();
                    umaOrdemServico.Filial.Codigo = sqlReader.GetString(indexCodFilial);
                    umaOrdemServico.Filial.Nome = sqlReader.GetString(indexNomeFilial);
                    umaOrdemServico.Cliente = new Cliente();
                    umaOrdemServico.Cliente.Codigo = sqlReader.GetInt32(indexCodCliente);
                    umaOrdemServico.Cliente.Nome = sqlReader.GetString(indexNomeCliente);
                    umaOrdemServico.Funcionario = new Funcionario();
                    umaOrdemServico.Funcionario.Codigo = sqlReader.GetInt32(indexCodFuncionario);
                    umaOrdemServico.Funcionario.Nome = sqlReader.GetString(indexNomeFucnionario);
                    umaOrdemServico.Status = new StatusOS();
                    umaOrdemServico.Status.Codigo = sqlReader.GetInt32(indexCodigoSituacao);
                    umaOrdemServico.Status.Descricao = sqlReader.GetString(indexDescricaoSituacao);
                    umaOrdemServico.Observacao = sqlReader.GetString(indexObservacao);
                    umaOrdemServico.Projeto = new Projeto();
                    umaOrdemServico.Projeto.Codigo =  sqlReader[indexCodProjeto] != DBNull.Value? sqlReader.GetInt32(indexCodProjeto):0;
                    umaOrdemServico.Projeto.Descricao = sqlReader.GetString(indexNomeProjeto) != string.Empty? sqlReader.GetString(indexNomeProjeto):"";
                    umaOrdemServico.TipoHora = new TipoHora();
                    umaOrdemServico.TipoHora.Codigo = sqlReader[indexCodTipoHora] != DBNull.Value? sqlReader.GetInt32(indexCodTipoHora):0;
                    umaOrdemServico.TipoHora.Descricao = sqlReader.GetString(indexDescTipoHora) != string.Empty? sqlReader.GetString(indexDescTipoHora):"";
                }

                return umaOrdemServico;

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

        protected IEnumerable<OrdemServico> ConverteDataTableEmList(DataTable dt)
        {

            int indexCodigo = dt.Columns["CODIGO"].Ordinal;
            int indexData = dt.Columns["DATA"].Ordinal;
            int indexInicio = dt.Columns["INICIO"].Ordinal;
            int indexFim = dt.Columns["FIM"].Ordinal;
            int indexTraslado = dt.Columns["TRANSLADO"].Ordinal;
            int indexAtividade = dt.Columns["ATIVIDADE"].Ordinal;
            int indexCodEmpresa = dt.Columns["CODEMPRESA"].Ordinal;
            int indexNomeEmpresa = dt.Columns["NOMEEMPRESA"].Ordinal;
            int indexCodFilial = dt.Columns["CODFILIAL"].Ordinal;
            int indexNomeFilial = dt.Columns["NOMEFILIAL"].Ordinal;
            int indexCodCliente = dt.Columns["CODCLIENTE"].Ordinal;
            int indexNomeCliente = dt.Columns["NOMECLIENTE"].Ordinal;
            int indexFaturado = dt.Columns["FATURADO"].Ordinal;
            int indexCodSituacao = dt.Columns["CODSITUACAO"].Ordinal;
            int indexNomeSituacao = dt.Columns["NOMESITUACAO"].Ordinal;
            int indexObservacao = dt.Columns["OBSERVACAO"].Ordinal;
            int indexCodProjeto = dt.Columns["CODPROJETO"].Ordinal;
            int indexNomeProjeto =  dt.Columns["NOMEPROJETO"].Ordinal;
            int indexCodTipoHora =  dt.Columns["CODTIPOHORA"].Ordinal;
            int indexDescTipoHora = dt.Columns["DESCTIPOHORA"].Ordinal;
            int indexCodFunc = dt.Columns["CODFUNCIONARIO"].Ordinal;
            int indexNomeFunc = dt.Columns["NOMEFUNCIONARIO"].Ordinal;

            foreach (DataRow linha in dt.Rows)
            {
                OrdemServico umaOrdemServico = new OrdemServico();
                umaOrdemServico.Codigo = Convert.ToInt32(linha[indexCodigo].ToString());
                umaOrdemServico.Data = Convert.ToDateTime(linha[indexData].ToString()).ToString("dd/MM/yyyy");
                umaOrdemServico.Inicio = linha[indexInicio].ToString().Insert(2, ":");
                umaOrdemServico.Fim = linha[indexFim].ToString().Insert(2, ":");

                if (linha[indexTraslado].ToString() == "0")
                {
                    umaOrdemServico.Traslado = "00:00";
                }
                else
                {
                    if (linha[indexTraslado].ToString().Length <= 4)
                    {
                        umaOrdemServico.Traslado = "0" + linha[indexTraslado].ToString().Insert(linha[indexTraslado].ToString().Length - 2, ":");
                    }
                    else
                    {
                        umaOrdemServico.Traslado = linha[indexTraslado].ToString().Insert(linha[indexTraslado].ToString().Length - 2, ":");
                    }
                }

                umaOrdemServico.Atividade = linha[indexAtividade].ToString();
                umaOrdemServico.Faturado = linha[indexFaturado].ToString() == "1" ? true : false;
                umaOrdemServico.Empresa = new Empresa();
                umaOrdemServico.Empresa.Codigo = linha[indexCodEmpresa].ToString();
                umaOrdemServico.Empresa.Nome = linha[indexNomeEmpresa].ToString();
                umaOrdemServico.Filial = new Filial();
                umaOrdemServico.Filial.Codigo = linha[indexCodFilial].ToString();
                umaOrdemServico.Filial.Nome = linha[indexNomeFilial].ToString();
                umaOrdemServico.Cliente = new Cliente();
                umaOrdemServico.Cliente.Codigo = Convert.ToInt32(linha[indexCodCliente].ToString());
                umaOrdemServico.Cliente.Nome = linha[indexNomeCliente].ToString();
                umaOrdemServico.Status = new StatusOS();
                umaOrdemServico.Status.Codigo = Convert.ToInt32(linha[indexCodSituacao]);
                umaOrdemServico.Status.Descricao = linha[indexNomeSituacao].ToString();
                umaOrdemServico.Observacao = linha[indexObservacao].ToString();
                umaOrdemServico.Projeto = new Projeto();
                umaOrdemServico.Projeto.Codigo = linha[indexCodProjeto].ToString() != ""? Convert.ToInt32(linha[indexCodProjeto].ToString()):0;
                umaOrdemServico.Projeto.Descricao = linha[indexNomeProjeto].ToString() != ""? linha[indexNomeProjeto].ToString():"";
                umaOrdemServico.TipoHora = new TipoHora();
                umaOrdemServico.TipoHora.Codigo =  linha[indexCodTipoHora].ToString() != ""? Convert.ToInt32(linha[indexCodTipoHora].ToString()):0;
                umaOrdemServico.TipoHora.Descricao = linha[indexDescTipoHora].ToString() != ""? linha[indexDescTipoHora].ToString() :"";
                umaOrdemServico.Funcionario = new Funcionario();
                umaOrdemServico.Funcionario.Codigo = Convert.ToInt32(linha[indexCodFunc]);
                umaOrdemServico.Funcionario.Nome = linha[indexNomeFunc].ToString();
                yield return umaOrdemServico;
            }
        }

        protected List<FbParameter> ParametrizarComando(OrdemServico umaOrdemServico)
        {
            List<FbParameter> lista = new List<FbParameter>();

            FbParameter sqlpEmpresa = new FbParameter();
            sqlpEmpresa.ParameterName = "@EMPRESA";
            sqlpEmpresa.Value = umaOrdemServico.Empresa.Codigo;
            lista.Add(sqlpEmpresa);

            FbParameter sqlpFilial = new FbParameter();
            sqlpFilial.ParameterName = "@FILIAL";
            sqlpFilial.Value = umaOrdemServico.Filial.Codigo;
            lista.Add(sqlpFilial);

            FbParameter sqlpCliente = new FbParameter();
            sqlpCliente.ParameterName = "@CLIENTE";
            sqlpCliente.Value = umaOrdemServico.Cliente.Codigo;
            lista.Add(sqlpCliente);

            FbParameter sqlpFuncionario = new FbParameter();
            sqlpFuncionario.ParameterName = "@FUNCIONARIO";
            sqlpFuncionario.Value = umaOrdemServico.Funcionario.Codigo;
            lista.Add(sqlpFuncionario);

            FbParameter sqlpProjeto = new FbParameter();
            sqlpProjeto.ParameterName = "@PROJETO";
            sqlpProjeto.Value = umaOrdemServico.Projeto.Codigo;
            lista.Add(sqlpProjeto);

            FbParameter sqlpTipoHora = new FbParameter();
            sqlpTipoHora.ParameterName = "@TIPOHORA";
            sqlpTipoHora.Value = umaOrdemServico.TipoHora.Codigo;
            lista.Add(sqlpTipoHora);

            FbParameter sqlpData = new FbParameter();
            sqlpData.ParameterName = "@DATA";
            sqlpData.Value = umaOrdemServico.Data;
            lista.Add(sqlpData);

            FbParameter sqlpInicio = new FbParameter();
            sqlpInicio.ParameterName = "@INICIO";
            sqlpInicio.Value = umaOrdemServico.Inicio.Replace(":", "");
            lista.Add(sqlpInicio);

            FbParameter sqlpFim = new FbParameter();
            sqlpFim.ParameterName = "@FIM";
            sqlpFim.Value = umaOrdemServico.Fim.Replace(":", "");
            lista.Add(sqlpFim);

            FbParameter sqlpTranslado = new FbParameter();
            sqlpTranslado.ParameterName = "@TRANSLADO";
            sqlpTranslado.Value = umaOrdemServico.Traslado.Replace(":", "");
            lista.Add(sqlpTranslado);

            FbParameter sqlpAtividade = new FbParameter();
            sqlpAtividade.ParameterName = "@ATIVIDADE";
            sqlpAtividade.Value = umaOrdemServico.Atividade;
            lista.Add(sqlpAtividade);

            FbParameter sqlpSituacao = new FbParameter();
            sqlpSituacao.ParameterName = "@SITUACAO";
            sqlpSituacao.Value = umaOrdemServico.Status.Codigo;
            lista.Add(sqlpSituacao);

            FbParameter sqlpObservacao = new FbParameter();
            sqlpObservacao.ParameterName = "@OBSERVACAO";
            sqlpObservacao.Value = umaOrdemServico.Observacao;
            lista.Add(sqlpObservacao);

            FbParameter sqlFaturado = new FbParameter();
            sqlFaturado.ParameterName = "@FATURADO";
            if (umaOrdemServico.Faturado)
            {
                sqlFaturado.Value = "1";
            }
            else
            {
                sqlFaturado.Value = "0";
            }

            lista.Add(sqlFaturado);

            if (umaOrdemServico.Codigo != 0)
            {
                FbParameter sqlpCodigo = new FbParameter();
                sqlpCodigo.ParameterName = "@CODIGO";
                sqlpCodigo.Value = umaOrdemServico.Codigo;
                lista.Add(sqlpCodigo);
            }

            return lista;
        }

        public DataTable GerarRelatorio(string query, IEnumerable<FbParameter> parametros)
        {
            FbCommand comando = new FbCommand();

            try
            {
                comando.Connection = this._conexao;
                comando.CommandText = query;

                foreach (FbParameter par in parametros)
                {
                    if (par != null)
                    {
                        comando.Parameters.Add(par);
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

        public void AcrescentarNaMeta(int ano, int mes, int meta, int funcionario, int indicador, double totalHoras = 0)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;

                switch (indicador)
                {
                    case 1:
                        sqlCommand.CommandText = "UPDATE PERIODO SET REALIZADO = REALIZADO + @TOTAL " +
                                                 "WHERE ANO = @ANO AND MES = @MES AND META = @META AND FUNCIONARIO = @FUNCIONARIO";
                        sqlCommand.Parameters.AddWithValue("@TOTAL", totalHoras);
                        break;
                    case 2:
                        sqlCommand.CommandText = "UPDATE PERIODO SET REALIZADO = REALIZADO + 1 " +
                                                 "WHERE ANO = @ANO AND MES = @MES AND META = @META AND FUNCIONARIO = @FUNCIONARIO";
                        break;
                }

                sqlCommand.Parameters.AddWithValue("@ANO", ano);
                sqlCommand.Parameters.AddWithValue("@MES", mes);
                sqlCommand.Parameters.AddWithValue("@META", meta);
                sqlCommand.Parameters.AddWithValue("@FUNCIONARIO", funcionario);

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

        public void DecrementarNaMeta(int ano, int mes, int meta, int funcionario, int indicador, double totalHoras = 0)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;

                switch (indicador)
                {
                    case 1:
                        sqlCommand.CommandText = "UPDATE PERIODO SET REALIZADO = REALIZADO - @TOTAL " +
                                                 "WHERE ANO = @ANO AND MES = @MES AND META = @META AND FUNCIONARIO = @FUNCIONARIO";
                        sqlCommand.Parameters.AddWithValue("@TOTAL", totalHoras);
                        break;
                    case 2:
                        sqlCommand.CommandText = "UPDATE PERIODO SET REALIZADO = REALIZADO - 1 " +
                                                 "WHERE ANO = @ANO AND MES = @MES AND META = @META AND FUNCIONARIO = @FUNCIONARIO";
                        break;
                }

                sqlCommand.Parameters.AddWithValue("@ANO", ano);
                sqlCommand.Parameters.AddWithValue("@MES", mes);
                sqlCommand.Parameters.AddWithValue("@META", meta);
                sqlCommand.Parameters.AddWithValue("@FUNCIONARIO", funcionario);

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

        public int UltimoId()
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT MAX(CODIGO) FROM ORDEM_SERVICO";

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
    }
}
