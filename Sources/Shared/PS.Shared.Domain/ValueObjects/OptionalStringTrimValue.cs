namespace PS.Shared.Domain.ValueObjects;

public record OptionalStringTrimValue
{
    private readonly string? value;

    public int Length => value.Length;

    private OptionalStringTrimValue(string? value) => this.value = string.IsNullOrWhiteSpace(value) ? null : value.Trim();

    public static OptionalStringTrimValue Create(string? value) => new(value);

    public override string? ToString() => value;

    public static implicit operator OptionalStringTrimValue(string? value) => Create(value);

    public static implicit operator string?(OptionalStringTrimValue value) => value?.ToString();
}
