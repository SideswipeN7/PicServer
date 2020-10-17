using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pic.Database.Data.Entities;

namespace Pic.Pictures.Entities
{
    public class PictureBuilder : EntityBuilder<Picture>
    {
        public override void Configure(EntityTypeBuilder<Picture> builder)
        {
            base.Configure(builder);

            builder.ToTable("PICTURES");

            builder.Property(p => p.Description)
                .HasColumnName("DESCRIPTION");

            builder.Property(p => p.Name)
                .HasColumnName("NAME")
                .IsRequired();

            builder.Property(p => p.ImageUrl)
                .HasColumnName("URL")
                .IsRequired();
        }
    }
}