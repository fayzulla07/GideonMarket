using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GideonMarket.Web.Client.Application
{
    public static class CustomHttpClientJsonExtensions
    {
        public static async Task MyEnsureSuccessStatusCode(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.Content != null)
                    response.Content.Dispose();

                throw new SimpleHttpResponseException(response.StatusCode, content);
            }
        }
    }
}
