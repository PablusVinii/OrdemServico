using FastReport.Web;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRS.Apoio
{
    public class Relatorio
    {
        public static WebReport GerarRelatorioOS(int id, string caminho, DataTable dados)
        {
            WebReport relatorio = new WebReport();
            DataSet connection = new DataSet();
            connection.DataSetName = "Connection";
            dados.TableName = "MinhaConsulta";
            connection.Tables.Add(dados);
            relatorio.Report.RegisterData(connection);
            relatorio.Report.SetParameterValue("parametro", id);
            relatorio.ReportFile = caminho;
            return relatorio;
        }

        public static WebReport GerarRelatorioConsultaDeHorasConsumidasOS(string caminho, DataTable dados)
        {
            WebReport relatorio = new WebReport();
            DataSet connection = new DataSet();
            connection.DataSetName = "Connection";
            dados.TableName = "MinhaQuery";
            connection.Tables.Add(dados);
            relatorio.Report.RegisterData(connection);
            relatorio.ReportFile = caminho;
            return relatorio;
        }

        public static WebReport GerarRelatorioListagemOS(string caminho, DataTable dados, IEnumerable<FbParameter> parametros)
        {
            WebReport relatorio = new WebReport();
            DataSet connection = new DataSet();
            connection.DataSetName = "Connection";
            dados.TableName = "Query";
            connection.Tables.Add(dados);
            relatorio.Report.RegisterData(connection);

            foreach (var par in parametros)
            {
                if (par != null)
                {
                    relatorio.Report.SetParameterValue(par.ParameterName.Substring(1, par.ParameterName.Length - 1), par.Value);
                }
            }

            relatorio.ReportFile = caminho;
            return relatorio;
        }

        public static WebReport GerarRelatorioMetas(string caminho, DataTable dados)
        {
            WebReport relatorio = new WebReport();
            DataSet connection = new DataSet();
            connection.DataSetName = "Connection";
            dados.TableName = "MinhaQuery";
            connection.Tables.Add(dados); 
            relatorio.Report.RegisterData(connection);
            relatorio.ReportFile = caminho;
            return relatorio;
        }
    }
}
