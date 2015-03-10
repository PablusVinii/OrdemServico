using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferenciaObjetos;
using TransferenciaObjetos.Autenticacao;
using TransferenciaObjetos.Pessoas;

// ********************************************************************* 
//
// TRS Sistemas - Runtime Library Functions }
//
// Copyright(c) 2006-2014 TRS Sistemas e Soluções em Informática Ltda. 
//
// Author: Júlio César Souza Murta
// Data: 14/05/2014
// ********************************************************************* 
// Entidade Usuario 
//
// ********************************************************************* 
// Data última alteração: 
// Últimas alterações: 
//
// ********************************************************************* 

namespace AcessaDados
{
    public class UsuarioDAO : IUsuarioRepositorio
    {
        protected FbConnection _conexao = null;

        public UsuarioDAO(FbConnection conn)
        {
            this._conexao = conn;

            if (this._conexao.State == ConnectionState.Closed)
            {
                this._conexao.Open();
            }
        }

        public void Cadastrar(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Editar(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public void AlterarSenha(Usuario obj)
        {

            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "UPDATE SYS_USERS SET USUARIOWEB = @USUARIO, SENHAWEB = @SENHA WHERE CODIGO  = @CODIGO";
                sqlCommand.Parameters.AddWithValue("@USUARIO", obj.NomeUsuario);
                sqlCommand.Parameters.AddWithValue("@SENHA", obj.Senha);
                sqlCommand.Parameters.AddWithValue("@CODIGO", obj.Codigo);
                sqlCommand.ExecuteNonQuery();
            }
            catch (FbException ex)
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

        public List<Usuario> Listar(string empresa, string filial)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> Pesquisar(string empresa, string filial, string id)
        {
            throw new NotImplementedException();
        }

        public Usuario Consultar(string empresa, string filial, string id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string nomeUsuario, string senha)
        {
            FbCommand sqlCommand = new FbCommand();

            try
            {
                sqlCommand.Connection = this._conexao;
                sqlCommand.CommandText = "SELECT SYS_USERS.CODIGO, SYS_USERS.USUARIOWEB, SYS_USERS.SENHAWEB, SYS_USERS.TIPO, SYS_COMPANY.EMPRESA, SYS_BRANCH.FILIAL," +
                                         "FUNCIONARIOS.REDUZIDO, FUNCIONARIOS.CODIGO AS CODFUNCIONARIO " +
                                         "FROM SYS_USERS INNER JOIN FUNCIONARIOS ON SYS_USERS.CODIGO = FUNCIONARIOS.USUARIO " +
                                         "LEFT JOIN SYS_COMPANY ON SYS_COMPANY.EMPRESA = FUNCIONARIOS.EMPRESA " +
                                         "LEFT JOIN SYS_BRANCH ON SYS_BRANCH.FILIAL = FUNCIONARIOS.FILIAL " +
                                         "WHERE SYS_USERS.USUARIOWEB = @USUARIO AND SYS_USERS.SENHAWEB = @SENHA";

                sqlCommand.Parameters.AddWithValue("@USUARIO", nomeUsuario);
                sqlCommand.Parameters.AddWithValue("@SENHA", senha);

                FbDataReader sqlReader = sqlCommand.ExecuteReader();

                Usuario umUsuario = null;

                while (sqlReader.Read())
                {

                    int indexCodigo = sqlReader.GetOrdinal("CODIGO");
                    int indexFuncionario = sqlReader.GetOrdinal("CODFUNCIONARIO");
                    int indexUsuario = sqlReader.GetOrdinal("USUARIOWEB");
                    int indexSenha = sqlReader.GetOrdinal("SENHAWEB");
                    int indexEmpresa = sqlReader.GetOrdinal("EMPRESA");
                    int indexFilial = sqlReader.GetOrdinal("FILIAL");
                    int indexReduzido = sqlReader.GetOrdinal("REDUZIDO");
                    int indexTipoUsuario = sqlReader.GetOrdinal("TIPO");

                    umUsuario = new Usuario();
                    umUsuario.Codigo = sqlReader.GetInt32(indexCodigo).ToString();
                    umUsuario.NomeUsuario = sqlReader.GetString(indexUsuario);
                    umUsuario.Senha = sqlReader.GetString(indexSenha);
                    umUsuario.Funcionario = new Funcionario();
                    umUsuario.Funcionario.Codigo = sqlReader.GetInt32(indexFuncionario);
                    umUsuario.Funcionario.Reduzido = sqlReader.GetString(indexReduzido);
                    umUsuario.Funcionario.Empresa = new Empresa();
                    umUsuario.Funcionario.Empresa.Codigo = sqlReader.GetString(indexEmpresa) != string.Empty ? sqlReader.GetString(indexEmpresa) : "**";
                    umUsuario.Funcionario.Filial = new Filial();
                    umUsuario.Funcionario.Filial.Codigo = sqlReader.GetString(indexFilial) != string.Empty ? sqlReader.GetString(indexFilial) : "**";
                    umUsuario.IsAdministrador = !Convert.ToBoolean(Convert.ToInt32(sqlReader.GetString(indexTipoUsuario)));
                }

                return umUsuario;
            }
            catch (FbException ex)
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
    }
}
