using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Pictures.Domain.Pictures;
using PS.Pictures.Infrastructure.EF.Models;

namespace PS.Pictures.Infrastructure.EF.Configurations.Pictures;

internal class PictureModelConfiguration : IEntityTypeConfiguration<PictureDbModel>
{
    public void Configure(EntityTypeBuilder<PictureDbModel> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Uid).IsRequired();
        builder.HasIndex(x => x.Uid);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(PictureBussinesRules.NameMaxLength);

        builder.Property(x => x.Owner).IsRequired();//.HasMaxLength(PictureBussinesRules.NameMaxLength);
        builder.Property(x => x.IsArchived).IsRequired().HasDefaultValue(false);//.HasMaxLength(PictureBussinesRules.NameMaxLength);

        builder.Property(x => x.FileName).IsRequired().HasMaxLength(PictureBussinesRules.FileNameMaxLength);

        builder.Property(x => x.Description);
    }
}
