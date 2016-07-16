using System;
using System.Collections;
using System.Collections.Generic;
using Itriad.Domain.Entities;
using Itriad.Domain.Interfaces.Repositories;
using Itriad.Infra.Data.Context;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Practices.ServiceLocation;

namespace Itriad.Infra.Data.Repositories
{
    /// <summary>
    /// install-package dapper
    /// Dapper = ferramenta que converse resultado de uma query em lista tipada.
    /// Repositório de clientes
    /// </summary>
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {        
        /// <summary>
        /// Obter usando dapper
        /// </summary>
        /// <param name="dapper"></param>
        /// <returns></returns>
        public IEnumerable<Cliente> Obter(bool dapper = false)
        {
            var conStr = ServiceLocator.Current.GetInstance<ContextManager>().Contexto.Database.Connection.ConnectionString;
            _dbConnection = new SqlConnection(conStr);

            IEnumerable<Cliente> result = new List<Cliente>();
            result = _dbConnection.Query<Cliente>(@" SELECT [ClienteIdx]
                                              ,[Nome]
                                              ,[SobreNome]
                                              ,[Email]
                                              ,[DataCadastro]
                                              ,[Ativo]
                                              ,[DataAtualizacao]
                                              ,[UsuarioCadastro]
                                              ,[UsuarioAtualizacao]
                                          FROM [Cliente]").AsList();
            
            return result;
        }

    }
}
