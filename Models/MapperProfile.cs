using AutoMapper;

namespace Example.Models;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ApplicationUserDto, ApplicationUser>();
    }
}
