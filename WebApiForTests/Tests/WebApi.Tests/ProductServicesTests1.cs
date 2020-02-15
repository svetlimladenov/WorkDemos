using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
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
            mockDbContext = new Mock<WebApiDbContext>();
            services = new ProductServices(mockDbContext.Object);
            var mockedProducts = new Mock<DbSet<Product>>();
            mockedProducts.Object.Add(new Product()
            {
                Name = "Credit",
                MaxPrincipal = 1000,
                MinPrincipal = 100,
                Step = 100
            });

            mockDbContext.Setup(x => x.Products).Returns(mockedProducts.Object);
        }

        [Fact]
        public void GetAllProducts_ShouldReturnAllActiveProducts()
        {
           
        }
    }
}
