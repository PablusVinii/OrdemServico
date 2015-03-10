using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;
using TransferenciaObjetos.Pessoas;

namespace AcessaDados
{
    public class ClienteDAO:IRepositorio<Cliente, int>
    {
        FbConnection _conexao = null;

        public ClienteDAO(FbConnection conn)
        {
            this._conexao = conn;

            if (this._conexao.State == ConnectionState.Closed)
            {
                this._conexao.Open();
            }
        }

        public void Cadastrar(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Cliente obj)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> Listar(string empresa, string filial)
        {
           FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT CLIENTES.CODIGO, CLIENTES.REDUZIDO, CLIENTES.UF, CLIENTES.MUNICIPIO, "+
                                         "CLIENTES.BAIRRO, CLIENTES.ENDERECO, CLIENTES.DDD, CLIENTES.TELEFONE FROM CLIENTES " +
                                         "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = CLIENTES.CODIGO "+
                                         "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = CLIENTES.FILIAL "+
                                         "ORDER BY CLIENTES.REDUZIDO ASC";

                FbDataAdapter sqlAdapter = new FbDataAdapter();
                sqlAdapter.SelectCommand = sqlCommand;
                DataTable dtCliente = new DataTable();
                sqlAdapter.Fill(dtCliente);
                return this.ConverteDataTableEmList(dtCliente).ToList();
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

        public List<Cliente> Pesquisar(string empresa, string filial, int id)
        {
            throw new NotImplementedException();
        }

        public Cliente Consultar(string empresa, string filial, int id)
        {
            throw new NotImplementedException();
        }

         protected IEnumerable<Cliente> ConverteDataTableEmList(DataTable dt)
        {
            int indexCodigo =  dt.Columns["CODIGO"].Ordinal;
            int indexNome = dt.Columns["REDUZIDO"].Ordinal;
            int indexEstado = dt.Columns["UF"].Ordinal;
            int indexMunicipio = dt.Columns["MUNICIPIO"].Ordinal;
            int indexBairro = dt.Columns["BAIRRO"].Ordinal;
            int indexEndereco = dt.Columns["ENDERECO"].Ordinal;
            int indexDDD = dt.Columns["DDD"].Ordinal;
            int indexTelefone = dt.Columns["TELEFONE"].Ordinal;

            foreach (DataRow linha in dt.Rows)
            {
                Cliente umCliente = new Cliente();
                umCliente.Codigo = Convert.ToInt32(linha[indexCodigo].ToString());
                umCliente.Nome = linha[indexNome].ToString();
                umCliente.Endereco = new Endereco();
                umCliente.Telefone = new Telefone();
                yield return umCliente;
            }
        }
    }
}
