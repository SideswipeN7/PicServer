using System.ComponentModel.DataAnnotations;
using PS.Pictures.Application.Pictures.Modify;

namespace PS.Pictures.Api.Controllers.Pictures.DTOs;

public record EditPictureRequest([Required] string FileName, string? Name, string? Description)
{
    internal EditPictureCommand AsCommand(Guid uid, string owner) => new(uid, owner, FileName, Name, Description);
}
