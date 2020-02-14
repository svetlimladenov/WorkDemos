using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Services;
using WebApiForTests.Controllers;
using Xunit;

namespace WebApi.Tests
{
    public class ProductControllerTest
    {
        private readonly Mock<IProductServices> productServicesMock;
        private readonly ProductController productController;
        public ProductControllerTest()
        {
            this.productServicesMock = new Mock<IProductServices>(MockBehavior.Loose);
            this.productServicesMock
                .Setup(x => x.GetProductByIdAsync(It.Is<int>(x => x == 1)))
                .ReturnsAsync(
                new Product()
                { 
                    Id = 1, 
                    MaxPrincipal = 1000, 
                    MinPrincipal = 100, 
                    Step = 100, 
                    Name = "Test" 
                });
            this.productController = new ProductController(productServicesMock.Object);
        }

        [Fact]
        public async Task Get_ProductById_ShouldReturnOkIfValidId()
        {
            //act
            var result = await this.productController.GetProductById(1);

            //assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public async Task Get_ProductById_ShouldReturnNotFoundIfInvalidId()
        {
            //act
            var result = await this.productController.GetProductById(99);

            //assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Get_ProductById_ShouldReturnValidProduct()
        {
            //act
            var result = await this.productController.GetProductById(1);


            var expected = new Product()
            {
                Id = 1,
                MaxPrincipal = 1000,
                MinPrincipal = 100,
                Step = 100,
                Name = "Test"
            };
            //assert
            Assert.True(expected.Equals(resu));
        }
    }
}
