using Murta.Utils.Dal.Exceptions;
using Murta.OrdemServico.Dal.Interfaces;
using Murta.QueryFactory;
using Murta.QueryFactory.Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Murta.OrdemServico.Dal.Repositories
{
    public class OrdemServicoRepository : IOrdemServicoRepository
    {
        protected Repository repository = null;

        public OrdemServicoRepository(DbConnection db)
        {
            this.repository = new Repository(db);
        }

        public List<Murta.OrdemServico.Dto.OS> Listar()
        {
            var resultado = this.repository.Query<Murta.OrdemServico.Dto.OS>(Databaseoperation.Select);
            return resultado.Mapper<Murta.OrdemServico.Dto.OS>().ToList();
        }

        public Murta.OrdemServico.Dto.OS Consultar(int id)
        {
            var resultado = this.repository.Query<Murta.OrdemServico.Dto.OS>(Databaseoperation.Filter, (List<string> nomesParametros) =>
            {
                KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomesParametros[0], id);
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(idParametro);
                return parametros;
            });
            return resultado.Mapper<Murta.OrdemServico.Dto.OS>().FirstOrDefault();
        }

        public void Cadastrar(Murta.OrdemServico.Dto.OS objeto)
        {
            this.repository.Execute<Murta.OrdemServico.Dto.OS>(Databaseoperation.Insert, (List<string> nomesParametro) =>
                {
                    KeyValuePair<string, object> dataParametro = new KeyValuePair<string, object>(nomesParametro[0], objeto.Data);
                    KeyValuePair<string, object> inicioParametro = new KeyValuePair<string, object>(nomesParametro[1], objeto.Inicio);
                    KeyValuePair<string, object> fimParametro = new KeyValuePair<string, object>(nomesParametro[2], objeto.Fim);
                    KeyValuePair<string, object> trasladoParametro = new KeyValuePair<string, object>(nomesParametro[3], objeto.Traslado);
                    KeyValuePair<string, object> atividadeParametro = new KeyValuePair<string, object>(nomesParametro[4], objeto.Atividade);
                    KeyValuePair<string, object> observacaoParametro = new KeyValuePair<string, object>(nomesParametro[5], objeto.Observacao);
                    KeyValuePair<string, object> faturadoParametro = new KeyValuePair<string, object>(nomesParametro[6], objeto.Faturado);
                    KeyValuePair<string, object> statusParametro = new KeyValuePair<string, object>(nomesParametro[7], objeto.Status.Codigo);
                    KeyValuePair<string, object> projetoParametro = new KeyValuePair<string, object>(nomesParametro[8], objeto.Projeto.Codigo);
                    KeyValuePair<string, object> tipoHoraParametro = new KeyValuePair<string, object>(nomesParametro[9], objeto.TipoHora.Codigo);
                    KeyValuePair<string, object> empresaParametro = new KeyValuePair<string, object>(nomesParametro[10], objeto.Empresa.Codigo);
                    KeyValuePair<string, object> filialParametro = new KeyValuePair<string, object>(nomesParametro[11], objeto.Filial.Codigo);
                    KeyValuePair<string, object> clienteParametro = new KeyValuePair<string, object>(nomesParametro[12], objeto.Cliente.Codigo);
                    KeyValuePair<string, object> funcionarioParametro = new KeyValuePair<string, object>(nomesParametro[13], objeto.Funcionario.Codigo);                    

                    IDictionary<string, object> parametros = new Dictionary<string, object>();
                    parametros.Add(dataParametro);
                    parametros.Add(inicioParametro);
                    parametros.Add(fimParametro);
                    parametros.Add(trasladoParametro);
                    parametros.Add(empresaParametro);
                    parametros.Add(filialParametro);
                    parametros.Add(clienteParametro);
                    parametros.Add(funcionarioParametro);
                    parametros.Add(projetoParametro);
                    parametros.Add(tipoHoraParametro);
                    parametros.Add(atividadeParametro);
                    parametros.Add(observacaoParametro);
                    parametros.Add(faturadoParametro);
                    parametros.Add(statusParametro);

                    return parametros;
                });
        }

        public void Editar(Murta.OrdemServico.Dto.OS objeto)
        {
            this.repository.Execute<Murta.OrdemServico.Dto.OS>(Databaseoperation.Update, (List<string> nomesParametro) =>
           {
                KeyValuePair<string, object> upDataParametro = new KeyValuePair<string, object>(nomesParametro[0], objeto.Data);
                KeyValuePair<string, object> upInicioParametro = new KeyValuePair<string, object>(nomesParametro[1], objeto.Inicio);
                KeyValuePair<string, object> upFimParametro = new KeyValuePair<string, object>(nomesParametro[2], objeto.Fim);
                KeyValuePair<string, object> upTrasladoParametro = new KeyValuePair<string, object>(nomesParametro[3], objeto.Traslado);
                KeyValuePair<string, object> upAtividadeParametro = new KeyValuePair<string, object>(nomesParametro[4], objeto.Atividade);
                KeyValuePair<string, object> upObservacaoParametro = new KeyValuePair<string, object>(nomesParametro[5], objeto.Observacao);
                KeyValuePair<string, object> upFaturadoParametro = new KeyValuePair<string, object>(nomesParametro[6], objeto.Faturado);
                KeyValuePair<string, object> upStatusParametro = new KeyValuePair<string, object>(nomesParametro[7], objeto.Status.Codigo);
                KeyValuePair<string, object> upProjetoParametro = new KeyValuePair<string, object>(nomesParametro[8], objeto.Projeto.Codigo);
                KeyValuePair<string, object> upTipoHoraParametro = new KeyValuePair<string, object>(nomesParametro[9], objeto.TipoHora.Codigo);
                KeyValuePair<string, object> upEmpresaParametro = new KeyValuePair<string, object>(nomesParametro[10], objeto.Empresa.Codigo);
                KeyValuePair<string, object> upFilialParametro = new KeyValuePair<string, object>(nomesParametro[11], objeto.Filial.Codigo);
                KeyValuePair<string, object> upClienteParametro = new KeyValuePair<string, object>(nomesParametro[12], objeto.Cliente.Codigo);
                KeyValuePair<string, object> upFuncionarioParametro = new KeyValuePair<string, object>(nomesParametro[13], objeto.Funcionario.Codigo);                    


                KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomesParametro[14], objeto.Codigo);

                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(upDataParametro);
                parametros.Add(upInicioParametro);
                parametros.Add(upFimParametro);
                parametros.Add(upTrasladoParametro);
                parametros.Add(upFaturadoParametro);
                parametros.Add(upStatusParametro);
                parametros.Add(upEmpresaParametro);
                parametros.Add(upFilialParametro);
                parametros.Add(upClienteParametro);
                parametros.Add(upFuncionarioParametro);
                parametros.Add(upProjetoParametro);
                parametros.Add(upTipoHoraParametro);
                parametros.Add(upAtividadeParametro);
                parametros.Add(upObservacaoParametro);
                parametros.Add(idParametro);

                return parametros;
            });
        }

        public void Excluir(Murta.OrdemServico.Dto.OS objeto)
        {
            this.repository.Execute<Murta.OrdemServico.Dto.OS>(Databaseoperation.Delete, (List<string> nomesParametro) =>
            {
                KeyValuePair<string, object> idParametro = new KeyValuePair<string, object>(nomesParametro[0], objeto.Codigo);
                IDictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add(idParametro);
                return parametros;
            });
        }
    }
}
