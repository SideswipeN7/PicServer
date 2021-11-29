namespace Pic.Data.Extensions;

internal static class PhotoAlbumExtensions
{
    public static IQueryable<AlbumInfo> MapToAlbumInfo(this IQueryable<PhotoAlbum> query)
    {
        return query.Select(pa => new AlbumInfo
        {
            Id = pa.Id,
            Title = pa.Title,
            Synopsis = pa.Synopsis,
            Thumbnail = pa.Thumbnail ?? Array.Empty<byte>(),
            PhotosCount = pa.Photos.Count,
        });
    }
}
