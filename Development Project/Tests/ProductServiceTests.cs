using Domain;
using Application.Models;
using Application.Requests;
using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests;

[TestClass]
public class ProductServiceTests
{
    private Mock<IProductRepository> _mockProductRepository;
    private Mock<IMapper> _mockMapper;
    private ProductService _service;

    [TestInitialize]
    public void Setup()
    {
        _mockProductRepository = new Mock<IProductRepository>();
        _mockMapper = new Mock<IMapper>();
        _service = new ProductService(_mockProductRepository.Object, _mockMapper.Object);
    }

    [TestMethod]
    public async Task SearchProductsAsync_ReturnsListOfProducts()
    {
        // Arrange
        _mockProductRepository.Setup(repo => repo.GetProductsAsync())
            .ReturnsAsync(new List<ProductEntity>());
        _mockMapper.Setup(mapper => mapper.Map<List<ProductModel>>(It.IsAny<List<ProductEntity>>()))
            .Returns(new List<ProductModel>());

        // Act
        var result = await _service.SearchProductsAsync("query");

        // Assert
        Assert.IsInstanceOfType(result, typeof(List<ProductModel>));
    }

    [TestMethod]
    public async Task SearchProductsByCategoryAsync_ReturnsListOfProducts()
    {
        // Arrange
        _mockProductRepository.Setup(repo => repo.GetProductsAsync())
            .ReturnsAsync(new List<ProductEntity>());
        _mockMapper.Setup(mapper => mapper.Map<List<ProductModel>>(It.IsAny<List<ProductEntity>>()))
            .Returns(new List<ProductModel>());

        // Act
        var result = await _service.SearchProductsByCategoryAsync("category");

        // Assert
        Assert.IsInstanceOfType(result, typeof(List<ProductModel>));
    }

    [TestMethod]
    public async Task GetProductByIdAsync_ReturnsProductModel_WhenProductExists()
    {
        // Arrange
        _mockProductRepository.Setup(repo => repo.GetProductByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new ProductEntity() { CreatedAt = DateTime.Now, CreatedBy = "test", Name = "testProduct" });
        _mockMapper.Setup(mapper => mapper.Map<ProductModel>(It.IsAny<ProductEntity>()))
            .Returns(new ProductModel() { CreatedAt = DateTime.Now, CreatedBy = "test", Name = "testProduct" });

        // Act
        var result = await _service.GetProductByIdAsync(1);

        // Assert
        Assert.IsInstanceOfType(result, typeof(ProductModel));
    }

    [TestMethod]
    public async Task GetProductsAsync_ReturnsListOfProducts()
    {
        // Arrange
        _mockProductRepository.Setup(repo => repo.GetProductsAsync())
            .ReturnsAsync(new List<ProductEntity>());
        _mockMapper.Setup(mapper => mapper.Map<List<ProductModel>>(It.IsAny<List<ProductEntity>>()))
            .Returns(new List<ProductModel>());

        // Act
        var result = await _service.GetProductsAsync();

        // Assert
        Assert.IsInstanceOfType(result, typeof(List<ProductModel>));
    }

    [TestMethod]
    public async Task AddProductAsync_ReturnsProductModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new AddProductRequest() { Name = "testProduct" };
        _mockMapper.Setup(mapper => mapper.Map<ProductEntity>(It.IsAny<AddProductRequest>()))
            .Returns(new ProductEntity() { CreatedAt = DateTime.Now, CreatedBy = "test", Name = "testProduct" });
        _mockProductRepository.Setup(repo => repo.CreateProductAsync(It.IsAny<ProductEntity>()))
            .ReturnsAsync(new ProductEntity() { CreatedAt = DateTime.Now, CreatedBy = "test", Name = "testProduct" });
        _mockMapper.Setup(mapper => mapper.Map<ProductModel>(It.IsAny<ProductEntity>()))
            .Returns(new ProductModel() { CreatedAt = DateTime.Now, CreatedBy = "test", Name = "testProduct" });

        // Act
        var result = await _service.AddProductAsync(request);

        // Assert
        Assert.IsInstanceOfType(result, typeof(ProductModel));
    }

    [TestMethod]
    public async Task UpdateProductAsync_ReturnsProductModel_WhenRequestIsValid()
    {
        // Arrange
        var request = new UpdateProductRequest() { Id = 1, Name = "testProduct" };
        _mockMapper.Setup(mapper => mapper.Map<ProductEntity>(It.IsAny<UpdateProductRequest>()))
            .Returns(new ProductEntity() { CreatedAt = DateTime.Now, CreatedBy = "test", Name = "testProduct" });
        _mockProductRepository.Setup(repo => repo.UpdateProductAsync(It.IsAny<ProductEntity>()))
            .ReturnsAsync(new ProductEntity() { CreatedAt = DateTime.Now, CreatedBy = "test", Name = "testProduct" });
        _mockMapper.Setup(mapper => mapper.Map<ProductModel>(It.IsAny<ProductEntity>()))
            .Returns(new ProductModel() { CreatedAt = DateTime.Now, CreatedBy = "test", Name = "testProduct" });

        // Act
        var result = await _service.UpdateProductAsync(request);

        // Assert
        Assert.IsInstanceOfType(result, typeof(ProductModel));
    }
}
