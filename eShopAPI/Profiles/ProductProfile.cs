using AutoMapper;
using eShopAPI.DTO_s;
using eShopAPI.Models;

namespace eShopAPI.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>();
        }
    }
}
