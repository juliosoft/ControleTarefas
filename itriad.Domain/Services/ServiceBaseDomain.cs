using Itriad.Domain.Interfaces.Repositories;
using Itriad.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using Microsoft.Practices.ServiceLocation;
using Itriad.Infra.CrossCutting.Common.Messages;

namespace Itriad.Domain.Services
{
    public class ServiceBaseDomain<TEntity> : IDisposable, IServiceBaseDomain<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceBaseDomain(IRepositoryBase<TEntity> repository)
        {
            _unitOfWork = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _repository = repository;
        }
        public void Add(TEntity obj)
        {
            try
            {
                BeginTransaction();
                _repository.Add(obj);

            }
            catch (Exception ex)
            {
                throw new ApplicationException(GenericMessage.Error());
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(GenericMessage.Error());
            }
        }

        public IEnumerable<TEntity> GetAllAsNoTrack()
        {
            try
            {
                return _repository.GetAllAsNoTrack();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(GenericMessage.Error());
            }
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(TEntity obj)
        {
            try
            {
                BeginTransaction();
                _repository.Remove(obj);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw new ApplicationException(GenericMessage.Error());
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                BeginTransaction();
                _repository.Update(obj);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(GenericMessage.Error());
            }
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

        public void Save()
        {
            try
            {
                _unitOfWork.Commit();
                GenericMessage.Success();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(GenericMessage.Error());
            }
        }

        public void RollBack()
        {
            _unitOfWork.RollBack();
        }

        public void BeginTransaction()
        {
            _unitOfWork.BeginTransaction();
        }
    }
}
