using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GideonMarket.Web.Client.Application
{
    public class AppService : IAppService
    {
        private readonly HttpClient _client;
        private readonly TokenService _token;

        public AppService(HttpClient client, TokenService token)
        {
            _client = client;
            _token = token;
        }
        //---  Get generic ---
        async Task<string> SetToken()
        {
            string TokenStr = await _token.GetToken();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TokenStr);
            return TokenStr;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            if (string.IsNullOrEmpty(await SetToken())) return default(T);
            return await _client.GetFromJsonAsync<T>((uri.StartsWith("/") == true ? "":"/") + $"{uri}");
        }
        public async Task UpdateAsync<T>(T obj, int id, string uri)
        {
            if (string.IsNullOrEmpty(await SetToken())) return;
            await _client.PutAsJsonAsync<T>((uri.StartsWith("/") == true ? "" : "/") + $"{uri}", obj);
        }
        public async Task<int> InsertAsync<T>(T obj, string url)
        {
            if (string.IsNullOrEmpty(await SetToken())) return 0;
            var responce = await _client.PostAsJsonAsync<T>((url.StartsWith("/") == true ? "" : "/") + $"{url}", obj);
            return await responce.Content.ReadFromJsonAsync<int>();
        }
        public async Task DeleteAsync(int Id, string url)
        {
            if (string.IsNullOrEmpty(await SetToken())) return;
            var response = await _client.DeleteAsync((url.StartsWith("/") == true ? "" : "/") + $"{url}");
            response.EnsureSuccessStatusCode();
        }
        public async Task<T> GetByIdAsync<T>(int id, string uri)
        {
            if (string.IsNullOrEmpty(await SetToken())) return default(T);
            return await _client.GetFromJsonAsync<T>((uri.StartsWith("/") == true ? "" : "/") + $"{uri}/{id}");
        }


        public async Task<T> PostAsync<T>(object obj, string url)
        {
            if (string.IsNullOrEmpty(await SetToken())) return default(T);
            var responce = await _client.PostAsJsonAsync((url.StartsWith("/") == true ? "" : "/") + $"{url}", obj);
            return await responce.Content.ReadFromJsonAsync<T>();
        }


        public async Task<HttpResponseMessage> CallAsync(string uri)
        {
            await SetToken();
            return await _client.GetAsync((uri.StartsWith("/") == true ? "" : "/") + $"{uri}");
        }
    }
}
