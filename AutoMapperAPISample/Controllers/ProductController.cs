using AutoMapper;
using AutoMapperAPISample.DTO;
using AutoMapperAPISample.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapperAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("ConvertOneProduct",Name = "ConvertOneProduct")]
        public ProductDTO Get()
        {
            Product product = new Product
            {
                Id = 1,
                Name = "Laptop",
                Price = 1000.00M,
                Description = "High-end gaming laptop",
                IsArchived = false,
                TimeStamp = 86400
            };
            var _Product = _mapper.Map<ProductDTO>(product);

            return _Product;
        }

        [HttpGet("ConvertListOfProducts", Name = "ConvertListOfProducts")]
        public IEnumerable<ProductDTO> GetList()
        {
            Product product1 = new Product
            {
                Id = 1,
                Name = "Laptop1",
                Price = 1000.00M,
                Description = "High-end gaming laptop",
                IsArchived = false
            };
            Product product2 = new Product
            {
                Id = 2,
                Name = "Laptop2",
                Price = 1000.00M,
                Description = "High-end gaming laptop",
                IsArchived = false
            };
            Product product3 = new Product
            {
                Id = 3,
                Name = "Laptop3",
                Price = 1000.00M,
                Description = "High-end gaming laptop",
                IsArchived = false
            };

            List<Product> aListOfProducts = new List<Product>();
            aListOfProducts.Add(product1);
            aListOfProducts.Add(product2);
            aListOfProducts.Add(product3);

            List<ProductDTO> aListOfProductDTOs = _mapper.Map<List<ProductDTO>>(aListOfProducts);

            return aListOfProductDTOs;
        }
    }
}
