using Application.Models;
using Application.Requests;
using AutoMapper;
using Infrastructure;
using Infrastructure.Entities;

namespace Domain;
public interface IProductService
{
    Task<List<ProductModel>> SearchProductsAsync(string query);
    Task<List<ProductModel>> SearchProductsByCategoryAsync(string category);
    Task<ProductModel> GetProductByIdAsync(int id);
    Task<List<ProductModel>> GetProductsAsync();
    Task<ProductModel> AddProductAsync(AddProductRequest request);
    Task<ProductModel> UpdateProductAsync(UpdateProductRequest request);
}
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<List<ProductModel>> SearchProductsByCategoryAsync(string category)
    {
        var products = await _productRepository.GetProductsAsync();
        products = products.Where(p => p.Categories.Any(c => c.Name == category)).ToList();
        return _mapper.Map<List<ProductModel>>(products);
    }
    public async Task<List<ProductModel>> SearchProductsAsync(string query)
    {
        var products = await _productRepository.GetProductsAsync();
        products = products.Where(p => p.Name.Contains(query)).ToList();
        return _mapper.Map<List<ProductModel>>(products);
    }
    public async Task<ProductModel> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);
        return _mapper.Map<ProductModel>(product);
    }
    public async Task<List<ProductModel>> GetProductsAsync()
    {
        var products = await _productRepository.GetProductsAsync();
        return _mapper.Map<List<ProductModel>>(products);
    }
    public async Task<ProductModel> AddProductAsync(AddProductRequest request)
    {
        var product = _mapper.Map<ProductEntity>(request);
        var addedProduct = await _productRepository.CreateProductAsync(product);
        return _mapper.Map<ProductModel>(addedProduct);
    }
    public async Task<ProductModel> UpdateProductAsync(UpdateProductRequest request)
    {
        var product = _mapper.Map<ProductEntity>(request);
        var updatedProduct = await _productRepository.UpdateProductAsync(product);
        return _mapper.Map<ProductModel>(updatedProduct);
    }
}