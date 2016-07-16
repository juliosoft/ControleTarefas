using Itriad.Domain.Interfaces.Repositories;
using Microsoft.Practices.ServiceLocation;
using System;

namespace Itriad.Infra.Data.Context
{
    /// <summary>
    /// Classe responsável por gerenciar as transações da aplicação
    /// Install-Package CommonServiceLocator
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        private ItriadContexto _contexto;

        /// <summary>
        /// Inicia uma nova transação.
        /// Recupera a conexão ativa através do serviceLocator, ContextManager.
        /// </summary>
        public void BeginTransaction()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager>();
            _contexto = contextManager.Contexto;
        }
        /// <summary>
        /// Comita todas as alterações realizadas nos objetos na corrente transação
        /// </summary>
        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_contexto != null)
                {
                    _contexto.Dispose();
                }
            }
        }

        /// <summary>
        /// Desfaz todas as alterações realizadas devido algum erro 
        /// </summary>
        public void RollBack()
        {
            //_contexto.Database.ro .CurrentTransaction.Rollback();
        }
    }
}
