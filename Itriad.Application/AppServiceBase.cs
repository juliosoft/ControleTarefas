using Itriad.Application.Interfaces;
using Itriad.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace Itriad.Application
{
    public class AppServiceBase<Tentity> : IDisposable, IAppServiceBase<Tentity> where Tentity : class
    {
        private readonly IServiceBaseDomain<Tentity> _serviceBase;

        public AppServiceBase(IServiceBaseDomain<Tentity> serviceBase)
        {
            _serviceBase = serviceBase;       
        }
        public void Add(Tentity obj)
        {
            _serviceBase.Add(obj);
        }

        public IEnumerable<Tentity> GetAll()
        {
            try
            {
                return _serviceBase.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Tentity> GetAllAsNoTrack()
        {
            return _serviceBase.GetAllAsNoTrack();
        }

        public Tentity GetById(int id)
        {
            return _serviceBase.GetById(id);
        }

        public void Remove(Tentity obj)
        {
            _serviceBase.Remove(obj);
        }

        public void Update(Tentity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }

        public void Save()
        {
            try
            {
                _serviceBase.Save();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
