using System.ComponentModel.DataAnnotations;
using PS.Pictures.Application.Pictures.Create;

namespace PS.Pictures.Api.Controllers.Pictures.DTOs;

public record CreatePictureRequest([Required] string FileName, [Required]string Location,  string Name, string? Description)
{
    internal CreatePictureCommand AsCommand(Guid uid, string userId) => new(uid, userId, Location, FileName, Name, Description);
}
