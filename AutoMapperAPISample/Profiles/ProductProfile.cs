using AutoMapper;
using AutoMapperAPISample.CustomConverters;
using AutoMapperAPISample.CustomResolvers;
using AutoMapperAPISample.DTO;
using AutoMapperAPISample.Entity;

namespace AutoMapperAPISample.Profiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.DisplayPrice, opt => opt.MapFrom<PriceResolver>())
                .ForMember(dest => dest.TimeStamp, opt => opt.ConvertUsing<UnixToDateTimeConverter, long>())
                .ForMember(dest => dest.Description, opt => opt.Condition(src => src.Description.Length > 10));
        }

    }
}
