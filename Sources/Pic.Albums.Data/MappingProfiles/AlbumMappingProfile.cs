using AutoMapper;
using Pic.Albums.Data.Dto;
using Pic.Albums.Data.Entities;

namespace Pic.Albums.Data.MappingProfiles
{
    public class AlbumMappingProfile : Profile
    {
        public AlbumMappingProfile()
        {
            CreateMap<AlbumPicture, AlbumPictureDto>();
            CreateMap<Album, AlbumDto>();
        }
    }
}