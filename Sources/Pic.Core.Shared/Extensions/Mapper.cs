using AutoMapper;
using Pic.Core.Shared.Exceptions;

namespace Pic.Core.Shared.Extensions;

public static class Mapper
{
    public const string IdProperty = "ID";

    private static IMapper? instance;

    public static IMapper Instance
    {
        get => instance!;
        set
        {
            if (instance is not null)
            {
                throw new DomainException("AutoMapper reinitialization");
            }

            instance = value;
        }
    }

    public static TDestination Map<TDestination>(object source)
    {
        return Instance.Map<TDestination>(source);
    }

    public static TDestination MapWithId<TDestination>(object source, int id)
    {
        return Instance.Map<TDestination>(source, opt => opt.Items.Add(IdProperty, id));
    }
}
