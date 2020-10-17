using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pic.Database.Data.Entities
{
    public class EntityBuilder<T> : IEntityTypeConfiguration<T> where T: BaseEntity
    {
        protected const string GetUtcDateFunction = "GETUTCDATE()";

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CreationTime)
                .IsRequired()
                .HasField("CREATION_TIME")
                .HasDefaultValueSql(GetUtcDateFunction)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.ModificationTime)
                .IsRequired()
                .HasField("MODIFICATION_TIME")
                .HasDefaultValueSql(GetUtcDateFunction)
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(p => p.Deleted)
                .IsRequired()
                .HasField("DELETED")
                .HasDefaultValue(false)
                .ValueGeneratedOnAdd();
        }
    }
}