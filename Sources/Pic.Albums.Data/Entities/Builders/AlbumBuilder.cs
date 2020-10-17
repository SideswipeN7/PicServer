using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pic.Database.Data.Entities;

namespace Pic.Albums.Data.Entities.Builders
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
        }
    }
}