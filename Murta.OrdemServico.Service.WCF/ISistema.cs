using Murta.Dto;
using Murta.OrdemServico.Dto;
using Murta.OrdemServico.Service.WCF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Murta.OrdemServico.Service.WCF
{
    [ServiceContract]
    public interface ISistema
    {
        [OperationContract]
        void CadastrarOrdemServico(Murta.OrdemServico.Dto.OS ordemServico);

        [OperationContract]
        void EditarOrdemServico(Murta.OrdemServico.Dto.OS ordemServico);

        [OperationContract]
        void ExcluirOrdemServico(Murta.OrdemServico.Dto.OS ordemServico);

        [OperationContract]
        Murta.OrdemServico.Dto.OS ConsultarOrdemServico(int id);
        
        [OperationContract]
        List<Murta.OrdemServico.Dto.OS> ListarOrdemServico();

        [OperationContract(Name = "ListarPorRangeDataOrdemServico")]
        List<Murta.OrdemServico.Dto.OS> ListarOrdemServico(DateTime dataDe, DateTime dataAte);

        [OperationContract(Name = "ListarPorRangedeDataeFuncionarioOrdemServico")]
        List<Murta.OrdemServico.Dto.OS> ListarOrdemServico(DateTime dataDe, DateTime dataAte, Funcionario funcionario);

        [OperationContract(Name = "ListarPorRangedeDataeClienteOrdemServico")]
        List<Murta.OrdemServico.Dto.OS> ListarOrdemServico(DateTime dataDe, DateTime dataAte, Cliente cliente);

        [OperationContract(Name = "ListarPorRangedeDataeFuncionarioeClienteOrdemServico")]
        List<Murta.OrdemServico.Dto.OS> ListarOrdemServico(DateTime dataDe, DateTime dataAte, Cliente cliente, Funcionario funcionario);

        [OperationContract(Name = "ListarPorDataeFuncionarioOrdemServico")]
        List<Murta.OrdemServico.Dto.OS> ListarOrdemServico(DateTime data, Funcionario funcionario, TipoData tipo);

        [OperationContract(Name = "ListarPorDataeClienteOrdemServico")]
        List<Murta.OrdemServico.Dto.OS> ListarOrdemServico(DateTime data, Cliente cliente, TipoData tipo);

        [OperationContract(Name = "ListarPorDataeFuncionarioeClienteOrdemServico")]
        List<Murta.OrdemServico.Dto.OS> ListarOrdemServico(DateTime data, Funcionario funcionario, Cliente cliente);

        [OperationContract(Name = "ListarPorDataOrdemServico")]
        List<Murta.OrdemServico.Dto.OS> ListarOrdemServico(DateTime data, TipoData tipo);

        [OperationContract(Name = "ListarPorFuncionarioeClienteOrdemServico")]
        List<Murta.OrdemServico.Dto.OS> ListarOrdemServico(Funcionario funcionario, Cliente cliente);

        [OperationContract(Name = "ListarPorFuncionarioOrdemServico")]
        List<Murta.OrdemServico.Dto.OS> ListarOrdemServico(Funcionario funcionario);

        [OperationContract(Name = "ListarPorClienteOrdemServico")]
        List<Murta.OrdemServico.Dto.OS> ListarOrdemServico(Cliente cliente);

        [OperationContract]
        List<Cliente> ListarClientes();

        [OperationContract]
        List<Projeto> ListarProjetos();

        [OperationContract]
        List<TipoHora> ListarTiposHora();

        [OperationContract]
        List<Funcionario> ListarFuncionarios();

        [OperationContract]
        List<Status> ListarStatus();

        [OperationContract]
        Usuario Login(string usuario, string senha);
    }
}
