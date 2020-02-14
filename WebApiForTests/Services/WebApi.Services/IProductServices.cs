using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.DTO.Product;

namespace WebApi.Services
{
    public interface IProductServices
    {
        Task<ProductType> AddProductTypeAsync(ProductTypeDTO inputModel);

        Task<List<ProductDTO>> GetAllProductsAsync();

        Task<Product> CreateProductAsync(CreateProductInputModel inputModel);

        Task<Product> GetProductByIdAsync(int id);

        Task<ProductType> GetProductTypeByIdAsync(int id);
    }
}
