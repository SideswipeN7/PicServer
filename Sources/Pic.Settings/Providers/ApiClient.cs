using Pic.Settings.Interfaces;
using Pic.Settings.Models;
using System;
using System.Collections.Generic;

namespace Pic.Settings.Providers
{
    public class ApiClient : IApiClient
    {
        bool IApiClient.AddAlbum(AlbumData albumData)
        {
            throw new NotImplementedException();
        }

        bool IApiClient.AddGroup(GroupData groupData)
        {
            throw new NotImplementedException();
        }

        bool IApiClient.AddUser(UserData userData)
        {
            throw new NotImplementedException();
        }

        bool IApiClient.DeleteAlbum(AlbumData albumData)
        {
            throw new NotImplementedException();
        }

        bool IApiClient.DeleteGroup(GroupData groupData)
        {
            throw new NotImplementedException();
        }

        bool IApiClient.DeleteUser(UserData userData)
        {
            throw new NotImplementedException();
        }

        IEnumerable<AlbumData> IApiClient.GetAlbums()
        {
            throw new NotImplementedException();
        }

        IEnumerable<GroupData> IApiClient.GetGroups()
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserData> IApiClient.GetUsers()
        {
            throw new NotImplementedException();
        }

        bool IApiClient.ModifyAlbum(AlbumData albumData)
        {
            throw new NotImplementedException();
        }

        bool IApiClient.ModifyGroup(GroupData groupData)
        {
            throw new NotImplementedException();
        }

        bool IApiClient.ModifyUser(UserData userData)
        {
            throw new NotImplementedException();
        }
    }
}