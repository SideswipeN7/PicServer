using AutoMapper;

namespace Pic.Service.Mappings;

public class PhotosMappings : Profile
{
    public PhotosMappings()
    {
        CreateMap<CreatePhotoAlbumCommand, CreatePhotoAlbumRequest>();

        CreateMap<AddPhoto, AddPhotoCommand>()
            .ForMember(command => command.ImageBytes, opt => opt.MapFrom(request => request.PhotoData))
            .ForMember(command => command.Name, opt => opt.MapFrom(request => request.PhotoName));

        CreateMap<string, GetPhotoQuery>()
            .ForMember(command => command.PhotoName, opt => opt.MapFrom(request => request));
    }
}
