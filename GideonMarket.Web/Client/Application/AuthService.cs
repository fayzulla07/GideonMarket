using GideonMarket.Web.Client.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace GideonMarket.Web.Client.Application
{
    public class AuthService
    {
        private readonly HttpClient _client;


        public AuthService(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserResponse> LoginUserAsync(LoginViewModel user)
        {
            UserResponse result = null;
            var responce = await _client.PostAsJsonAsync<LoginViewModel>("/api/auth/login", user);
            await responce.MyEnsureSuccessStatusCode();
            result = await responce.Content.ReadFromJsonAsync<UserResponse>();
            result.RememberMe = user.RememberMe;
            return result;
        }


    }
}
