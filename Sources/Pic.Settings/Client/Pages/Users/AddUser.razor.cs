using System;
using Microsoft.AspNetCore.Components;
using Pic.Settings.Client.Services;
using Pic.Settings.Client.Shared.Modal;
using Pic.Settings.Shared.Dto;

namespace Pic.Settings.Client.Pages.Users
{
    public partial class AddUser
    {
        public static string Url => $"{UsersList.Url}/Add";

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private UsersService UsersService { get; set; }

        [Inject]
        private GroupsService GroupsService { get; set; }

        private readonly ModalLocale saveModalLocale = new ModalLocale
        {
            Title = "Add new user",
            Content = "Are you sure you want to add this user?",
            CloseText = "Cancel",
            OkText = "Add"
        };
        private readonly ModalLocale cancelModalLocale = new ModalLocale
        {
            Title = "Cancel",
            Content = "Are you sure you want to cancel? All data will be lost.",
            CloseText = "Cancel",
            OkText = "OK"
        };

        private void NavigateBack() => NavigationManager.NavigateTo(UsersList.Url);

        private void Add(UserDto userDto)
        {
            if (UsersService.Add(userDto))
            {
                NavigateBack();
            }
            else
            {
                Console.Error.WriteLine("Error on add user");
            }
        }
    }
}