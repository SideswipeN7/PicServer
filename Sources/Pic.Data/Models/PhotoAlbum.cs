using Pic.Data.Interfaces;

namespace Pic.Data.Models;

public class PhotoAlbum : BaseModel, IEntity
{
    public string Title { get; private set; } = default!;

    public string FolderName { get; init; } = default!;

    public byte[]? Thumbnail { get; private set; }

    public ICollection<Photo> Photos { get; set; } = default!;

    public void AddPhoto(Photo photoToAdd)
    {
        Photos.Add(photoToAdd);
        UpdateModelDate();
    }

    public void RemovePhoto(int photoId)
    {
        RemovePhotos(new[] { photoId });
        UpdateModelDate();
    }

    public void RemovePhotos(IEnumerable<int> ids)
    {
        Photos = Photos.Where(p => !ids.Contains(p.Id)).ToList();
        UpdateModelDate();
    }

    public void SetThumbnail(byte[]? newThumbnail = null)
    {
        Thumbnail = newThumbnail;
        UpdateModelDate();
    }

    public void ChangeTitle(string newTitle)
    {
        Title = newTitle;
        UpdateModelDate();
    }
}
