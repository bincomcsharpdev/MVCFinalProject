using AutoMapper;
using MVCFinalProject.Models.DTOs;
using MVCFinalProject.Models.Entities;

namespace MVCFinalProject.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<YahyaPortfolioItem, PortfolioItemDto>().ReverseMap();
        }
    }
}
