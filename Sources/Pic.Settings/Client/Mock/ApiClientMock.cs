using Pic.Settings.Client.Interfaces;
using Pic.Settings.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Pic.Settings.Client.Mock
{
    public class ApiClientMock : IApiClient
    {
        private List<GroupData> groups = new List<GroupData>
        {
            new GroupData{Name="Admin", Rights=Rights.Delete },
            new GroupData{Name="User", Rights=Rights.Read },
            new GroupData{Name="Special", Rights=Rights.Delete},
        };
        private List<AlbumData> albums = new List<AlbumData>
        {
            new AlbumData{Title="First", Path="/first_album", Summary="My first Album", RequireAuthorization= true, Groups=new List<string> { "User", "Admin" } },
            new AlbumData{Title="Second", Path="/second_album", Summary="My second Album", RequireAuthorization= true, Groups=new List<string> { "User", "Admin" } },
        };
        private List<UserData> users = new List<UserData>
        {
            new UserData{Username = "Admin", Password= "Admin", Groups=new List<string> { "Admin" } },
            new UserData{Username = "Student", Password= "Student", Groups=new List<string> { "User" } },
            new UserData{Username = "Student_22", Password= "Student", Groups=new List<string> { "User" } },
        };


        public IEnumerable<AlbumData> GetAlbums() => albums;
        public IEnumerable<UserData> GetUsers() => users;
        public IEnumerable<GroupData> GetGroups() => groups;

        public bool AddAlbum(AlbumData albumData)
        {
            AlbumData album = FindAlbum(albumData);
            if (album is null)
            {
                albums.Add(albumData);
            }

            return true;
        }

        public bool AddGroup(GroupData groupData)
        {
            GroupData group = FindGroup(groupData);
            if (group is null)
            {
                groups.Add(groupData);
            }

            return true;
        }

        public bool AddUser(UserData userData)
        {
            UserData user = FindUser(userData);
            if (user != null)
            {
                users.Add(userData);
            }

            return true;
        }

        public bool ModifyAlbum(AlbumData albumData)
        {
            AlbumData album = FindAlbum(albumData);
            if (album is null)
            {
                albums.Add(albumData);

                return true;
            }

            int index = albums.IndexOf(album);
            albums[index] = albumData;

            return true;
        }

        public bool ModifyGroup(GroupData groupData)
        {
            GroupData group = FindGroup(groupData);
            if (group is null)
            {
                groups.Add(groupData);

                return true;
            }

            int index = groups.IndexOf(group);
            groups[index] = groupData;

            return true;
        }

        public bool ModifyUser(UserData userData)
        {
            UserData user = FindUser(userData);
            if (user != null)
            {
                users.Add(userData);

                return true;
            }

            int index = users.IndexOf(user);
            users[index] = userData;

            return true;
        }

        public bool DeleteAlbum(AlbumData albumData)
        {
            AlbumData album = FindAlbum(albumData);
            if (album != null)
            {
                albums.Remove(album);
            }

            return true;
        }

        public bool DeleteGroup(GroupData groupData)
        {
            GroupData group = FindGroup(groupData);
            if (group != null)
            {
                groups.Remove(group);
            }

            return true;
        }

        public bool DeleteUser(UserData userData)
        {
            UserData user = FindUser(userData);
            if (user != null)
            {
                users.Remove(user);
            }

            return true;
        }

        private UserData FindUser(UserData userData) => users.FirstOrDefault(x => x.Username == userData.Username);
        private GroupData FindGroup(GroupData groupData) => groups.FirstOrDefault(x => x.Name == groupData.Name);
        private AlbumData FindAlbum(AlbumData albumData) => albums.FirstOrDefault(x => x.Title == albumData.Title);
    }
}