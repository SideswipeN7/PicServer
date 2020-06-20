using System.Collections.Generic;
using Pic.Settings.Client.Interfaces;
using Pic.Settings.Shared.Dto;

namespace Pic.Settings.Client.Services
{
    public class GroupsService
    {
        public List<GroupDto> Groups { get; private set; }

        private IApiClient apiClient { get; }

        public GroupsService(IApiClient apiClient) => this.apiClient = apiClient;

        public void Fetch()
        {
            Users = apiClient.GetUsers();
        }

        public bool UpdateClient(UserDto userDto)
        {
            bool succes = false;
            if (apiClient.ModifyUser(userDto))
            {
                Users[Users.FindIndex(x => x.Username == userDto.Username)] = userDto;
                succes = true;
            }

            return succes;
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