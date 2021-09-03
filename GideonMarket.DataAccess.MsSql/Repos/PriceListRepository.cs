using GideonMarket.Entities.Models;
using GideonMarket.Entities.Shared;
using GideonMarket.UseCases.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GideonMarket.DataAccess.MsSql.Repos
{
    public class PriceListRepository : IGenericRepository
    {
        public Task AddAsync<T>(List<T> entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task AddAsync<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void AddOrUpdate<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync<T>(int[] ids) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task<T> FindById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAsync<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(List<T> entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
