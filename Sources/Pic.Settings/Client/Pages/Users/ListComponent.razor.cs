using Microsoft.AspNetCore.Components;
using Pic.Settings.Client.Interfaces;
using Pic.Settings.Shared.Models;
using System.Collections.Generic;

namespace Pic.Settings.Client.Pages.Users
{
    public partial class ListComponent
    {
        public static readonly string Path = "/Users";

        [Inject]
        IApiClient apiClient { get; set; }
        IEnumerable<UserData> users { get; set; }

        protected override void OnInitialized()
        {
            users = apiClient.GetUsers();
        }
    }
}
