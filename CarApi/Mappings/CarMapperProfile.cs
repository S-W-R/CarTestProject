using AutoMapper;
using CarApi.Domain.Models;
using CarApi.DTO;
using CarApi.Infrastructure.Models;

namespace CarApi.Mappings;

public class CarMapperProfile : Profile
{
    public CarMapperProfile()
    {
        CreateMap<CarDbEntity, Car>()
            .ForMember(x => x.CarNumber,
                e => e.MapFrom(c => new CarNumber(c.Number, c.RegionCode)))
            .ReverseMap()
            .ForMember(x => x.Number, e => e.MapFrom(c => c.CarNumber.Number))
            .ForMember(x => x.RegionCode, e => e.MapFrom(c => c.CarNumber.Code));
        CreateMap<CarDTO, Car>()
            .ForMember(x => x.CarNumber,
                e => e.MapFrom(c => new CarNumber(c.Number, c.RegionCode)))
            .ReverseMap()
            .ForMember(x => x.Number, e => e.MapFrom(c => c.CarNumber.Number))
            .ForMember(x => x.RegionCode, e => e.MapFrom(c => c.CarNumber.Code));
    }
}