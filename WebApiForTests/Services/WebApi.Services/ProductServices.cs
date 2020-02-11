using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.DTO.Product;

namespace WebApi.Services
{
    public class ProductServices : IProductServices
    {
        private readonly WebApiDbContext dbContext;

        public ProductServices(WebApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddProductTypeAsync(ProductTypeDTO inputModel)
        {
            var productType = new ProductType()
            {
                Name = inputModel.Name
            };

            await this.dbContext.ProductType.AddAsync(productType);
            await this.dbContext.SaveChangesAsync();
            return productType.Id;
        }

        public List<ProductDTO> GetAllProducts() 
        {
            var products = this.dbContext.Products.Select(x => new ProductDTO
            {
                Name = x.Name,
                MaxPrincipal = x.MaxPrincipal,
                MinPrincipal = x.MinPrincipal,
                Step = x.Step
            }).ToList();

            return products;
        }

        public async Task<int> CreateProductAsync(CreateProductInputModel inputModel)
        {
            var product = new Product()
            {
                Name = inputModel.Name,
                Step = inputModel.Step,
                MaxPrincipal = inputModel.MaxPrincipal,
                MinPrincipal = inputModel.MinPrincipal,
                ProductTypeId = inputModel.ProductTypeId,
            };
            await this.dbContext.AddAsync(product);
            await this.dbContext.SaveChangesAsync();
            return product.Id;
        }
    }
}