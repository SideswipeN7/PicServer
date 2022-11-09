using PS.Pictures.Domain.Pictures;
using PS.Shared.Application.CQRS.Commands;

namespace PS.Pictures.Application.Pictures.Create;

public record CreatePictureCommand(Guid Uid, string Owner, string Location, string FileName, string Name, string? Description) : ICommand
{
    internal PictureState AsState() => new(FileName, Name, Description);
}
