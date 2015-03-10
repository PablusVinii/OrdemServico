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
// Data: 26/05/2014
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
    public class AgendamentoDAO : IAgendamentoRepositorio
    {
        FbConnection _conexao = null;

        public AgendamentoDAO(FbConnection conn)
        {
            this._conexao = conn;

            if (this._conexao.State == ConnectionState.Closed)
            {
                this._conexao.Open();
            }
        }

        public void Cadastrar(Agendamento obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "INSERT INTO AGENDAMENTO (EMPRESA, FILIAL, FUNCIONARIO, CLIENTE,STATUS,DATAPREVISTO, " +
                                         "INICIOPREVISTO,FIMPREVISTO,TRASLADOPREVISTO, RESUMOAGENDAMENTO) " +
                                         "VALUES (@EMPRESA,@FILIAL,@FUNCIONARIO,@CLIENTE, @STATUS, @DATAPREVISTO, @INICIOPREVISTO, " +
                                         "@FIMPREVISTO,@TRASLADOPREVISTO, @RESUMOAGENDAMENTO)";
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

        public void Editar(Agendamento obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "UPDATE AGENDAMENTO SET EMPRESA = @EMPRESA, FILIAL = @FILIAL, FUNCIONARIO = @FUNCIONARIO, " +
                                         "CLIENTE = @CLIENTE, STATUS = @STATUS, DATAPREVISTO = @DATAPREVISTO, INICIOPREVISTO  = @INICIOPREVISTO, " +
                                         "FIMPREVISTO  = @FIMPREVISTO, TRASLADOPREVISTO = @TRASLADOPREVISTO, DATACONCLUSAO = @DATACONCLUSAO, " +
                                         "INICIOCONCLUSAO = @INICIOCONCLUSAO, FIMCONCLUSAO = @FIMCONCLUSAO, TRASLADOCONCLUSAO = @TRASLADOCONCLUSAO, " +
                                         "RESUMOAGENDAMENTO = @RESUMOAGENDAMENTO " +
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

        public void Excluir(Agendamento obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "DELETE FROM AGENDAMENTO WHERE CODIGO = @CODIGO";
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

        public List<Agendamento> Listar(string empresa, string filial)
        {

            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT AGENDAMENTO.CODIGO, AGENDAMENTO.DATAPREVISTO, " +
                                            "AGENDAMENTO.INICIOPREVISTO, AGENDAMENTO.FIMPREVISTO, " +
                                            "AGENDAMENTO.TRASLADOPREVISTO, AGENDAMENTO.DATACONCLUSAO, " +
                                            "AGENDAMENTO.INICIOCONCLUSAO, AGENDAMENTO.FIMCONCLUSAO, " +
                                            "AGENDAMENTO.RESUMOAGENDAMENTO, " +
                                            "AGENDAMENTO.TRASLADOCONCLUSAO, AGENDAMENTO.EMPRESA, AGENDAMENTO.FILIAL, " +
                                            "AGENDAMENTO.STATUS AS CODIGOSITUACAO, SITUACAO.DESCRICAO AS DESCRICAOSITUACAO, " +
                                            "CLIENTES.CODIGO AS CODIGOCLIENTE, CLIENTES.NOME AS RAZAOSOCIAL, CLIENTES.REDUZIDO AS NOMECLIENTE, CLIENTES.EMAIL AS EMAILCLIENTE, " +
                                            "CLIENTES.UF, CLIENTES.MUNICIPIO, CLIENTES.BAIRRO, CLIENTES.ENDERECO, CLIENTES.DDD, CLIENTES.TELEFONE, " +
                                            "FUNCIONARIOS.CODIGO AS CODIGOFUNCIONARIO, FUNCIONARIOS.REDUZIDO AS NOMEFUNCIONARIO, SYS_USERS.EMAIL AS EMAILFUNCIONARIO " +
                                            "FROM AGENDAMENTO " +
                                            "INNER JOIN CLIENTES ON CLIENTES.CODIGO = AGENDAMENTO.CLIENTE " +
                                            "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = AGENDAMENTO.FUNCIONARIO " +
                                            "INNER JOIN SYS_USERS ON SYS_USERS.CODIGO = FUNCIONARIOS.USUARIO " +
                                            "INNER JOIN SITUACAO ON AGENDAMENTO.STATUS = SITUACAO.CODIGO " +
                                            "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = AGENDAMENTO.EMPRESA " +
                                            "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = AGENDAMENTO.FILIAL " +
                                            "WHERE ((AGENDAMENTO.EMPRESA = @EMPRESA) OR (AGENDAMENTO.EMPRESA = '**')) AND " +
                                            "((AGENDAMENTO.FILIAL = @FILIAL) OR (AGENDAMENTO.FILIAL = '**'))";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                DataTable dtAgendamento = new DataTable();
                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;
                sqlAdapter.Fill(dtAgendamento);
                return this.ConverteDataTableEmList(dtAgendamento).ToList();
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

        public List<Agendamento> Listar(string empresa, string filial, int idFuncionario)
        {
            List<Agendamento> lista = new List<Agendamento>();

            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT AGENDAMENTO.CODIGO, AGENDAMENTO.DATAPREVISTO, " +
                                            "AGENDAMENTO.INICIOPREVISTO, AGENDAMENTO.FIMPREVISTO, " +
                                            "AGENDAMENTO.TRASLADOPREVISTO, AGENDAMENTO.DATACONCLUSAO, " +
                                            "AGENDAMENTO.INICIOCONCLUSAO, AGENDAMENTO.FIMCONCLUSAO, " +
                                            "AGENDAMENTO.RESUMOAGENDAMENTO, " +
                                            "AGENDAMENTO.TRASLADOCONCLUSAO, AGENDAMENTO.EMPRESA, AGENDAMENTO.FILIAL, " +
                                            "AGENDAMENTO.STATUS AS CODIGOSITUACAO, SITUACAO.DESCRICAO AS DESCRICAOSITUACAO, " +
                                            "CLIENTES.CODIGO AS CODIGOCLIENTE, CLIENTES.NOME AS RAZAOSOCIAL, CLIENTES.REDUZIDO AS NOMECLIENTE, CLIENTES.EMAIL AS EMAILCLIENTE, " +
                                            "CLIENTES.UF, CLIENTES.MUNICIPIO, CLIENTES.BAIRRO, CLIENTES.ENDERECO, CLIENTES.DDD, CLIENTES.TELEFONE, " +
                                            "FUNCIONARIOS.CODIGO AS CODIGOFUNCIONARIO, FUNCIONARIOS.REDUZIDO AS NOMEFUNCIONARIO, SYS_USERS.EMAIL AS EMAILFUNCIONARIO " +
                                            "FROM AGENDAMENTO " +
                                            "INNER JOIN CLIENTES ON CLIENTES.CODIGO = AGENDAMENTO.CLIENTE " +
                                            "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = AGENDAMENTO.FUNCIONARIO " +
                                            "INNER JOIN SYS_USERS ON SYS_USERS.CODIGO = FUNCIONARIOS.USUARIO " +
                                            "INNER JOIN SITUACAO ON AGENDAMENTO.STATUS = SITUACAO.CODIGO " +
                                            "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = AGENDAMENTO.EMPRESA " +
                                            "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = AGENDAMENTO.FILIAL " +
                                            "WHERE ((AGENDAMENTO.EMPRESA = @EMPRESA) OR (AGENDAMENTO.EMPRESA = '**')) AND " +
                                            "((AGENDAMENTO.FILIAL = @FILIAL) OR (AGENDAMENTO.FILIAL = '**')) " +
                                            "AND AGENDAMENTO.FUNCIONARIO = @FUNCIONARIO";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                sqlCommand.Parameters.AddWithValue("@FUNCIONARIO", idFuncionario);
                DataTable dtAgendamento = new DataTable();
                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;
                sqlAdapter.Fill(dtAgendamento);
                return this.ConverteDataTableEmList(dtAgendamento).ToList();
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

        public List<Agendamento> Pesquisar(string empresa, string filial, int id)
        {
            List<Agendamento> lista = new List<Agendamento>();

            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT AGENDAMENTO.CODIGO, AGENDAMENTO.DATAPREVISTO, " +
                                            "AGENDAMENTO.INICIOPREVISTO, AGENDAMENTO.FIMPREVISTO, " +
                                            "AGENDAMENTO.TRASLADOPREVISTO, AGENDAMENTO.DATACONCLUSAO, " +
                                            "AGENDAMENTO.INICIOCONCLUSAO, AGENDAMENTO.FIMCONCLUSAO, " +
                                            "AGENDAMENTO.RESUMOAGENDAMENTO, " +
                                            "AGENDAMENTO.TRASLADOCONCLUSAO, AGENDAMENTO.EMPRESA, AGENDAMENTO.FILIAL, " +
                                            "AGENDAMENTO.STATUS AS CODIGOSITUACAO, SITUACAO.DESCRICAO AS DESCRICAOSITUACAO, " +
                                            "CLIENTES.CODIGO AS CODIGOCLIENTE, CLIENTES.NOME AS RAZAOSOCIAL, CLIENTES.REDUZIDO AS NOMECLIENTE, CLIENTES.EMAIL AS EMAILCLIENTE, " +
                                            "CLIENTES.UF, CLIENTES.MUNICIPIO, CLIENTES.BAIRRO, CLIENTES.ENDERECO, CLIENTES.DDD, CLIENTES.TELEFONE, " +
                                            "FUNCIONARIOS.CODIGO AS CODIGOFUNCIONARIO, FUNCIONARIOS.REDUZIDO AS NOMEFUNCIONARIO, SYS_USERS.EMAIL AS EMAILFUNCIONARIO " +
                                            "FROM AGENDAMENTO " +
                                            "INNER JOIN CLIENTES ON CLIENTES.CODIGO = AGENDAMENTO.CLIENTE " +
                                            "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = AGENDAMENTO.FUNCIONARIO " +
                                            "INNER JOIN SYS_USERS ON SYS_USERS.CODIGO = FUNCIONARIOS.USUARIO " +
                                            "INNER JOIN SITUACAO ON AGENDAMENTO.STATUS = SITUACAO.CODIGO " +
                                            "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = AGENDAMENTO.EMPRESA " +
                                            "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = AGENDAMENTO.FILIAL " +
                                            "WHERE ((AGENDAMENTO.EMPRESA = @EMPRESA) OR (AGENDAMENTO.EMPRESA = '**')) AND " +
                                            "((AGENDAMENTO.FILIAL = @FILIAL) OR (AGENDAMENTO.FILIAL = '**')) AND " +
                                            "AGENDAMENTO.CODIGO LIKE @CODIGO";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                sqlCommand.Parameters.AddWithValue("@CODIGO", id);
                DataTable dtAgendamento = new DataTable();
                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;
                sqlAdapter.Fill(dtAgendamento);
                return this.ConverteDataTableEmList(dtAgendamento).ToList();
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

        public Agendamento Consultar(string empresa, string filial, int id)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT AGENDAMENTO.CODIGO, AGENDAMENTO.DATAPREVISTO, "+
                                            "AGENDAMENTO.INICIOPREVISTO, AGENDAMENTO.FIMPREVISTO, "+
                                            "AGENDAMENTO.TRASLADOPREVISTO, AGENDAMENTO.DATACONCLUSAO, "+
                                            "AGENDAMENTO.INICIOCONCLUSAO, AGENDAMENTO.FIMCONCLUSAO, "+
                                            "AGENDAMENTO.RESUMOAGENDAMENTO, "+
                                            "AGENDAMENTO.TRASLADOCONCLUSAO, AGENDAMENTO.EMPRESA, AGENDAMENTO.FILIAL, "+
                                            "AGENDAMENTO.STATUS AS CODIGOSITUACAO, SITUACAO.DESCRICAO AS DESCRICAOSITUACAO, "+
                                            "CLIENTES.CODIGO AS CODIGOCLIENTE, CLIENTES.NOME AS RAZAOSOCIAL, CLIENTES.REDUZIDO AS NOMECLIENTE, CLIENTES.EMAIL AS EMAILCLIENTE, "+
                                            "CLIENTES.UF, CLIENTES.MUNICIPIO, CLIENTES.BAIRRO, CLIENTES.ENDERECO, CLIENTES.DDD, CLIENTES.TELEFONE, "+
                                            "CLIENTES.CNPJ, CLIENTES.IE, CLIENTES.CONTATO, CLIENTES.HOMEPAGE, " +
                                            "FUNCIONARIOS.CODIGO AS CODIGOFUNCIONARIO, FUNCIONARIOS.REDUZIDO AS NOMEFUNCIONARIO, SYS_USERS.EMAIL AS EMAILFUNCIONARIO "+
                                            "FROM AGENDAMENTO "+
                                            "INNER JOIN CLIENTES ON CLIENTES.CODIGO = AGENDAMENTO.CLIENTE "+
                                            "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = AGENDAMENTO.FUNCIONARIO "+
                                            "INNER JOIN SYS_USERS ON SYS_USERS.CODIGO = FUNCIONARIOS.USUARIO "+
                                            "INNER JOIN SITUACAO ON AGENDAMENTO.STATUS = SITUACAO.CODIGO "+
                                            "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = AGENDAMENTO.EMPRESA "+
                                            "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = AGENDAMENTO.FILIAL "+
                                            "WHERE ((AGENDAMENTO.EMPRESA = @EMPRESA) OR (AGENDAMENTO.EMPRESA = '**')) AND "+
                                            "((AGENDAMENTO.FILIAL = @FILIAL) OR (AGENDAMENTO.FILIAL = '**')) AND "+
                                            "AGENDAMENTO.CODIGO = @CODIGO";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                sqlCommand.Parameters.AddWithValue("@CODIGO", id);

                FbDataReader sqlReader = sqlCommand.ExecuteReader();

                Agendamento umAgendamento = new Agendamento();

                int indexEmpresa = sqlReader.GetOrdinal("EMPRESA");
                int indexFilial = sqlReader.GetOrdinal("FILIAL");
                int indexCodigo = sqlReader.GetOrdinal("CODIGO");
                int indexFuncionario = sqlReader.GetOrdinal("CODIGOFUNCIONARIO");
                int indexNomeFuncionario = sqlReader.GetOrdinal("NOMEFUNCIONARIO");
                int indexCliente = sqlReader.GetOrdinal("CODIGOCLIENTE");
                int indexNomeCliente = sqlReader.GetOrdinal("NOMECLIENTE");
                int indexStatus = sqlReader.GetOrdinal("CODIGOSITUACAO");
                int indexDescricaoStatus = sqlReader.GetOrdinal("DESCRICAOSITUACAO");
                int indexDataPrevisto = sqlReader.GetOrdinal("DATAPREVISTO");
                int indexInicioPrevisto = sqlReader.GetOrdinal("INICIOPREVISTO");
                int indexFimPrevisto = sqlReader.GetOrdinal("FIMPREVISTO");
                int indexTrasladoPrevisto = sqlReader.GetOrdinal("TRASLADOPREVISTO");
                int indexDataConclusao = sqlReader.GetOrdinal("DATACONCLUSAO");
                int indexInicioConlusao = sqlReader.GetOrdinal("INICIOCONCLUSAO");
                int indexFimConclusao = sqlReader.GetOrdinal("FIMCONCLUSAO");
                int indexTrasladoConclusao = sqlReader.GetOrdinal("TRASLADOCONCLUSAO");
                int indexResumoAgendamento = sqlReader.GetOrdinal("RESUMOAGENDAMENTO");
                int indexEmailCliente = sqlReader.GetOrdinal("EMAILCLIENTE");
                int indexEmailFuncionario = sqlReader.GetOrdinal("EMAILFUNCIONARIO");
                int indexClienteUf = sqlReader.GetOrdinal("UF");
                int indexClienteMunicipio = sqlReader.GetOrdinal("MUNICIPIO");
                int indexClienteBairro = sqlReader.GetOrdinal("BAIRRO");
                int indexClienteEndereco = sqlReader.GetOrdinal("ENDERECO");
                int indexClienteDDD = sqlReader.GetOrdinal("DDD");
                int indexClienteTelefone = sqlReader.GetOrdinal("TELEFONE");
                int indexClienteRazaoSocial = sqlReader.GetOrdinal("RAZAOSOCIAL");
                int indexClienteCnpj = sqlReader.GetOrdinal("CNPJ");
                int indexClienteIE = sqlReader.GetOrdinal("IE");
                int indexClienteContato = sqlReader.GetOrdinal("CONTATO");
                int indexClienteHomePage = sqlReader.GetOrdinal("HOMEPAGE");

                while (sqlReader.Read())
                {
                    umAgendamento.Codigo = sqlReader.GetInt32(indexCodigo);
                    umAgendamento.ResumoAgendamento = sqlReader.GetString(indexResumoAgendamento);
                    umAgendamento.Empresa = new Empresa();
                    umAgendamento.Empresa.Codigo = sqlReader.GetString(indexEmpresa);
                    umAgendamento.Filial = new Filial();
                    umAgendamento.Filial.Codigo = sqlReader.GetString(indexFilial);
                    umAgendamento.Cliente = new Cliente();
                    umAgendamento.Cliente.Codigo = sqlReader.GetInt32(indexCliente);
                    umAgendamento.Cliente.RazaoSocial = sqlReader.GetString(indexClienteRazaoSocial);
                    umAgendamento.Cliente.Nome = sqlReader.GetString(indexNomeCliente);
                    umAgendamento.Funcionario = new Funcionario();
                    umAgendamento.Funcionario.Codigo = sqlReader.GetInt32(indexFuncionario);
                    umAgendamento.Funcionario.Nome = sqlReader.GetString(indexNomeFuncionario);
                    umAgendamento.Status = new Status();
                    umAgendamento.Status.Codigo = sqlReader.GetInt32(indexStatus);
                    umAgendamento.Status.Descricao = sqlReader.GetString(indexDescricaoStatus);
                    umAgendamento.DataPrevista = sqlReader.GetDateTime(indexDataPrevisto).ToString("dd/MM/yyyy");
                    umAgendamento.InicioPrevisto = sqlReader.GetString(indexInicioPrevisto).Insert(2, ":");
                    umAgendamento.FimPrevisto = sqlReader.GetString(indexFimPrevisto).Insert(2, ":");
                    umAgendamento.TrasladoPrevisto = sqlReader.GetString(indexTrasladoPrevisto).Insert(2, ":");
                    umAgendamento.Cliente.Email = new Email();
                    umAgendamento.Cliente.Email.WebMail = sqlReader.GetString(indexEmailCliente);
                    umAgendamento.Funcionario.Email = new Email();
                    umAgendamento.Funcionario.Email.WebMail = sqlReader.GetString(indexEmailFuncionario);
                    umAgendamento.DataConclusao = sqlReader[indexDataConclusao] != DBNull.Value ? sqlReader.GetDateTime(indexDataConclusao).ToString("dd/MM/yyyy") : "01/01/1900";
                    umAgendamento.InicioConclusao = sqlReader.GetString(indexInicioConlusao) != string.Empty ? sqlReader.GetString(indexInicioConlusao).Insert(2, ":") : string.Empty;
                    umAgendamento.FimConclusao = sqlReader.GetString(indexFimConclusao) != string.Empty ? sqlReader.GetString(indexFimConclusao).Insert(2, ":") : string.Empty;
                    umAgendamento.TrasladoConclusao = sqlReader.GetString(indexTrasladoConclusao) != string.Empty ? sqlReader.GetString(indexTrasladoConclusao).Insert(2, ":") : string.Empty;
                    umAgendamento.Cliente.Endereco = new Endereco();
                    umAgendamento.Cliente.Endereco.Estado = sqlReader.GetString(indexClienteUf);
                    umAgendamento.Cliente.Endereco.Municipio = sqlReader.GetString(indexClienteMunicipio);
                    umAgendamento.Cliente.Endereco.Bairro = sqlReader.GetString(indexClienteBairro);
                    umAgendamento.Cliente.Endereco.Logradouro = sqlReader.GetString(indexClienteEndereco);
                    umAgendamento.Cliente.Telefone = new Telefone();
                    umAgendamento.Cliente.Telefone.Tipo = TipoContato.Corporativo;
                    umAgendamento.Cliente.Telefone.DDD = sqlReader.GetString(indexClienteDDD);
                    umAgendamento.Cliente.Telefone.Numero = sqlReader.GetString(indexClienteTelefone);
                    umAgendamento.Cliente.CNPJ = sqlReader.GetString(indexClienteCnpj);
                    umAgendamento.Cliente.Contato = sqlReader.GetString(indexClienteContato);
                    umAgendamento.Cliente.HomePage = sqlReader.GetString(indexClienteHomePage);
                    umAgendamento.Cliente.IE = sqlReader[indexClienteIE] != null ? sqlReader.GetString(indexClienteIE) : string.Empty;
                }

                return umAgendamento;
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

        protected List<FbParameter> ParametrizarComando(Agendamento obj)
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

            FbParameter sqlpFuncionario = new FbParameter();
            sqlpFuncionario.ParameterName = "@FUNCIONARIO";
            sqlpFuncionario.Value = obj.Funcionario.Codigo;
            lista.Add(sqlpFuncionario);

            FbParameter sqlpCliente = new FbParameter();
            sqlpCliente.ParameterName = "@CLIENTE";
            sqlpCliente.Value = obj.Cliente.Codigo;
            lista.Add(sqlpCliente);

            FbParameter sqlpInicioPrevisto = new FbParameter();
            sqlpInicioPrevisto.ParameterName = "@INICIOPREVISTO";
            sqlpInicioPrevisto.Value = obj.InicioPrevisto.Replace(":", "");
            lista.Add(sqlpInicioPrevisto);

            FbParameter sqlpFimPrevisto = new FbParameter();
            sqlpFimPrevisto.ParameterName = "@FIMPREVISTO";
            sqlpFimPrevisto.Value = obj.FimPrevisto.Replace(":", "");
            lista.Add(sqlpFimPrevisto);

            FbParameter sqlpTrasladoPrevisto = new FbParameter();
            sqlpTrasladoPrevisto.ParameterName = "@TRASLADOPREVISTO";
            sqlpTrasladoPrevisto.Value = obj.TrasladoPrevisto.Replace(":", "");
            lista.Add(sqlpTrasladoPrevisto);

            FbParameter sqlpDataPrevista = new FbParameter();
            sqlpDataPrevista.ParameterName = "@DATAPREVISTO";
            sqlpDataPrevista.Value = obj.DataPrevista;
            lista.Add(sqlpDataPrevista);

            FbParameter sqlpStatus = new FbParameter();
            sqlpStatus.ParameterName = "@STATUS";
            sqlpStatus.Value = obj.Status.Codigo;
            lista.Add(sqlpStatus);

            FbParameter sqlpResumoAgendamneto = new FbParameter();
            sqlpResumoAgendamneto.ParameterName = "@RESUMOAGENDAMENTO";
            sqlpResumoAgendamneto.Value = obj.ResumoAgendamento;
            lista.Add(sqlpResumoAgendamneto);

            if (obj.Codigo != 0)
            {
                FbParameter sqlpInicioConclusao = new FbParameter();
                sqlpInicioConclusao.ParameterName = "@INICIOCONCLUSAO";
                sqlpInicioConclusao.Value = obj.InicioConclusao != null ? obj.InicioConclusao.Replace(":", "") : "";
                lista.Add(sqlpInicioConclusao);

                FbParameter sqlpFimConclusao = new FbParameter();
                sqlpFimConclusao.ParameterName = "@FIMCONCLUSAO";
                sqlpFimConclusao.Value = obj.FimConclusao != null ? obj.FimConclusao.Replace(":", "") : "";
                lista.Add(sqlpFimConclusao);

                FbParameter sqlpTrasladoConclusao = new FbParameter();
                sqlpTrasladoConclusao.ParameterName = "@TRASLADOCONCLUSAO";
                sqlpTrasladoConclusao.Value = obj.TrasladoConclusao != null ? obj.TrasladoConclusao.Replace(":", "") : "";
                lista.Add(sqlpTrasladoConclusao);

                FbParameter sqlpDataConclusao = new FbParameter();
                sqlpDataConclusao.ParameterName = "@DATACONCLUSAO";
                sqlpDataConclusao.Value = obj.DataConclusao;
                lista.Add(sqlpDataConclusao);

                FbParameter sqlpCodigo = new FbParameter();
                sqlpCodigo.ParameterName = "@CODIGO";
                sqlpCodigo.Value = obj.Codigo;
                lista.Add(sqlpCodigo);
            }

            return lista;
        }

        protected IEnumerable<Agendamento> ConverteDataTableEmList(DataTable dt)
        {
            int indexEmpresa = dt.Columns["EMPRESA"].Ordinal;
            int indexFilial = dt.Columns["FILIAL"].Ordinal;
            int indexCodigo = dt.Columns["CODIGO"].Ordinal;
            int indexResumoAgendamento = dt.Columns["RESUMOAGENDAMENTO"].Ordinal;
            int indexFuncionario = dt.Columns["CODIGOFUNCIONARIO"].Ordinal;
            int indexNomeFuncionario = dt.Columns["NOMEFUNCIONARIO"].Ordinal;
            int indexCliente = dt.Columns["CODIGOCLIENTE"].Ordinal;
            int indexNomeCliente = dt.Columns["NOMECLIENTE"].Ordinal;
            int indexStatus = dt.Columns["CODIGOSITUACAO"].Ordinal;
            int indexDescricaoStatus = dt.Columns["DESCRICAOSITUACAO"].Ordinal;
            int indexDataPrevisto = dt.Columns["DATAPREVISTO"].Ordinal;
            int indexInicioPrevisto = dt.Columns["INICIOPREVISTO"].Ordinal;
            int indexFimPrevisto = dt.Columns["FIMPREVISTO"].Ordinal;
            int indexTrasladoPrevisto = dt.Columns["TRASLADOPREVISTO"].Ordinal;
            int indexDataConclusao = dt.Columns["DATACONCLUSAO"].Ordinal;
            int indexInicioConlusao = dt.Columns["INICIOCONCLUSAO"].Ordinal;
            int indexFimConclusao = dt.Columns["FIMCONCLUSAO"].Ordinal;
            int indexTrasladoConclusao = dt.Columns["TRASLADOCONCLUSAO"].Ordinal;
            int indexEmailCliente = dt.Columns["EMAILCLIENTE"].Ordinal;
            int indexEmailFuncionario = dt.Columns["EMAILFUNCIONARIO"].Ordinal;
            int indexClienteUf = dt.Columns["UF"].Ordinal;
            int indexClienteMunicipio = dt.Columns["MUNICIPIO"].Ordinal;
            int indexClienteBairro = dt.Columns["BAIRRO"].Ordinal;
            int indexClienteEndereco = dt.Columns["ENDERECO"].Ordinal;
            int indexClienteDDD = dt.Columns["DDD"].Ordinal;
            int indexClienteTelefone = dt.Columns["TELEFONE"].Ordinal;
            int indexClienteRazaoSocial = dt.Columns["RAZAOSOCIAL"].Ordinal;

            foreach (DataRow linha in dt.Rows)
            {
                Agendamento umAgendamento = new Agendamento();
                umAgendamento.Codigo = Convert.ToInt32(linha[indexCodigo].ToString());
                umAgendamento.ResumoAgendamento = linha[indexResumoAgendamento].ToString();
                umAgendamento.Empresa = new Empresa();
                umAgendamento.Empresa.Codigo = linha[indexEmpresa].ToString();
                umAgendamento.Filial = new Filial();
                umAgendamento.Filial.Codigo = linha[indexFilial].ToString();
                umAgendamento.Cliente = new Cliente();
                umAgendamento.Cliente.Codigo = Convert.ToInt32(linha[indexCliente].ToString());
                umAgendamento.Cliente.RazaoSocial = linha[indexClienteRazaoSocial].ToString();
                umAgendamento.Cliente.Nome = linha[indexNomeCliente].ToString();
                umAgendamento.Funcionario = new Funcionario();
                umAgendamento.Funcionario.Codigo = Convert.ToInt32(linha[indexFuncionario].ToString());
                umAgendamento.Funcionario.Reduzido = linha[indexNomeFuncionario].ToString();
                umAgendamento.Status = new Status();
                umAgendamento.Status.Codigo = Convert.ToInt32(linha[indexStatus].ToString());
                umAgendamento.Status.Descricao = linha[indexDescricaoStatus].ToString();
                umAgendamento.DataPrevista = Convert.ToDateTime(linha[indexDataPrevisto].ToString()).ToString("dd/MM/yyyy");
                umAgendamento.InicioPrevisto = linha[indexInicioPrevisto].ToString().Insert(2, ":");
                umAgendamento.FimPrevisto = linha[indexFimPrevisto].ToString().Insert(2, ":");
                umAgendamento.TrasladoPrevisto = linha[indexTrasladoPrevisto].ToString().Insert(2, ":");
                umAgendamento.DataConclusao = linha[indexDataConclusao].ToString() != "" ? Convert.ToDateTime(linha[indexDataConclusao].ToString()).ToString("dd/MM/yyyy") : "01/01/1900";
                umAgendamento.Cliente.Email = new Email();
                umAgendamento.Cliente.Email.WebMail = linha[indexEmailCliente].ToString();
                umAgendamento.Funcionario.Email = new Email();
                umAgendamento.Funcionario.Email.WebMail = linha[indexEmailFuncionario].ToString();
                umAgendamento.InicioConclusao = linha[indexInicioConlusao].ToString() != "" ? linha[indexInicioConlusao].ToString().Insert(2, ":") : "";
                umAgendamento.FimConclusao = linha[indexFimConclusao].ToString() != "" ? linha[indexFimConclusao].ToString().Insert(2, ":") : "";
                umAgendamento.TrasladoConclusao = linha[indexTrasladoConclusao].ToString() != "" ? linha[indexTrasladoConclusao].ToString().Insert(2, ":") : "";
                umAgendamento.Cliente.Endereco = new Endereco();
                umAgendamento.Cliente.Endereco.Estado = linha[indexClienteUf].ToString();
                umAgendamento.Cliente.Endereco.Municipio = linha[indexClienteMunicipio].ToString();
                umAgendamento.Cliente.Endereco.Bairro = linha[indexClienteBairro].ToString();
                umAgendamento.Cliente.Endereco.Logradouro = linha[indexClienteEndereco].ToString();
                umAgendamento.Cliente.Telefone = new Telefone();
                umAgendamento.Cliente.Telefone.Tipo = TipoContato.Corporativo;
                umAgendamento.Cliente.Telefone.DDD = linha[indexClienteDDD].ToString();
                umAgendamento.Cliente.Telefone.Numero = linha[indexClienteTelefone].ToString();
                yield return umAgendamento;
            }
        }
    }
}
