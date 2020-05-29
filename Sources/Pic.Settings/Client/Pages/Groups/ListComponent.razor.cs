using Microsoft.AspNetCore.Components;
using Pic.Settings.Client.Interfaces;
using Pic.Settings.Shared.Models;
using System.Collections.Generic;

namespace Pic.Settings.Client.Pages.Groups
{
    public partial class ListComponent
    {
        public static readonly string Path = "/Groups";

        [Inject]
        IApiClient apiClient { get; set; }
        IEnumerable<GroupData> groups { get; set; }

        protected override void OnInitialized()
        {
            groups = apiClient.GetGroups();
        }
    }
}
