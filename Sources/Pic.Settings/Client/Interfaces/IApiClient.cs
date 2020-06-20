using Pic.Settings.Shared.Dto;
using System.Collections.Generic;

namespace Pic.Settings.Client.Interfaces
{
    public interface IApiClient
    {
        IEnumerable<AlbumDto> GetAlbums();
        IEnumerable<GroupDto> GetGroups();
        List<UserDto> GetUsers();

        bool AddAlbum(AlbumDto albumData);
        bool AddGroup(GroupDto groupData);
        bool AddUser(UserDto userData);

        bool ModifyAlbum(AlbumDto albumData);
        bool ModifyGroup(GroupDto groupData);
        bool ModifyUser(UserDto userData);

        bool DeleteAlbum(AlbumDto albumData);
        bool DeleteGroup(GroupDto groupData);
        bool DeleteUser(UserDto userData);
    }
}