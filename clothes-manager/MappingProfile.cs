using AutoMapper;
using Entities.Models;
using Entities.DataTransferObjects;

namespace clothes_manager
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Clothing, ClothingDto>();
            CreateMap<ClothingForCreationDto, Clothing>();
            CreateMap<ClothingForUpdateDto, Clothing>();

            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();
            CreateMap<UserForUpdateDto, User>();
        }
    }
}
