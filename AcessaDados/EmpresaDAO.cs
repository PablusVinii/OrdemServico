using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;

namespace AcessaDados
{
    public class EmpresaDAO:IRepositorio<Empresa,string>
    {
        FbConnection _conexao = null;

        public EmpresaDAO(FbConnection conn)
        {
            this._conexao = conn;

            if (this._conexao.State == ConnectionState.Closed)
            {
                this._conexao.Open();
            }
        }

        public void Cadastrar(Empresa obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(Empresa obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Empresa obj)
        {
            throw new NotImplementedException();
        }

        public List<Empresa> Listar(string empresa, string filial)
        {
            FbCommand sqlCommand = new FbCommand();
            
            try
            {
                sqlCommand.Connection = this._conexao;

                if (empresa != "**")
                {
                    sqlCommand.CommandText = "SELECT EMPRESA, REDUZIDO FROM SYS_COMPANY WHERE EMPRESA = @EMPRESA";
                    sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);  
                }
                else
                {
                    sqlCommand.CommandText = "SELECT EMPRESA, REDUZIDO FROM SYS_COMPANY";
                }

                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;
                DataTable dtEmpresa = new DataTable();
                sqlAdapter.Fill(dtEmpresa);
                return ConverteDataTableParaLista(dtEmpresa).ToList();
            }
            catch(FbException ex)
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

        public List<Empresa> Pesquisar(string empresa, string filial, string id)
        {
            throw new NotImplementedException();
        }

        public Empresa Consultar(string empresa, string filia, string id)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Empresa> ConverteDataTableParaLista(DataTable dt)
        {
            int indexReduzido = dt.Columns["REDUZIDO"].Ordinal;
            int indexEmpresa = dt.Columns["EMPRESA"].Ordinal;

            foreach (DataRow linha in dt.Rows)
            {
                Empresa umaEmpresa = new Empresa();
                umaEmpresa.Codigo = linha[indexEmpresa].ToString();
                umaEmpresa.Nome = linha[indexReduzido].ToString();
                yield return umaEmpresa;
            }
        }
    }
}
