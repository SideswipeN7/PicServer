using PS.Pictures.Domain.Pictures;
using PS.Pictures.Infrastructure.EF.Models;

namespace PS.Pictures.Infrastructure.Repositories.Pictures.Extensions;

internal static class PictureModelExtensions
{
    internal static PictureDbModel ToModel(this Picture entity)
    {
        var snapshot = entity.GetSnapshot();

        return new PictureDbModel
        {
            Uid = snapshot.Uid,
            Description = snapshot.Description,
            Name = snapshot.Name,
            FileName = snapshot.FileName,
            Location = snapshot.Location,
            Owner = snapshot.Owner,
        };
    }

    internal static Picture ToEntity(this PictureDbModel model) => new(new(
        model.Uid,
        model.Owner,
        model.FileName,
        model.Name,
        model.Description,
        model.Location));
}
