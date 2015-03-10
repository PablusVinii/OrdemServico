using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;

namespace AcessaDados
{
    public class FilialDAO:IRepositorio<Filial, string>
    {
        FbConnection _conexao = null;

        public FilialDAO(FbConnection conn)
        {
            this._conexao = conn;

            if (this._conexao.State == ConnectionState.Closed)
            {
                this._conexao.Open();
            }
        }

        public void Cadastrar(Filial obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(Filial obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Filial obj)
        {
            throw new NotImplementedException();
        }

        public List<Filial> Listar(string empresa, string filial)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.CommandText = "SELECT FILIAL, REDUZIDO FROM SYS_BRANCH WHERE EMPRESA = @EMPRESA";
                sqlCommand.Parameters.AddWithValue("@EMPRESA", empresa);
                sqlCommand.Connection = this._conexao;
                FbDataAdapter sqlAdapater = new FbDataAdapter();
                sqlAdapater.SelectCommand = sqlCommand;
                DataTable dtFilial = new DataTable();
                sqlAdapater.Fill(dtFilial);
                return ConverteDataTableEmList(dtFilial).ToList();
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
                this._conexao.Close();
            }
        }

        public List<Filial> Pesquisar(string empresa, string filial, string id)
        {
            throw new NotImplementedException();
        }

        public Filial Consultar(string empresa, string filia, string id)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Filial> ConverteDataTableEmList(DataTable dt)
        {
            int indexFilial = dt.Columns["FILIAL"].Ordinal;
            int indexReduzido = dt.Columns["REDUZIDO"].Ordinal;

            foreach (DataRow linha in dt.Rows)
            {
                Filial umaFilial = new Filial();
                umaFilial.Codigo = linha[indexFilial].ToString();
                umaFilial.Nome = linha[indexReduzido].ToString();
                yield return umaFilial;
            }
        }
    }
}
