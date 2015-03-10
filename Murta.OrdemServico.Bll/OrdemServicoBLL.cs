using Murta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Bll
{
    public class OrdemServicoBLL
    {
        public List<Murta.Dto.OrdemServico> Listar()
        {
            // TODO Listar ordens de serviços
            throw new NotImplementedException();
        }

        public List<Murta.Dto.OrdemServico> BuscarPorPeriodo(DateTime de, DateTime ate)
        {
            // TODO Buscar por data
            throw new NotImplementedException();
        }

        public List<Murta.Dto.OrdemServico> BuscarPorPeriodo(DateTime de, DateTime ate, Funcionario funcionario)
        {
            // TODO Buscar por data e funcionario
            throw new NotImplementedException();
        }

        public List<Murta.Dto.OrdemServico> BuscarPorPeriodo(DateTime de, DateTime ate, Cliente cliente)
        {
            // TODO Buscar por data e cliente
            throw new NotImplementedException();
        }

        public List<Murta.Dto.OrdemServico> BuscarPorPeriodo(DateTime de, DateTime ate, Funcionario funcionario, Cliente cliente)
        {
            // TODO Buscar por data, cliente e funcionario
            throw new NotImplementedException();
        }

        public void Cadastrar(Murta.Dto.OrdemServico ordemServico)
        {
            // TODO Insere uma nova ordem de servico
            throw new NotImplementedException();
        }

        public void CadastrarLote(List<Murta.Dto.OrdemServico> ordensServico)
        {
            // TODO Cadastra um lote de ordens de servico
            throw new NotImplementedException();
        }

        public void Editar(Murta.Dto.OrdemServico ordemServico)
        {
            // TODO Edita uma ordem de servico
            throw new NotImplementedException();
        }

        public void Excluir(Murta.Dto.OrdemServico ordemServico)
        {
            // TODO Exclui uma ordem de servico
            throw new NotImplementedException();
        }

        public void ExcluirLote(List<Murta.Dto.OrdemServico> ordensServico)
        {
            // TODO Exclui um lote de ordens de servico
            throw new NotImplementedException();
        }
    }
}
