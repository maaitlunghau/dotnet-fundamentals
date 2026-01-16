using _11_dto_automapper_authentication.DTOs;
using AutoMapper;

namespace _11_dto_automapper_authentication.Models;

public class MapperProfile : Profile
{
    // constructor
    public MapperProfile()
    {
        // dest (destination: đích đến): object đích (UserDTO)
        // opt (options): cấu hình cách map
        // src (source): object nguồn (Account)
        CreateMap<Account, UserDTO>()
            .ForMember(dest => dest.Tuoi, opt => opt.MapFrom(src => src.Age))
            .ReverseMap();
    }
}