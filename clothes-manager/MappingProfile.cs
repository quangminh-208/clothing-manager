using AutoMapper;
using Entities.Models;
using Entities.DataTransferObjects;

namespace clothes_manager
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();
            CreateMap<UserForUpdateDto, User>();

            CreateMap<UserOrder, UserOrderDto>();

            CreateMap<Clothing, ClothingDto>();
            CreateMap<ClothingForCreationDto, Clothing>();
            CreateMap<ClothingForUpdateDto, Clothing>();
        }
    }
}
