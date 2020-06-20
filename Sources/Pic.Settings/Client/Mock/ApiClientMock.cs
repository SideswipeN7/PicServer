using Pic.Settings.Client.Interfaces;
using Pic.Settings.Shared.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Pic.Settings.Client.Mock
{
    public class ApiClientMock : IApiClient
    {
        private List<GroupDto> groups = new List<GroupDto>
        {
            new GroupDto{Name="Admin", Rights=RightsDto.Read },
            new GroupDto{Name="User", Rights=RightsDto.Read },
            new GroupDto{Name="Special", Rights=RightsDto.ReadWrite},
        };
        private List<AlbumDto> albums = new List<AlbumDto>
        {
            new AlbumDto{Title="First", Path="/first_album", Summary="My first Album", RequireAuthorization= true, Groups=new List<string> { "User", "Admin" } },
            new AlbumDto{Title="Second", Path="/second_album", Summary="My second Album", RequireAuthorization= true, Groups=new List<string> { "User", "Admin" } },
        };
        private List<UserDto> users = new List<UserDto>
        {
            new UserDto{Username = "Admin", Password= "Admin", Groups=new List<string> { "Admin" } },
            new UserDto{Username = "Student", Password= "Student", Groups=new List<string> { "User" } },
            new UserDto{Username = "Student_22", Password= "Student", Groups=new List<string> { "User" } },
        };


        public IEnumerable<AlbumDto> GetAlbums() => albums;
        public List<UserDto> GetUsers() => users;
        public IEnumerable<GroupDto> GetGroups() => groups;

        public bool AddAlbum(AlbumDto albumData)
        {
            AlbumDto album = FindAlbum(albumData);
            if (album is null)
            {
                albums.Add(albumData);
            }

            return true;
        }

        public bool AddGroup(GroupDto groupData)
        {
            GroupDto group = FindGroup(groupData);
            if (group is null)
            {
                groups.Add(groupData);
            }

            return true;
        }

        public bool AddUser(UserDto userData)
        {
            UserDto user = FindUser(userData);
            if (user is object)
            {
                users.Add(userData);
            }

            return true;
        }

        public bool ModifyAlbum(AlbumDto albumData)
        {
            AlbumDto album = FindAlbum(albumData);
            if (album is null)
            {
                albums.Add(albumData);

                return true;
            }

            int index = albums.IndexOf(album);
            albums[index] = albumData;

            return true;
        }

        public bool ModifyGroup(GroupDto groupData)
        {
            GroupDto group = FindGroup(groupData);
            if (group is null)
            {
                groups.Add(groupData);

                return true;
            }

            int index = groups.IndexOf(group);
            groups[index] = groupData;

            return true;
        }

        public bool ModifyUser(UserDto userData)
        {
            UserDto user = FindUser(userData);
            if (user is object)
            {
                users.Add(userData);

                return true;
            }

            int index = users.IndexOf(user);
            users[index] = userData;

            return true;
        }

        public bool DeleteAlbum(AlbumDto albumData)
        {
            AlbumDto album = FindAlbum(albumData);
            if (album is object)
            {
                albums.Remove(album);
            }

            return true;
        }

        public bool DeleteGroup(GroupDto groupData)
        {
            GroupDto group = FindGroup(groupData);
            if (group is object)
            {
                groups.Remove(group);
            }

            return true;
        }

        public bool DeleteUser(UserDto userData)
        {
            UserDto user = FindUser(userData);
            if (user is object)
            {
                users.Remove(user);
            }

            return true;
        }

        private UserDto FindUser(UserDto userData) => users.FirstOrDefault(x => x.Username == userData.Username);
        private GroupDto FindGroup(GroupDto groupData) => groups.FirstOrDefault(x => x.Name == groupData.Name);
        private AlbumDto FindAlbum(AlbumDto albumData) => albums.FirstOrDefault(x => x.Title == albumData.Title);
    }
}