﻿using System.Net.Http;
using System.Threading.Tasks;

namespace GideonMarket.Web.Client.Application
{
    public interface IAppService
    {
        Task<T> GetAsync<T>(string uri);
        Task UpdateAsync<T>(T obj, int id, string uri);
        Task<int> InsertAsync<T>(T obj, string url);
        Task DeleteAsync(int Id, string url);
        Task<T> GetByIdAsync<T>(int id, string uri);

        Task<T> PostAsync<T>(object obj, string url);

        Task<HttpResponseMessage> CallAsync(string uri);
    }
}