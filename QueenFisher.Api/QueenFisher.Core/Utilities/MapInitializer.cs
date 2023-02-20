
using AutoMapper;
using QueenFisher.Data.Domains;
using QueenFisher.Data.DTO;

namespace QueenFisher.Core.Utilities
{
    public class MapInitializer : Profile
    {
        public Mapper regMapper { get; set; }
        public MapInitializer()
        {
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AppUser,AppUserDtoForUpdate>().ReverseMap();
            CreateMap<AppUser,LoginUserDTO>().ReverseMap();
            CreateMap<AppUser, RegisterDTO>().ReverseMap();
        }
    }
}
