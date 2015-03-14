using Bll = Murta.OrdemServico.Bll;
using Dto = Murta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Murta.Ordemservico.Wcf
{
    public class OrdemServicoFacade : IOrdemServicoFacade
    {
        Bll.OrdemServicoBLL ordemServicoBLL = new Bll.OrdemServicoBLL();

        public List<Dto.OrdemServico> Listar()
        {
            return this.ordemServicoBLL.Listar();
        }

        public List<Dto.OrdemServico> BuscarPorPeriodo(DateTime de, DateTime ate, Dto.Funcionario funcionario, Dto.Cliente cliente)
        {
            if ((funcionario == null) && (cliente == null))
                return this.ordemServicoBLL.BuscarPorPeriodo(de, ate);

            if ((funcionario != null) && (cliente != null))
                return this.ordemServicoBLL.BuscarPorPeriodo(de, ate, funcionario, cliente);

            if (cliente == null)
                return this.ordemServicoBLL.BuscarPorPeriodo(de, ate, funcionario);

            if (funcionario == null)
                return this.ordemServicoBLL.BuscarPorPeriodo(de, ate, cliente);

            throw new Exception("Método overload não identificado");
        }

        public void Cadastrar(Dto.OrdemServico ordemServico)
        {
            this.ordemServicoBLL.Cadastrar(ordemServico);
        }

        public void CadastrarLote(List<Dto.OrdemServico> ordensServico)
        {
            this.ordemServicoBLL.CadastrarLote(ordensServico);
        }

        public void Editar(Dto.OrdemServico ordemServico)
        {
            this.ordemServicoBLL.Editar(ordemServico);
        }

        public void Excluir(Dto.OrdemServico ordemServico)
        {
            this.ordemServicoBLL.Excluir(ordemServico);
        }

        public void ExcluirLote(List<Dto.OrdemServico> ordensServico)
        {
            this.ordemServicoBLL.ExcluirLote(ordensServico);
        }
    }
}
