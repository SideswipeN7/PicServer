using Microsoft.AspNetCore.Components;
using Pic.Settings.Client.Interfaces;
using Pic.Settings.Shared.Dto;
using System.Collections.Generic;

namespace Pic.Settings.Client.Pages.Groups
{
    public partial class ListComponent
    {
        public static readonly string Path = "/Groups";

        [Inject]
        IApiClient apiClient { get; set; }
        IEnumerable<GroupDto> groups { get; set; }

        protected override void OnInitialized()
        {
            groups = apiClient.GetGroups();
        }

        private void DeleteGroup(GroupDto groupData)
        {

        }

        private void EditGroup(GroupDto groupData)
        {

        }
    }
}
