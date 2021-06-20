using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GideonMarket.Web.Client.Application
{
    public class TokenService
    {
        private readonly NavigationManager _manager;
        private readonly LocalStorageAuthProvider _provider;

        public TokenService(NavigationManager manager, AuthenticationStateProvider provider)
        {
            _manager = manager;
            _provider = provider as LocalStorageAuthProvider;
        }
        public async Task<string> GetToken()
        {
            return await Task.FromResult("wegqgewg43gwag");
            if (_provider.CurrentUser == null)
                return null;
            var CurrentUser = _provider.CurrentUser;
            if (CurrentUser.User == null)
            {
                await _provider.LogoutAsync();
                _manager.NavigateTo("/system/login");
                return null;
            }
            if (DateTime.Parse(CurrentUser.User.FindFirst("Expired").Value) < DateTime.Now)
            {
                await _provider.LogoutAsync();
                _manager.NavigateTo("/system/login");
                return null;
            }
            else
            {
                return CurrentUser.User.FindFirst("AccessToken").Value;
            }
        }
    }
}
