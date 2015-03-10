using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;

namespace AcessaDados
{
    public interface IOrdemServicoRepositorio:IRepositorio<OrdemServico,int>
    {
        List<OrdemServico> Listar(string empresa, string filial, string idFuncionario);
        List<OrdemServico> Pesquisar(string empresa, string filial, OrdemServico os);
        DataTable GerarRelatorio(string query, IEnumerable<FbParameter> parametros);
        void AcrescentarNaMeta(int ano, int mes, int meta, int funcionario, int indicador, double totalHoras = 0);
        void DecrementarNaMeta(int ano, int mes, int meta, int funcionario, int indicador, double totalHoras = 0);
        int UltimoId();
    }

    public interface IOrdemServicoRemotoRepositorio
    {
        void Cadastrar(OrdemServicoRemoto obj);
        void Editar(OrdemServicoRemoto obj);
        void Excluir(OrdemServicoRemoto obj);
        OrdemServicoRemoto RealizarConsulta(OrdemServicoRemoto OSRemoto);
        List<OrdemServicoRemoto> RealizarListagem(List<OrdemServicoRemoto> listaOSRemoto);
    }
}
