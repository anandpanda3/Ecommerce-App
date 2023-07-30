using AutoMapper;
using Core.Entities;
using Souq.Dtos;

namespace Souq.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(x => x.ProductBrand, o => o.MapFrom(x => x.ProductBrand.Name))
                .ForMember(x => x.ProductType, o => o.MapFrom(x => x.ProductType.Name))
                .ForMember(x => x.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
