namespace PS.Shared.Domain.ValueObjects;

public record StringTrimValue
{
    private readonly string value;

    public int Length => value.Length;

    private StringTrimValue(string value) => this.value = value.Trim();

    public static StringTrimValue Create(string value) => new(value);

    public override string ToString() => value;

    public static implicit operator StringTrimValue(string value) => Create(value);

    public static implicit operator string(StringTrimValue value) => value.ToString();

    public static implicit operator StringTrimValue(OptionalStringTrimValue value) => Create(value!);
}
