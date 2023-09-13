using AutoMapper;
using AutoMapperAPISample.DTO;
using AutoMapperAPISample.Entity;

namespace AutoMapperAPISample.CustomResolvers
{
    public class PriceResolver : IValueResolver<Product, ProductDTO, string>
    {
        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            return $"${source.Price}";
        }
    }
}
