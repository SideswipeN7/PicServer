using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Pic.Settings.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Pic.Settings.Client.Pages
{
    public partial class Login
    {
        [Inject]
        public TokenAuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public HttpClient http { get; set; }
        private CredentialsDto Credentials { get; set; } = new CredentialsDto();
        private EditForm loginForm{get;set;}
        private bool loginFailure;

        private async Task LogInAsync()
        {
            var httpResponse = await http.PutAsJsonAsync("api/Authorization/Login", Credentials);
            var logInResult = await httpResponse.Content.ReadAsAsync<LogInResultDto>();

            loginFailure = logInResult.Token is null;
            if (!loginFailure)
            {
                await AuthenticationStateProvider.SetTokenAsync(logInResult.Token, logInResult.Expiry);
            }

        }
    }
}
