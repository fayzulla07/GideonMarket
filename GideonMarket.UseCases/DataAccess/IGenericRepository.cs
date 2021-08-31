using GideonMarket.Entities.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GideonMarket.UseCases.DataAccess
{
    public interface IGenericRepository
    {
        Task AddAsync<T>(List<T> entity) where T : Entity;
        Task AddAsync<T>(T entity) where T : Entity;
        void AddOrUpdate<T>(T entity) where T : Entity;
        Task DeleteAsync<T>(int id) where T : Entity;
        Task DeleteAsync<T>(int[] ids) where T : Entity;
        Task<T> FindById<T>(int id) where T : Entity;
        Task<List<T>> GetAsync<T>() where T : Entity;
        Task<int> SaveAsync();
        void Update<T>(List<T> entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
    }
}