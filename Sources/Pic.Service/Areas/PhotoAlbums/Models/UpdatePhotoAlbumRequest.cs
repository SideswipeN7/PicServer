using System.ComponentModel.DataAnnotations;
using Pic.Core.Infrastructure.Constants;

namespace Pic.Service.Areas.PhotoAlbums.Models;
public record CreatePhotoAlbumRequest(
    [MaxLength(StringConstrains.MaxTitleLength)] string Title,
    [MaxLength(StringConstrains.MaxSynopsisLength)] string? Synopsis);
