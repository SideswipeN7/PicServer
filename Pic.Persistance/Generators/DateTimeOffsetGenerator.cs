using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Pic.Persistance.Generators;

public class DateTimeOffsetGenerator : ValueGenerator<DateTimeOffset>
{
    public override bool GeneratesTemporaryValues => false;

    public override DateTimeOffset Next([NotNull] EntityEntry entry)
    {
        return DateTimeOffset.UtcNow;
    }
}
