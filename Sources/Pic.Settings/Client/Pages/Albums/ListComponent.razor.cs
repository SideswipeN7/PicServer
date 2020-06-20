﻿using Microsoft.AspNetCore.Components;
using Pic.Settings.Client.Interfaces;
using Pic.Settings.Shared.Dto;
using System.Collections.Generic;

namespace Pic.Settings.Client.Pages.Albums
{

    public partial class ListComponent
    {
        public static readonly string Path = "/Albums";

        [Inject]
        IApiClient apiClient { get; set; }
        IEnumerable<AlbumDto> albums { get; set; }

        protected override void OnInitialized()
        {
            albums = apiClient.GetAlbums();
        }


        private void DeleteAlbum(AlbumDto albumData)
        {

        }

        private void EditAlbum(AlbumDto albumData)
        {

        }
    }
}
