using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pic.Database.Data.Entities;

namespace Pic.Albums.Data.Entities
{
    public class AlbumsPicturesBuilder : EntityBuilder<AlbumPicture>
    {
        public override void Configure(EntityTypeBuilder<AlbumPicture> builder)
        {
            base.Configure(builder);

            builder.ToTable("ALBUMS_PICTURES");

            builder.Property(p => p.AlbumId)
                .IsRequired()
                .HasColumnName("ALBUM_ID");

            builder.Property(p => p.PictureId)
                .IsRequired()
                .HasColumnName("PICTURE_ID");

            builder.Property(p => p.OrderId)
                .IsRequired()
                .HasColumnName("ORDER_ID");
        }
    }
}