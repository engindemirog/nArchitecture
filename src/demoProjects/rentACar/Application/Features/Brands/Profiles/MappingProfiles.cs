using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Brand, CreatedBrandDto>().ReverseMap(); // her iki türlü de mapleme çalışır. Brand dto yada dto Brand
            CreateMap<Brand, CreateBrandCommand>().ReverseMap();
            CreateMap<Brand, BrandListDto>().ReverseMap();
            CreateMap<Brand, BrandGetByIdDto>().ReverseMap();
            CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
        }
    }
}
