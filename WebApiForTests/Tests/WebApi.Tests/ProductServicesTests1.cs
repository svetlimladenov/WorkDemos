using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Data;
using WebApi.Services;
using Xunit;

namespace WebApi.Tests
{
    public class ProductServicesTests
    {
        private readonly ProductServices services;
        private Mock<WebApiDbContext> mockDbContext;
        private ProductsMockObjectGenerator productsMockObjectGenerator;
        public ProductServicesTests()
        {
            services = new ProductServices(mockDbContext.Object);
            mockDbContext.Setup(x => x.Products).Returns(new Mock<List<Product>() >);
        }

        [Fact]
        public void GetAllProducts_ShouldReturnAllActiveProducts()
        {
            //act
            this.services.GetAllProducts();
        }
    }
}
