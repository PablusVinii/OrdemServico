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
// Data: 12/08/2014
// ********************************************************************* 
// Entidade OrdemServicoRemoto
//
// ********************************************************************* 
//
// ********************************************************************* 

namespace AcessaDados
{
    public class OrdemServicoRemotoDAO : IOrdemServicoRemotoRepositorio
    {
        protected FbConnection _connection = null;

        public OrdemServicoRemotoDAO(FbConnection conn)
        {
            this._connection = conn;
            if (this._connection.State == System.Data.ConnectionState.Closed)
            {
                this._connection.Open();
            }
        }

        public void Cadastrar(OrdemServicoRemoto obj)
        {
            string query = "INSERT INTO ORDEM_SERVICO_REMOTO (ORDEMSERVICO, INICIO, FIM, TOTAL) VALUES (@ORDEMSERVICO, @INICIO, @FIM, @TOTAL)";
            this.ExecutarComando(query, this.CarregarParametros(obj));
        }

        public void Editar(OrdemServicoRemoto obj)
        {
            string query = "UPDATE ORDEM_SERVICO_REMOTO SET INICIO = @INICIO, FIM = @FIM, TOTAL = @TOTAL WHERE ORDEMSERVICO = @ORDEMSERVICO";
            this.ExecutarComando(query, this.CarregarParametros(obj));
        }

        public void Excluir(OrdemServicoRemoto obj)
        {
            string query = "DELETE FROM ORDEM_SERVICO_REMOTO WHERE ORDEMSERVICO = @ORDEMSERVICO";
            List<FbParameter> lista = new List<FbParameter>();
            lista.Add(new FbParameter { ParameterName = "@ORDEMSERVICO", Value = obj.OrdemServico.Codigo });
            this.ExecutarComando(query, lista);
        }

        protected void ExecutarComando(string query, List<FbParameter> parametros)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._connection;
                sqlCommand.CommandText = query;
                sqlCommand.Parameters.AddRange(parametros);
                sqlCommand.ExecuteNonQuery();
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

        protected FbDataReader ExecutarLeitura(int codigo)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._connection;
                sqlCommand.CommandText = "SELECT ORDEMSERVICO, INICIO, FIM, TOTAL FROM ORDEM_SERVICO_REMOTO WHERE ORDEMSERVICO = @CODIGO";
                sqlCommand.Parameters.AddWithValue("@CODIGO", codigo);
                return sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected List<FbParameter> CarregarParametros(OrdemServicoRemoto obj)
        {
            List<FbParameter> parametros = new List<FbParameter>();

            FbParameter sqlpOrdemServico = new FbParameter();
            sqlpOrdemServico.ParameterName = "@ORDEMSERVICO";
            sqlpOrdemServico.Value = obj.OrdemServico.Codigo;
            parametros.Add(sqlpOrdemServico);

            FbParameter sqlpInicio = new FbParameter();
            sqlpInicio.ParameterName = "@INICIO";
            sqlpInicio.Value = obj.DataInicio;
            parametros.Add(sqlpInicio);

            FbParameter sqlpFim = new FbParameter();
            sqlpFim.ParameterName = "@FIM";
            sqlpFim.Value = obj.DataFim;
            parametros.Add(sqlpFim);

            FbParameter sqlpTotal = new FbParameter();
            sqlpTotal.ParameterName = "@TOTAL";
            sqlpTotal.Value = obj.Total;
            parametros.Add(sqlpTotal);

            return parametros;
        }

        public List<OrdemServicoRemoto> RealizarListagem(List<OrdemServicoRemoto> listaOSRemoto)
        {
            for (int i = 0; i < listaOSRemoto.Count - 1; i++)
            {
                FbDataReader leitor = this.ExecutarLeitura(listaOSRemoto[i].OrdemServico.Codigo);

                int indexInicioOsRemota = leitor.GetOrdinal("INICIO");
                int indexFimOsRemota = leitor.GetOrdinal("FIM");
                int indextTotalOsRemota = leitor.GetOrdinal("TOTAL");

                while (leitor.Read())
                {
                    listaOSRemoto[i].DataInicio = leitor.GetDateTime(indexInicioOsRemota);
                    listaOSRemoto[i].DataFim = leitor.GetDateTime(indexFimOsRemota);
                    listaOSRemoto[i].Total = leitor.GetString(indextTotalOsRemota);
                }

                leitor.Close();
            }

            return listaOSRemoto;
        }

        public OrdemServicoRemoto RealizarConsulta(OrdemServicoRemoto OSRemoto)
        {
            FbDataReader leitor = this.ExecutarLeitura(OSRemoto.OrdemServico.Codigo);

            int indexInicioOsRemota = leitor.GetOrdinal("INICIO");
            int indexFimOsRemota = leitor.GetOrdinal("FIM");
            int indextTotalOsRemota = leitor.GetOrdinal("TOTAL");

            while (leitor.Read())
            {
                OSRemoto.DataInicio = leitor.GetDateTime(indexInicioOsRemota);
                OSRemoto.DataFim = leitor.GetDateTime(indexFimOsRemota);
                OSRemoto.Total = leitor.GetString(indextTotalOsRemota);
            }

            leitor.Close();

            return OSRemoto;
        }

    }
}
