using Interview.Web.Controllers;
using Application.Requests;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Models;

namespace Tests
{
    [TestClass]
    public class ProductControllerTests
    {
        private Mock<IProductService>? _mockProductService;
        private ProductController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockProductService = new Mock<IProductService>();
            _controller = new ProductController(_mockProductService.Object);
        }

        [TestMethod]
        public async Task GetProducts_ReturnsOkResult_WithListOfProducts()
        {
            // Arrange
            _mockProductService?.Setup(service => service.GetProductsAsync())
                .ReturnsAsync(new List<ProductModel>());

            // Act
            var result = await _controller.GetProducts();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetProductById_ReturnsNotFound_WhenProductDoesNotExist()
        {
            // Arrange
            _mockProductService?.Setup(service => service.GetProductByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((ProductModel)null);

            // Act
            var result = await _controller.GetProductById(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task CreateProduct_ReturnsBadRequest_WhenRequestIsNull()
        {
            // Act
            var result = await _controller.CreateProduct(null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public async Task UpdateProduct_ReturnsBadRequest_WhenRequestIsNull()
        {
            // Act
            var result = await _controller.UpdateProduct(1, null);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}
