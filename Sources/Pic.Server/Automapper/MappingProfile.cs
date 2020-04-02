using AutoMapper;
using Pic.Repository.Models;
using Pic.Server.DTO;

namespace Pic.Server.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AlbumDto, AlbumEntity>().ReverseMap();
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<GroupDto, GroupEntity>().ReverseMap();
        }
    }
}