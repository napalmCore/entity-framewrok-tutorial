using EFTuto.Models;
using EFTuto.Services;
using Xunit;
using Moq;
using EFTuto.Repositories;

namespace Tests
{
    public class ProductServiceTest
    {
        [Fact]
        public void GetProducts_ShouldReturnAllProducts()
        {
            //Arrange
            var moq = new Mock<IProductRepository>();
            moq.Setup(x => x.GetProducts()).Returns(new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10 },
                new Product { Id = 2, Name = "Product 2", Price = 20 },
                new Product { Id = 3, Name = "Product 3", Price = 30 }
            });
            var productService = new ProductService(moq.Object);
            
            //Act

            var products = productService.GetProducts();


            Assert.Equal(3, products.Count());
        }

        [Fact]
        public void GetProductById_ShouldReturnProduct()
        {
            //Arrange
            var moq = new Mock<IProductRepository>();
            moq.Setup(x => x.GetProductById(1)).Returns(new Product { Id = 1, Name = "Product 1", Price = 10 });
            var productService = new ProductService(moq.Object);

            //Act
            var product = productService.GetProductById(1);

            //Assert
            Assert.Equal(1, product.Id);
        }

        [Fact]
        public void AddProduct_ShouldAddProduct()
        {
            //Arrange
            var moq = new Mock<IProductRepository>();
            var productService = new ProductService(moq.Object);
            var product = new Product { Id = 1, Name = "Product 1", Price = 10 };

            //Act
            productService.AddProduct(product);

            //Assert
            moq.Verify(x => x.AddProduct(product), Times.Once);
        }

        [Fact]
        public void UpdateProduct_ShouldUpdateProduct()
        {
            //Arrange
            var moq = new Mock<IProductRepository>();
            var productService = new ProductService(moq.Object);
            var product = new Product { Id = 1, Name = "Product 1", Price = 10 };

            //Act
            productService.UpdateProduct(product);

            //Assert
            moq.Verify(x => x.UpdateProduct(product), Times.Once);
        }
    }
}