using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pic.Database.Data.Entities;

namespace Pic.Albums.Data.Entities
{
    public class AlbumBuilder : EntityBuilder<Album>
    {
        public override void Configure(EntityTypeBuilder<Album> builder)
        {
            base.Configure(builder);

            builder.ToTable("ALBUMS");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("NAME");

            builder.Property(p => p.Description)
                .HasColumnName("DESCRIPTION");

            builder.HasMany(p => p.Pictures)
                .WithOne(p => p.Album)
                .HasForeignKey(p => p.AlbumId);
        }
    }
}