namespace Pic.Persistance.Configurations;

internal class SettingConfiguration : BaseIdentityConfiguration<Setting>
{
    public override void Configure(EntityTypeBuilder<Setting> builder)
    {
        base.Configure(builder);

        builder.HasIndex(s => s.Key);
    }
}
