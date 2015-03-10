using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;

namespace Negocio
{
    public interface IOrdemServicoNegocio:INegocio<OrdemServico,int>
    {
        List<OrdemServico> Listar(string idFuncionario);
        List<OrdemServico> Pesquisar(OrdemServico os);
        bool VerificaPrazoEdicao(OrdemServico os, int diasLimite);
        int UltimoId();
    }

    public interface IOrdemServicoRemotoNegocio : INegocio<OrdemServicoRemoto, int>
    {
        List<OrdemServicoRemoto> Listar(string idFuncionario);
        List<OrdemServicoRemoto> Pesquisar(OrdemServicoRemoto os);
        bool VerificaPrazoEdicao(OrdemServicoRemoto os, int diasLimite);
    }
}
