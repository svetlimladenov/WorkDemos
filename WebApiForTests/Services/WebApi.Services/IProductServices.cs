using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.DTO.Product;

namespace WebApi.Services
{
    interface IProductServices
    {
        Task<int> AddProductTypeAsync(ProductTypeDTO inputModel);

        List<ProductDTO> GetAllProducts();

        Task<int> CreateProductAsync(CreateProductInputModel inputModel);
    }
}
