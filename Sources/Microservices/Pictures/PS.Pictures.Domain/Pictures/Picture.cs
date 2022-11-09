using System.Runtime.CompilerServices;
using PS.Pictures.Domain.Pictures.Snapshots;
using PS.Shared.Domain.Domain.Exceptions.Extensions;
using PS.Shared.Domain.ValueObjects;

[assembly: InternalsVisibleTo("PS.Pictures.Infrastructure")]

namespace PS.Pictures.Domain.Pictures;

public class Picture
{
    private readonly Guid uid;
    private readonly StringTrimValue owner;
    private PictureState state;

    internal Picture(PictureSnapshot snapshot)
    {
        uid = snapshot.Uid;
        owner = snapshot.Owner;
        state = snapshot.AsState();
    }

    private Picture(Guid uid, string owner, PictureState state)
    {
        Validate(uid, owner, state);

        this.uid = uid;
        this.owner = owner;
        this.state = state;
    }

    public static Picture Create(Guid uid, string owner, PictureState state) => new(uid, owner, state);

    public void Edit(PictureState state)
    {
        ValidateState(state);

        this.state = state;
    }

    internal PictureSnapshot GetSnapshot() => new(uid, owner, state.FileName, state.Name, state.Description, "TODO");

    private static void Validate(Guid uid, string owner, PictureState state)
    {
        uid.ThrowIfDefault();
        owner.ThrowIfNullOrDefault();

        ValidateState(state);
    }

    private static void ValidateState(PictureState state)
    {
        state.FileName
            .ThrowIfLongerThan(PictureBussinesRules.FileNameMaxLength);

        state.FileName.ThrowIfLongerThan(PictureBussinesRules.NameMaxLength);
    }
}
