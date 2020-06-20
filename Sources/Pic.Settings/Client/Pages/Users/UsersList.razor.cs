using Microsoft.AspNetCore.Components;
using Pic.Settings.Client.Services;
using Pic.Settings.Client.Shared;
using Pic.Settings.Shared.Dto;

namespace Pic.Settings.Client.Pages.Users
{
    public partial class UsersList
    {
        public static readonly string Url = "/Users";

        [Inject]
        private UsersService UsersService { get; set; }
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        private SimpleModalComponent Modal { get; set; }
        private UserDto selectedUser;

        protected override void OnInitialized() => UsersService.Fetch();

        private void Edit(UserDto userData) => NavigationManager.NavigateTo(EditUser.CreateUrl(userData));

        private void Add() => NavigationManager.NavigateTo(AddUser.Url);

        private void Delete(UserDto userData)
        {
            selectedUser = userData;
            Modal.Open();
        }

        private void DeleteUser()
        {
            if (!UsersService.Delete(selectedUser))
            {
                // TODO: Add notification
                StateHasChanged();
            }

            selectedUser = null;
        }
    }
}
