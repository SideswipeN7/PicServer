using System;
using System.Collections.Generic;
using System.Linq;
using Pic.Settings.Client.Interfaces;
using Pic.Settings.Shared.Dto;

namespace Pic.Settings.Client.Services
{
    public class UsersService
    {
        public List<UserDto> Users { get; private set; }

        private IApiClient apiClient { get; }

        public UsersService(IApiClient apiClient) => this.apiClient = apiClient;

        public void Fetch()
        {
            Users = apiClient.GetUsers();
            Users.Sort();
        }

        public bool Update(string oldUsername, UserDto userDto)
        {
            bool succes = false;
            if (apiClient.ModifyUser(userDto) && (Find(oldUsername) is null || oldUsername == userDto.Username))
            {
                Users[Users.FindIndex(x => x.Username == userDto.Username)] = userDto;
                Users.Sort();
                succes = true;
            }

            return succes;
        }

        public bool Add(UserDto userDto)
        {
            bool succes = false;
            if (apiClient.AddUser(userDto))
            {
                Users.Add(userDto);
                Users.Sort();
                succes = true;
            }

            return succes;
        }

        internal UserDto Find(string userName, bool shouldfetch = false)
        {
            if (shouldfetch)
            {
                Fetch();
            }
            return Users.FirstOrDefault(x => x.Username == userName);
        }

        public bool Delete(UserDto userDto)
        {
            bool succes = false;
            if (apiClient.ModifyUser(userDto))
            {
                Users.Remove(userDto);
                succes = true;
            }

            return succes;
        }
    }
}