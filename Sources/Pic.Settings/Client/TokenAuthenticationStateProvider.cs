using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pic.Settings.Client
{
    public class TokenAuthenticationStateProvider : AuthenticationStateProvider
    {

        private static readonly string LocalStorage = "localStorage";
        private static readonly string LocalStorageSetItem = $"{LocalStorage}.setItem";
        private static readonly string LocalStorageRemoveItem = $"{LocalStorage}.removeItem";
        private static readonly string LocalStorageGetItem = $"{LocalStorage}.getItem";
        private static readonly string Token = "AuthToken";
        private static readonly string TokenExpiry = "AuthTokenExpiry";
        private readonly IJSRuntime jSRuntime;

        public TokenAuthenticationStateProvider(IJSRuntime jSRuntime) => this.jSRuntime = jSRuntime;

        public async Task SetTokenAsync(string token = null, DateTime expire = default)
        {
            if (token is null)
            {
                await jSRuntime.InvokeAsync<object>(LocalStorageRemoveItem, Token);
                await jSRuntime.InvokeAsync<object>(LocalStorageRemoveItem, TokenExpiry);
            }
            else
            {
                await jSRuntime.InvokeAsync<object>(LocalStorageSetItem, Token, token);
                await jSRuntime.InvokeAsync<object>(LocalStorageSetItem, TokenExpiry, expire);
            }

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }


        public async Task<string> GetTokenAsync()
        {
            var expiry = await jSRuntime.InvokeAsync<object>(LocalStorageGetItem, TokenExpiry);
            if (expiry is object)
            {
                if (DateTime.Parse(expiry.ToString()) > DateTime.Now)
                {
                    return await jSRuntime.InvokeAsync<string>(LocalStorageGetItem, Token);
                }
                else
                {
                    await SetTokenAsync();
                }
            }

            return null;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await GetTokenAsync();
            var identity = string.IsNullOrEmpty(token)
                ? new ClaimsIdentity()
                : new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split(".")[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuesPairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            return keyValuesPairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString()));
        }


        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }

            return Convert.FromBase64String(base64);
        }
    }
}
