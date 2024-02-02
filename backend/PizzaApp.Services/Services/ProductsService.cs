using AutoMapper;
using PizzaApp.BusinessLogic.Models.Products;
using PizzaApp.BusinessLogic.Services.Contracts;
using PizzaApp.DataAccess.Repos.Contracts;

namespace PizzaApp.BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository productRepo;
        private readonly IMapper mapper;

        public ProductsService(IProductsRepository productRepo, IMapper mapper)
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var  products =  await productRepo.GetAllAsync();

            return mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
