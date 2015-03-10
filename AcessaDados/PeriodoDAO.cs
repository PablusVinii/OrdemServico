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
    public class PeriodoDAO:IPeriodoRepositorio
    {
        FbConnection _conexao = null;

        public PeriodoDAO(FbConnection conn)
        {
            this._conexao = conn;

            if (this._conexao.State == System.Data.ConnectionState.Closed)
            {
                this._conexao.Open();
            }
        }

        public void Cadastrar(Periodo obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "INSERT INTO PERIODO (EMPRESA, FILIAL, ANO, MES, REALIZADO, ESPERADO, META, FUNCIONARIO) VALUES "+
                                         "(@EMPRESA, @FILIAL, @ANO, @MES, @REALIZADO, @ESPERADO, @META, @FUNCIONARIO)";

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

        public void Editar(Periodo obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "UPDATE PERIODO SET EMPRESA = @EMPRESA, FILIAL = @FILIAL, "+
                                         "REALIZADO = @REALIZADO, ESPERADO = @ESPERADO "+
                                         "WHERE ANO = @ANO AND MES = @MES AND META = @META AND FUNCIONARIO = @FUNCIONARIO";

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

        public void Excluir(Periodo obj)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "DELETE FROM PERIODO WHERE PERIODO.ANO = @ANO AND PERIODO.MES = @MES AND PERIODO.META = @META AND FUNCIONARIO = @FUNCIONARIO";
                sqlCommand.Parameters.AddWithValue("@ANO", obj.Ano);
                sqlCommand.Parameters.AddWithValue("@MES", obj.Mes);
                sqlCommand.Parameters.AddWithValue("@META", obj.Meta.Codigo);
                sqlCommand.Parameters.AddWithValue("@FUNCIONARIO", obj.Meta.Funcionario.Codigo);
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

        public List<Periodo> Listar(string empresa, string filial)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT PERIODO.EMPRESA, PERIODO.FILIAL, PERIODO.ANO, PERIODO.MES, PERIODO.ESPERADO, "+
                                        "PERIODO.REALIZADO, META.CODIGO AS CODMETA, META.DESCRICAO AS DESCMETA, "+
                                        "FUNCIONARIOS.CODIGO AS CODFUNC, FUNCIONARIOS.NOME AS NOMEFUNC "+
                                        "FROM PERIODO "+
                                        "INNER JOIN META ON META.CODIGO = PERIODO.META "+
                                        "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = META.FUNCIONARIO "+
                                        "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = PERIODO.EMPRESA "+
                                        "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = PERIODO.FILIAL "+
                                        "WHERE ((PERIODO.EMPRESA = @EMPRESA) OR (PERIODO.EMPRESA = '**')) AND "+
                                        "((PERIODO.FILIAL = @FILIAL) OR (PERIODO.FILIAL = '**'))";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                DataTable dtPeriodos = new DataTable();
                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;
                sqlAdapter.Fill(dtPeriodos);
                return this.ConverteDataTableEmList(dtPeriodos).ToList();
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

        public List<Periodo> Pesquisar(string empresa, string filial, int id)
        {
            throw new NotImplementedException();
        }

        public Periodo Consultar(string empresa, string filia, int id)
        {
            throw new NotImplementedException();
        }

        public Periodo Consultar(string empresa, string filial, int ano, int mes, int meta, int funcionario)
        {    
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT PERIODO.EMPRESA, PERIODO.FILIAL, PERIODO.ANO, PERIODO.MES, PERIODO.ESPERADO, "+
                                        "PERIODO.REALIZADO, META.CODIGO AS CODMETA, META.DESCRICAO AS DESCMETA, "+
                                        "FUNCIONARIOS.CODIGO AS CODFUNC, FUNCIONARIOS.NOME AS NOMEFUNC "+
                                        "FROM PERIODO "+
                                        "INNER JOIN META ON META.CODIGO = PERIODO.META "+
                                        "INNER JOIN FUNCIONARIOS ON FUNCIONARIOS.CODIGO = META.FUNCIONARIO "+
                                        "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = PERIODO.EMPRESA "+
                                        "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = PERIODO.FILIAL "+
                                        "WHERE ((PERIODO.EMPRESA = @EMPRESA) OR (PERIODO.EMPRESA = '**')) AND "+
                                        "((PERIODO.FILIAL = @FILIAL) OR (PERIODO.FILIAL = '**')) "+
                                        "AND PERIODO.ANO = @ANO AND PERIODO.MES = @MES AND META.CODIGO = @META "+
                                        "AND FUNCIONARIOS.CODIGO = @FUNCIONARIO";

                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Parameters.AddWithValue("@FILIAL", filial);
                sqlCommand.Parameters.AddWithValue("@ANO", ano);
                sqlCommand.Parameters.AddWithValue("@MES", mes);
                sqlCommand.Parameters.AddWithValue("@META", meta);
                sqlCommand.Parameters.AddWithValue("@FUNCIONARIO", funcionario);

                FbDataReader sqlDataReader = sqlCommand.ExecuteReader();

                Periodo umPeriodo = null;

                int indexEmpresa = sqlDataReader.GetOrdinal("EMPRESA");
                int indexFilial = sqlDataReader.GetOrdinal("FILIAL");
                int indexAno = sqlDataReader.GetOrdinal("ANO");
                int indexMes = sqlDataReader.GetOrdinal("MES");
                int indexEsperado = sqlDataReader.GetOrdinal("ESPERADO");
                int indexRealizado = sqlDataReader.GetOrdinal("REALIZADO");
                int indexCodMeta = sqlDataReader.GetOrdinal("CODFUNC");
                int indexDescMeta = sqlDataReader.GetOrdinal("DESCMETA");
                int indexCodFunc = sqlDataReader.GetOrdinal("CODFUNC");
                int indexDescFunc = sqlDataReader.GetOrdinal("NOMEFUNC");

                while (sqlDataReader.Read())
                {
                    umPeriodo = new Periodo();
                    umPeriodo.Empresa = new Empresa();
                    umPeriodo.Empresa.Codigo = sqlDataReader.GetString(indexEmpresa);
                    umPeriodo.Filial = new Filial();
                    umPeriodo.Filial.Codigo = sqlDataReader.GetString(indexFilial);
                    umPeriodo.Ano = sqlDataReader.GetInt32(indexAno);
                    umPeriodo.Mes = sqlDataReader.GetInt32(indexMes);
                    umPeriodo.Meta = new Meta();
                    umPeriodo.Meta.Codigo = sqlDataReader.GetInt32(indexCodMeta);
                    umPeriodo.Meta.Descricao = sqlDataReader.GetString(indexDescMeta);
                    umPeriodo.Esperado = sqlDataReader.GetInt32(indexEsperado);
                    umPeriodo.Realizado = sqlDataReader.GetInt32(indexRealizado);
                    umPeriodo.Meta.Funcionario = new Funcionario();
                    umPeriodo.Meta.Funcionario.Codigo = sqlDataReader.GetInt32(indexCodFunc);
                    umPeriodo.Meta.Funcionario.Nome = sqlDataReader.GetString(indexDescFunc);
                }

                return umPeriodo;
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

        protected List<FbParameter> ParametrizarComando(Periodo obj)
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

            FbParameter sqlpAno = new FbParameter();
            sqlpAno.ParameterName = "@ANO";
            sqlpAno.Value = obj.Ano;
            lista.Add(sqlpAno);

            FbParameter sqlpMes = new FbParameter();
            sqlpMes.ParameterName = "@MES";
            sqlpMes.Value = obj.Mes;
            lista.Add(sqlpMes);

            FbParameter sqlpRealizado = new FbParameter();
            sqlpRealizado.ParameterName = "@REALIZADO";      
            sqlpRealizado.Value = obj.Realizado;
            lista.Add(sqlpRealizado);

            FbParameter sqlpEsperado = new FbParameter();
            sqlpEsperado.ParameterName = "@ESPERADO";
            sqlpEsperado.Value = obj.Esperado;
            lista.Add(sqlpEsperado);

            FbParameter sqlpMeta = new FbParameter();
            sqlpMeta.ParameterName = "@META";
            sqlpMeta.Value = obj.Meta.Codigo;
            lista.Add(sqlpMeta);

            FbParameter sqlpFuncionario = new FbParameter();
            sqlpFuncionario.ParameterName = "@FUNCIONARIO";
            sqlpFuncionario.Value = obj.Meta.Funcionario.Codigo;
            lista.Add(sqlpFuncionario);

            return lista;
        }

        protected IEnumerable<Periodo> ConverteDataTableEmList(DataTable dt)
        {
            int indexEmpresa = dt.Columns["EMPRESA"].Ordinal;
            int indexFilial = dt.Columns["FILIAL"].Ordinal;
            int indexAno = dt.Columns["ANO"].Ordinal;
            int indexMes = dt.Columns["MES"].Ordinal;
            int indexEsperado = dt.Columns["ESPERADO"].Ordinal;
            int indexRealizado = dt.Columns["REALIZADO"].Ordinal;
            int indexCodMeta = dt.Columns["CODFUNC"].Ordinal;
            int indexDescMeta = dt.Columns["DESCMETA"].Ordinal;
            int indexCodFunc = dt.Columns["CODFUNC"].Ordinal;
            int indexDescFunc = dt.Columns["NOMEFUNC"].Ordinal;

            foreach (DataRow linha in dt.Rows)
            {
                Periodo umPeriodo = new Periodo();
                umPeriodo.Empresa = new Empresa();
                umPeriodo.Empresa.Codigo = linha[indexEmpresa].ToString();
                umPeriodo.Filial = new Filial();
                umPeriodo.Filial.Codigo = linha[indexFilial].ToString();
                umPeriodo.Meta = new Meta();
                umPeriodo.Meta.Codigo = Convert.ToInt32(linha[indexCodMeta].ToString());
                umPeriodo.Meta.Descricao = linha[indexDescMeta].ToString(); 
                umPeriodo.Meta.Funcionario = new Funcionario();
                umPeriodo.Meta.Funcionario.Codigo = Convert.ToInt32(linha[indexCodFunc].ToString());
                umPeriodo.Meta.Funcionario.Nome = linha[indexDescFunc].ToString();
                umPeriodo.Realizado = Convert.ToInt32(linha[indexRealizado].ToString());
                umPeriodo.Esperado = Convert.ToInt32(linha[indexEsperado].ToString());
                yield return umPeriodo;                
            }
        }
    }
}
