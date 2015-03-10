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
// Data: 20/06/2014
// ********************************************************************* 
// Entidade Projeto 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace AcessaDados
{
    public class ProjetoDAO : IProjetoRepositorio
    {
        protected FbConnection _conexao = null;

        public ProjetoDAO(FbConnection conn)
        {
            this._conexao = conn;

            if (this._conexao.State == System.Data.ConnectionState.Closed)
            {
                this._conexao.Open();
            }
        }

        public void Cadastrar(Projeto obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "INSERT INTO PROJETOS (CLIENTE, EMPRESA, FILIAL, HORASGERENTE, HORASCONSULTOR, HORASCOORDENADOR, DESCRICAO, META) " +
                                         "VALUES (@CLIENTE, @EMPRESA, @FILIAL, @HORAGERENTE, @HORACONSULTOR, @HORACOORDENADOR, @DESCRICAO, @META)";

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

        public void Editar(Projeto obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "UPDATE PROJETOS SET CLIENTE = @CLIENTE, DESCRICAO = @DESCRICAO, EMPRESA = @EMPRESA, FILIAL = @FILIAL, " +
                                         "HORASGERENTE = @HORAGERENTE, HORASCONSULTOR = @HORACONSULTOR, HORASCOORDENADOR = @HORACOORDENADOR, " +
                                         "META = @META " +
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

        public void Excluir(Projeto obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "DELETE FROM PROJETOS WHERE CODIGO = @CODIGO";
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

        public List<Projeto> Listar(string empresa, string filial)
        {
            FbCommand comando = new FbCommand();

            try
            {
                comando.Connection = this._conexao;
                comando.CommandText = "SELECT PROJETOS.CODIGO, PROJETOS.HORASGERENTE, PROJETOS.DESCRICAO, " +
                                        "PROJETOS.HORASCOORDENADOR, PROJETOS.HORASCONSULTOR, " +
                                        "CLIENTES.CODIGO AS CODCLIENTE, CLIENTES.REDUZIDO AS NOMECLIENTE, " +
                                        "META.CODIGO AS CODMETA, META.DESCRICAO AS DESCMETA, " +
                                        "SYS_COMPANY.EMPRESA AS CODEMPRESA, SYS_COMPANY.NOME AS NOMEEMPRESA, " +
                                        "SYS_BRANCH.FILIAL AS CODFILIAL, SYS_BRANCH.NOME AS NOMEFILIAL " +
                                        "FROM PROJETOS INNER JOIN CLIENTES ON CLIENTES.CODIGO = PROJETOS.CLIENTE " +
                                        "LEFT JOIN META ON META.CODIGO = PROJETOS.META " +
                                        "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = PROJETOS.EMPRESA " +
                                        "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = PROJETOS.FILIAL " +
                                        "WHERE ((PROJETOS.EMPRESA = @EMPRESA) OR (PROJETOS.EMPRESA = '**') ) " +
                                        "AND ((PROJETOS.FILIAL = @FILIAL) OR (PROJETOS.FILIAL = '**'))";

                comando.Parameters.AddWithValue("@EMPRESA", empresa);
                comando.Parameters.AddWithValue("@FILIAL", filial);

                FbDataAdapter adaptador = new FbDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable dtProjeto = new DataTable();
                adaptador.Fill(dtProjeto);
                return this.ConverteDataTableEmList(dtProjeto).ToList();
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

        public List<Projeto> Pesquisar(string empresa, string filial, int id)
        {
            FbCommand comando = new FbCommand();

            try
            {
                comando.Connection = this._conexao;
                comando.CommandText = "SELECT PROJETOS.CODIGO, PROJETOS.HORASGERENTE, PROJETOS.DESCRICAO, PROJETOS.HORASCOORDENADOR, PROJETOS.HORASCONSULTOR, " +
                                      "CLIENTES.CODIGO AS CODCLIENTE, CLIENTES.NOME AS NOMECLIENTE, " +
                                      "META.CODIGO AS CODMETA, META.DESCRICAO AS DESCMETA, " +
                                      "SYS_COMPANY.EMPRESA AS CODEMPRESA, SYS_COMPANY.REDUZIDO AS NOMEEMPRESA, " +
                                      "SYS_BRANCH.FILIAL AS CODFILIAL, SYS_BRANCH.NOME AS NOMEFILIAL " +
                                      "FROM PROJETOS INNER JOIN CLIENTES ON CLIENTES.CODIGO = PROJETOS.CLIENTE " +
                                      "LEFT JOIN META ON META.CODIGO = PROJETOS.META " +
                                      "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = PROJETOS.EMPRESA " +
                                      "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = PROJETOS.FILIAL " +
                                      "WHERE ((PROJETOS.EMPRESA = @EMPRESA) OR (PROJETOS.EMPRESA = '**') ) " +
                                      "AND ((PROJETOS.FILIAL = @FILIAL) OR (PROJETOS.FILIAL = '**')) " +
                                      "AND PROJETOS.CLIENTE = @CODIGO";

                comando.Parameters.AddWithValue("@EMPRESA", empresa);
                comando.Parameters.AddWithValue("@FILIAL", filial);
                comando.Parameters.AddWithValue("@CODIGO", id);

                FbDataAdapter adaptador = new FbDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable dtProjeto = new DataTable();
                adaptador.Fill(dtProjeto);
                return this.ConverteDataTableEmList(dtProjeto).ToList();
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

        public List<Projeto> Pesquisar(string empresa, string filial, string descricao)
        {
            FbCommand comando = new FbCommand();

            try
            {
                comando.Connection = this._conexao;
                comando.CommandText = "SELECT PROJETOS.CODIGO, PROJETOS.HORASGERENTE, PROJETOS.DESCRICAO, PROJETOS.HORASCOORDENADOR, PROJETOS.HORASCONSULTOR, " +
                                      "CLIENTES.CODIGO AS CODCLIENTE, CLIENTES.NOME AS NOMECLIENTE, " +
                                      "META.CODIGO AS CODMETA, META.DESCRICAO AS DESCMETA, " +
                                      "SYS_COMPANY.EMPRESA AS CODEMPRESA, SYS_COMPANY.REDUZIDO AS NOMEEMPRESA, " +
                                      "SYS_BRANCH.FILIAL AS CODFILIAL, SYS_BRANCH.NOME AS NOMEFILIAL " +
                                      "FROM PROJETOS INNER JOIN CLIENTES ON CLIENTES.CODIGO = PROJETOS.CLIENTE " +
                                      "LEFT JOIN META ON META.CODIGO = PROJETOS.META " +
                                      "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = PROJETOS.EMPRESA " +
                                      "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = PROJETOS.FILIAL " +
                                      "WHERE ((PROJETOS.EMPRESA = @EMPRESA) OR (PROJETOS.EMPRESA = '**') ) " +
                                      "AND ((PROJETOS.FILIAL = @FILIAL) OR (PROJETOS.FILIAL = '**')) " +
                                      "AND PROJETOS.DESCRICAO LIKE @DESCRICAO";

                comando.Parameters.AddWithValue("@EMPRESA", empresa);
                comando.Parameters.AddWithValue("@FILIAL", filial);
                comando.Parameters.AddWithValue("@DESCRICAO", "%" + descricao + "%");

                FbDataAdapter adaptador = new FbDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable dtProjeto = new DataTable();
                adaptador.Fill(dtProjeto);
                return this.ConverteDataTableEmList(dtProjeto).ToList();
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

        public Projeto Consultar(string empresa, string filial, int id)
        {
            FbCommand comando = new FbCommand();

            try
            {
                comando.Connection = this._conexao;
                comando.CommandText = "SELECT PROJETOS.CODIGO, PROJETOS.HORASGERENTE, PROJETOS.DESCRICAO, PROJETOS.HORASCOORDENADOR, PROJETOS.HORASCONSULTOR, " +
                                        "CLIENTES.CODIGO AS CODCLIENTE, CLIENTES.REDUZIDO AS NOMECLIENTE, " +
                                        "META.CODIGO AS CODMETA, META.DESCRICAO AS DESCMETA, " +
                                        "SYS_COMPANY.EMPRESA AS CODEMPRESA, SYS_COMPANY.NOME AS NOMEEMPRESA, " +
                                        "SYS_BRANCH.FILIAL AS CODFILIAL, SYS_BRANCH.NOME AS NOMEFILIAL " +
                                        "FROM PROJETOS " +
                                        "INNER JOIN CLIENTES ON CLIENTES.CODIGO = PROJETOS.CLIENTE " +
                                        "LEFT JOIN META ON META.CODIGO = PROJETOS.META " +
                                        "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = PROJETOS.EMPRESA " +
                                        "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = PROJETOS.FILIAL " +
                                        "WHERE ((PROJETOS.EMPRESA = @EMPRESA) OR (PROJETOS.EMPRESA = '**') ) " +
                                        "AND ((PROJETOS.FILIAL = @FILIAL) OR (PROJETOS.FILIAL = '**')) " +
                                        "AND PROJETOS.CODIGO = @CODIGO";

                comando.Parameters.AddWithValue("@EMPRESA", empresa);
                comando.Parameters.AddWithValue("@FILIAL", filial);
                comando.Parameters.AddWithValue("@CODIGO", id);

                FbDataReader reader = comando.ExecuteReader();

                int indexCodigo = reader.GetOrdinal("CODIGO");
                int indexDescricao = reader.GetOrdinal("DESCRICAO");
                int indexHorasGerente = reader.GetOrdinal("HORASGERENTE");
                int indexHorasCoordenador = reader.GetOrdinal("HORASCOORDENADOR");
                int indexHorasConsultor = reader.GetOrdinal("HORASCONSULTOR");
                int indexCodCliente = reader.GetOrdinal("CODCLIENTE");
                int indexNomeCliente = reader.GetOrdinal("NOMECLIENTE");
                int indexCodEmpresa = reader.GetOrdinal("CODEMPRESA");
                int indexNomeEmpresa = reader.GetOrdinal("NOMEEMPRESA");
                int indexCodFilial = reader.GetOrdinal("CODFILIAL");
                int indexNomeFilial = reader.GetOrdinal("NOMEFILIAL");
                int indexCodMeta = reader.GetOrdinal("CODMETA");
                int indexDescMeta = reader.GetOrdinal("DESCMETA");

                Projeto umProjeto = new Projeto();

                while (reader.Read())
                {
                    umProjeto.Codigo = reader.GetInt32(indexCodigo);
                    umProjeto.Descricao = reader.GetString(indexDescricao);
                    umProjeto.HorasGerente = reader.GetString(indexHorasGerente).Insert(reader.GetString(indexHorasGerente).Length - 2, ":");
                    umProjeto.HorasCoordenador = reader.GetString(indexHorasCoordenador).Insert(reader.GetString(indexHorasCoordenador).Length - 2, ":");
                    umProjeto.HorasConsultor = reader.GetString(indexHorasConsultor).Insert(reader.GetString(indexHorasConsultor).Length - 2, ":");
                    umProjeto.Cliente = new Cliente();
                    umProjeto.Cliente.Codigo = reader.GetInt32(indexCodCliente);
                    umProjeto.Cliente.Nome = reader.GetString(indexNomeCliente);
                    umProjeto.Empresa = new Empresa();
                    umProjeto.Empresa.Codigo = reader.GetString(indexCodEmpresa);
                    umProjeto.Empresa.Nome = reader.GetString(indexNomeEmpresa);
                    umProjeto.Filial = new Filial();
                    umProjeto.Filial.Codigo = reader.GetString(indexCodFilial);
                    umProjeto.Filial.Nome = reader.GetString(indexNomeFilial);
                    umProjeto.Meta = new Meta();
                    umProjeto.Meta.Codigo = reader[indexCodMeta] != DBNull.Value ? reader.GetInt32(indexCodMeta) : 0;
                    umProjeto.Meta.Descricao = reader[indexDescMeta] != DBNull.Value? reader.GetString(indexDescMeta):"";
                }

                return umProjeto;
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

        protected List<FbParameter> ParametrizarComando(Projeto obj)
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

            FbParameter sqlpCliente = new FbParameter();
            sqlpCliente.ParameterName = "@CLIENTE";
            sqlpCliente.Value = obj.Cliente.Codigo;
            lista.Add(sqlpCliente);

            FbParameter sqlpHoraGerente = new FbParameter();
            sqlpHoraGerente.ParameterName = "@HORAGERENTE";
            sqlpHoraGerente.Value = obj.HorasGerente.Replace(":", "");
            lista.Add(sqlpHoraGerente);

            FbParameter sqlpHoraConsultor = new FbParameter();
            sqlpHoraConsultor.ParameterName = "@HORACONSULTOR";
            sqlpHoraConsultor.Value = obj.HorasConsultor.Replace(":", "");
            lista.Add(sqlpHoraConsultor);

            FbParameter sqlpHoraCoordenador = new FbParameter();
            sqlpHoraCoordenador.ParameterName = "@HORACOORDENADOR";
            sqlpHoraCoordenador.Value = obj.HorasCoordenador.Replace(":", "");
            lista.Add(sqlpHoraCoordenador);

            FbParameter sqlpDescricao = new FbParameter();
            sqlpDescricao.ParameterName = "@DESCRICAO";
            sqlpDescricao.Value = obj.Descricao;
            lista.Add(sqlpDescricao);

            if (obj.Codigo != 0)
            {
                FbParameter sqlpCodigo = new FbParameter();
                sqlpCodigo.ParameterName = "@CODIGO";
                sqlpCodigo.Value = obj.Codigo;
                lista.Add(sqlpCodigo);
            }


            FbParameter sqlpMeta = new FbParameter();
            sqlpMeta.ParameterName = "@META";

            if ((obj.Meta != null) && (obj.Meta.Codigo != 0))
            {
                sqlpMeta.Value = obj.Meta.Codigo;
            }
            else
            {
                sqlpMeta.Value = null;
            }

            lista.Add(sqlpMeta);

            return lista;
        }

        protected IEnumerable<Projeto> ConverteDataTableEmList(DataTable dt)
        {
            int indexCodigo = dt.Columns["CODIGO"].Ordinal;
            int indexDescricao = dt.Columns["DESCRICAO"].Ordinal;
            int indexHorasGerente = dt.Columns["HORASGERENTE"].Ordinal;
            int indexHorasCoordenador = dt.Columns["HORASCOORDENADOR"].Ordinal;
            int indexHorasConsultor = dt.Columns["HORASCONSULTOR"].Ordinal;
            int indexCodCliente = dt.Columns["CODCLIENTE"].Ordinal;
            int indexNomeCliente = dt.Columns["NOMECLIENTE"].Ordinal;
            int indexCodEmpresa = dt.Columns["CODEMPRESA"].Ordinal;
            int indexNomeEmpresa = dt.Columns["NOMEEMPRESA"].Ordinal;
            int indexCodFilial = dt.Columns["CODFILIAL"].Ordinal;
            int indexNomeFilial = dt.Columns["NOMEFILIAL"].Ordinal;
            int indexCodMeta = dt.Columns["CODMETA"].Ordinal;
            int indexDescMeta = dt.Columns["DESCMETA"].Ordinal;

            foreach (DataRow linha in dt.Rows)
            {
                Projeto umProjeto = new Projeto();
                umProjeto.Codigo = Convert.ToInt32(linha[indexCodigo].ToString());
                umProjeto.Descricao = linha[indexDescricao].ToString();
                umProjeto.HorasConsultor = linha[indexHorasConsultor].ToString().Insert(linha[indexHorasConsultor].ToString().Length - 2, ":");
                umProjeto.HorasCoordenador = linha[indexHorasCoordenador].ToString().Insert(linha[indexHorasCoordenador].ToString().Length - 2, ":");
                umProjeto.HorasGerente = linha[indexHorasGerente].ToString().Insert(linha[indexHorasGerente].ToString().Length - 2, ":");
                umProjeto.Cliente = new Cliente();
                umProjeto.Cliente.Codigo = Convert.ToInt32(linha[indexCodCliente].ToString());
                umProjeto.Cliente.Nome = linha[indexNomeCliente].ToString();
                umProjeto.Empresa = new Empresa();
                umProjeto.Empresa.Codigo = linha[indexCodEmpresa].ToString();
                umProjeto.Empresa.Nome = linha[indexNomeCliente].ToString();
                umProjeto.Filial = new Filial();
                umProjeto.Filial.Codigo = linha[indexCodFilial].ToString();
                umProjeto.Filial.Nome = linha[indexNomeFilial].ToString();
                umProjeto.Meta = new Meta();
                umProjeto.Meta.Codigo = linha[indexCodMeta].ToString() != "" ? Convert.ToInt32(linha[indexCodMeta].ToString()) : 0;
                umProjeto.Meta.Descricao = linha[indexDescMeta].ToString();
                yield return umProjeto;
            }
        }
    }
}
