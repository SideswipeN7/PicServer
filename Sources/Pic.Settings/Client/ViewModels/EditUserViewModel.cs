using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pic.Settings.Shared.Dto;

namespace Pic.Settings.Client.ViewModels
{
    public class EditUserViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "User name is required")]
        [MinLength(4, ErrorMessage = "Minimum length is 4")]
        [MaxLength(20, ErrorMessage = "Maximum length is 20")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password name is required")]
        [MinLength(4, ErrorMessage = "Minimum length is 4")]
        [MaxLength(20, ErrorMessage = "Maximum length is 20")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please retype password")]
        [Compare(nameof(Password), ErrorMessage = "Password are not that same")]
        public string PasswordRetype { get; set; }

        public List<string> Groups { get; set; }

        internal UserDto ToUserDto() => new UserDto { Username = Username, Password = Password, Groups = Groups };

        internal static EditUserViewModel FromUser(UserDto userDto) => new EditUserViewModel
        {
            Username = userDto.Username,
            Password = userDto.Password,
            PasswordRetype = userDto.Password,
            Groups = userDto.Groups ?? new List<string>()
        };
    }
}