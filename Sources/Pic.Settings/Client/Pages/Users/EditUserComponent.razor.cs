using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Pic.Settings.Client.Shared.Modal;
using Pic.Settings.Client.ViewModels;
using Pic.Settings.Shared.Dto;

namespace Pic.Settings.Client.Pages.Users
{
    public partial class EditUserComponent
    {
        [Parameter]
        public bool ShouldEditUserName { get; set; }

        [Parameter]
        public IEnumerable<GroupDto> Groups { get; set; }

        [Parameter]
        public string SaveBtnText { get; set; }

        [Parameter]
        public ModalLocale CancelModalLocale { get; set; }

        [Parameter]
        public ModalLocale SaveModalLocale { get; set; }

        [Parameter]
        public Action<UserDto> OnSaveModalOk { get; set; }

        [Parameter]
        public Action OnCancelModalOk { get; set; }

        private EditUserViewModel ViewModel { get; set; } = new EditUserViewModel { Groups = new List<string>() };
        private SimpleModalComponent Modal { get; set; }

        internal void SetData(UserDto userDto) => ViewModel = EditUserViewModel.FromUser(userDto);

        private void Cancel()
        {
            Modal.ModalLocale = CancelModalLocale;
            Modal.ActionOk = OnCancelModalOk;
            Modal.Open();
        }

        private void Save()
        {
            Modal.ModalLocale = SaveModalLocale;
            Modal.ActionOk = () => OnSaveModalOk(ViewModel.ToUserDto());
            Modal.Open();
        }

        private void ToggleGroup(string groupName, bool shouldAdd)
        {
            ViewModel
        }
    }
}
