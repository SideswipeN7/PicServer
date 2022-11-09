using PS.Pictures.Domain.Pictures;
using PS.Shared.Application.CQRS.Commands;

namespace PS.Pictures.Application.Pictures.Modify;

public record EditPictureCommand(Guid Uid, string Owner, string FileName, string? Name, string? Description) : ICommand
{
    internal PictureState AsState() => new(FileName, Name, Description);
}
