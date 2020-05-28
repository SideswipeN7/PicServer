using Microsoft.AspNetCore.Components;
using Pic.Settings.Interfaces;
using Pic.Settings.Models;
using System.Collections.Generic;

namespace Pic.Settings.Pages.Albums
{

    public partial class ListComponent
    {
        public static readonly string Path = "/Albums";

        [Inject]
        IApiClient apiClient { get; set; }
        IEnumerable<AlbumData> albums { get; set; }

        protected override void OnInitialized()
        {
            albums = apiClient.GetAlbums();
        }
    }
}
