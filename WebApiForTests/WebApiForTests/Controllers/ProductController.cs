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
        private readonly IProductServices productServices;

        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        [HttpGet("AllProducts")]
        public async Task<IEnumerable<ProductDTO>> GetAllProducts()
        {
            var allProducts = await this.productServices.GetAllProductsAsync();
            return allProducts; 
        }

        [HttpPost("AddProductType")]
        public async Task<ActionResult> AddProductType(ProductTypeDTO productTypeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productType = await this.productServices.AddProductTypeAsync(productTypeDTO);
            return CreatedAtAction(nameof(GetProductTypeById), new { id = productType.Id }, productType);
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult> CreateProduct(CreateProductInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await this.productServices.CreateProductAsync(inputModel);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpGet("GetProduct/{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await this.productServices.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            //TODO: Use automapper
            var dto = new ProductDTO()
            {
                Name = product.Name,
                MaxPrincipal = product.MaxPrincipal,
                MinPrincipal = product.MinPrincipal,
                ProductTypeId = product.ProductTypeId,
                Step = product.Step
            };
            return Ok(dto);
        }

        [HttpGet("GetProductType/{id}")]
        public async Task<ActionResult<ProductTypeDTO>> GetProductTypeById(int id)
        {
            var productType = await this.productServices.GetProductTypeByIdAsync(id);

            if (productType == null)
            {
                return NotFound();
            }
            //TODO: Use automapper
            var dto = new ProductTypeDTO()
            {
                Name = productType.Name,
            };

            return dto;
        }
    }
}