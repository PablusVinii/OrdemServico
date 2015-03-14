using Murta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Murta.Ordemservico.Wcf
{
    [ServiceContract]
    public interface IOrdemServicoFacade
    {
        [OperationContract]
        List<Dto.OrdemServico> Listar();

        [OperationContract]
        List<Murta.Dto.OrdemServico> BuscarPorPeriodo(DateTime de, DateTime ate, Funcionario funcionario, Cliente cliente);

        [OperationContract]
        void Cadastrar(Dto.OrdemServico ordemServico);

        [OperationContract]
        void CadastrarLote(List<Dto.OrdemServico> ordensServico);

        [OperationContract]
        void Editar(Dto.OrdemServico ordemServico);

        [OperationContract]
        void Excluir(Dto.OrdemServico ordemServico);

        [OperationContract]
        void ExcluirLote(List<Dto.OrdemServico> ordensServico);
    }
}
