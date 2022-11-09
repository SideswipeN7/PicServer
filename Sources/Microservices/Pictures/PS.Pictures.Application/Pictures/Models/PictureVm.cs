using System.ComponentModel.DataAnnotations;

namespace PS.Pictures.Application.Pictures.Models;

public record PictureVm([property: Key] Guid Uid, string Name, string? Description);
