using Pic.Data.Interfaces;

namespace Pic.Data.Models;

public class PhotoAlbum : BaseModel, IEntity
{
    public string Title { get; set; } = default!;

    public string FolderName { get; init; } = default!;

    public byte[]? Thumbnail { get; private set; }

    private readonly List<Photo> _photos = new();

    public IReadOnlyCollection<Photo> Photos => _photos;

    public void AddPhotos(IEnumerable<Photo> photosToAdd) => _photos.AddRange(photosToAdd);

    public void AddPhoto(Photo photoToAdd) => AddPhotos(new[] { photoToAdd });

    public void RemovePhoto(int photoId) => RemovePhotos(new[] { photoId });

    public void RemovePhotos(IEnumerable<int> ids) => _photos.RemoveAll(p => ids.Contains(p.Id));

    public void SetThumbnail(byte[]? newThumbnail = null) => Thumbnail = newThumbnail;

    public void ChangeTitle(string newTitle) => Title = newTitle;
}
