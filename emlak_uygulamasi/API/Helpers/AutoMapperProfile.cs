using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MusteriSatici, MusteriSaticiDto>();
            CreateMap<Emlak, EmlakDto>();
        }
    }
}