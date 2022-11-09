using PS.Shared.Domain.ValueObjects;

namespace PS.Pictures.Domain.Pictures;

public record PictureState(StringTrimValue FileName, OptionalStringTrimValue Name, OptionalStringTrimValue Description);
