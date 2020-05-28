using Pic.Settings.Models;
using System.Collections.Generic;

namespace Pic.Settings.Interfaces
{
    public interface IApiClient
    {
        IEnumerable<AlbumData> GetAlbums();
        IEnumerable<GroupData> GetGroups();
        IEnumerable<UserData> GetUsers();

        bool AddAlbum(AlbumData albumData);
        bool AddGroup(GroupData groupData);
        bool AddUser(UserData userData);

        bool ModifyAlbum(AlbumData albumData);
        bool ModifyGroup(GroupData groupData);
        bool ModifyUser(UserData userData);

        bool DeleteAlbum(AlbumData albumData);
        bool DeleteGroup(GroupData groupData);
        bool DeleteUser(UserData userData);
    }
}