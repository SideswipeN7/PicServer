using Microsoft.EntityFrameworkCore;
using PS.Pictures.Domain.Pictures;
using PS.Pictures.Infrastructure.EF;
using PS.Pictures.Infrastructure.EF.Models;
using PS.Pictures.Infrastructure.Repositories.Pictures.Extensions;

namespace PS.Pictures.Infrastructure.Repositories.Pictures;

internal class PictureRepository : IPictureRepository
{
    private readonly DbSet<PictureDbModel> pictures;

    public PictureRepository(PSContext context) => pictures = context.Pictures;

    public Task Add(Picture entity, CancellationToken cancellationToken = default) => pictures.AddAsync(entity.ToModel(), cancellationToken).AsTask();

    public async Task<Picture?> GetByUidAndOwner(Guid uid, string owner, CancellationToken cancellationToken = default)
    {
        var model = await pictures.FirstOrDefaultAsync(x => x.Uid == uid && x.Owner == owner, cancellationToken);

        return model?.ToEntity();
    }

    public async Task Update(Picture entity, CancellationToken cancellationToken = default)
    {
        var snapshot = entity.GetSnapshot();

        var model = await pictures.FirstOrDefaultAsync(x => x.Uid == snapshot.Uid, cancellationToken);

        model!.Description = snapshot.Description;
        model.Name = snapshot.Name;
        model.FileName = snapshot.FileName;
    }

    public Task<bool> IsFileNameUniqueForOwner(string owner, string fileName, CancellationToken cancellationToken = default) =>
        pictures.Where(x => x.Owner == owner).AllAsync(x => x.FileName == fileName, cancellationToken);

    public Task<int> GetSimilarNameCount(string owner, string fileName, CancellationToken cancellationToken = default) =>
        pictures.Where(x => x.Owner == owner).CountAsync(x => x.FileName.StartsWith(fileName), cancellationToken);
}
