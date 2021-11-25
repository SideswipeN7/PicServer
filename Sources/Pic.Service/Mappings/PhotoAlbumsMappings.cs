using AutoMapper;

namespace Pic.Service.Mappings;

public class PhotoAlbumsMappings : Profile
{
    public PhotoAlbumsMappings()
    {
        CreateMap<CreatePhotoAlbumRequest, CreatePhotoAlbumCommand>();

        CreateMap<UpdatePhotoAlbumRequest, UpdatePhotoAlbumTitleCommand>()
            .ForMember(command => command.PhotoAlbumId, opt => opt.MapFrom<CustomIdResolver>());

        CreateMap<int, GetSinglePhotoAlbumInfoQuery>()
            .ForMember(command => command.Id, opt => opt.MapFrom(request => request));

        CreateMap<IEnumerable<int>, MarkPhotoAlbumsAsDeletedCommand>()
            .ForMember(command => command.PhotoAlbumIds, opt => opt.MapFrom(request => request));

        CreateMap<int, MarkPhotoAlbumsAsDeletedCommand>()
            .ForMember(command => command.PhotoAlbumIds, opt => opt.MapFrom(request => new[] { request }));

        CreateMap<IEnumerable<int>, RestorePhotoAlbumsCommand>()
            .ForMember(command => command.PhotoAlbumIds, opt => opt.MapFrom(request => request));

        CreateMap<int, RestorePhotoAlbumsCommand>()
            .ForMember(command => command.PhotoAlbumIds, opt => opt.MapFrom(request => new[] { request }));
    }
}
