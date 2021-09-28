using Microsoft.EntityFrameworkCore;
using Pic.Data.Models;

namespace Pic.Persistance;

public class PicDbContext : DbContext
{
    public DbSet<PhotoAlbum> PhotoAlbums { get; set; } = default!;

    public DbSet<Photo> Photos { get; set; } = default!;
}
