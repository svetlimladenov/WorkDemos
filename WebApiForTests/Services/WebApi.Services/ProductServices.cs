using Microsoft.EntityFrameworkCore;
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

        public async Task<ProductType> AddProductTypeAsync(ProductTypeDTO inputModel)
        {
            var productType = new ProductType()
            {
                Name = inputModel.Name
            };

            await this.dbContext.ProductType.AddAsync(productType);
            await this.dbContext.SaveChangesAsync();
            return productType;
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            var products = await this.dbContext.Products.Select(x => new ProductDTO
            {
                Name = x.Name,
                MaxPrincipal = x.MaxPrincipal,
                MinPrincipal = x.MinPrincipal,
                Step = x.Step
            }).ToListAsync();

            return products;
        }

        public async Task<Product> CreateProductAsync(CreateProductInputModel inputModel)
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
            return product;
        }

        public async Task<Product> GetProductByIdAsync(int id)
            => await this.dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<ProductType> GetProductTypeByIdAsync(int id)
            => await this.dbContext.ProductType.FirstOrDefaultAsync(x => x.Id == id);
    }
}