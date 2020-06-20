using System;
using Microsoft.AspNetCore.Components;
using Pic.Settings.Client.Services;
using Pic.Settings.Client.Shared.Modal;
using Pic.Settings.Shared.Dto;

namespace Pic.Settings.Client.Pages.Users
{
    public partial class EditUser
    {
        public static string CreateUrl(UserDto userDto) => $"{UsersList.Url}/Edit/{Uri.EscapeDataString(userDto.Username)}";

        [Parameter]
        public string UserName { get; set; }

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private UsersService UsersService { get; set; }

        [Inject]
        private GroupsService GroupsService { get; set; }

        private EditUserComponent EditUserComponent { get; set; }        

        private readonly ModalLocale saveModalLocale = new ModalLocale
        {
            Title = "Edit user",
            Content = "Are you sure you want to save chages?",
            CloseText = "Cancel",
            OkText = "Update"
        };
        private readonly ModalLocale cancelModalLocale = new ModalLocale
        {
            Title = "Cancel",
            Content = "Are you sure you want to cancel? User data will not be changed.",
            CloseText = "Cancel",
            OkText = "OK"
        };

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var userDto = UsersService.Find(UserName, true);
            if (userDto is object)
            {
                EditUserComponent.SetData(userDto);
            }
            else
            {
                NavigateBack();
            }
        }

        private void NavigateBack() => NavigationManager.NavigateTo(UsersList.Url);

        private void Update(UserDto userDto)
        {
            if(UsersService.Update(UserName, userDto))
            {
                NavigateBack();
            }
            else
            {
                Console.Error.WriteLine("Error on update user");
            }
        }
    }
}