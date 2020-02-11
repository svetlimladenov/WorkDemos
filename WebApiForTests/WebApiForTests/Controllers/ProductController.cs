using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO.Product;
using WebApi.Services;

namespace WebApiForTests.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ProductServices productServices;

        public ProductController(ProductServices productServices)
        {
            this.productServices = productServices;
        }

        [HttpGet("AllProducts")]
        public List<ProductDTO> GetAllProducts()
        {
            var allProducts = this.productServices.GetAllProducts();
            return allProducts; 
        }

        [HttpPost("AddProductType")]
        public async Task<int> AddProductType(ProductTypeDTO productTypeDTO)
        {
            var id = await this.productServices.AddProductTypeAsync(productTypeDTO);
            return id;
        }

        [HttpPost("CreateProduct")]
        public async Task<int> CreateProduct(CreateProductInputModel inputModel)
        {
            var id = await this.productServices.CreateProductAsync(inputModel);
            return id;
        }
    }
}