using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreatedBrandDto>().ReverseMap(); // her iki türlü de mapleme çalışır. Brand dto yada dto Brand
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
        }
    }
}
