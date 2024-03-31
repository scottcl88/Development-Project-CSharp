using Application.Requests;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Web.Controllers;

[Route("api/v1/products")]
public class ProductController : Controller
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    //get all products
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _productService.GetProductsAsync();
        return Ok(products);
    }
    //search products by name
    [HttpGet("search-name")]
    public async Task<IActionResult> SearchProducts([FromQuery] string query)
    {
        var products = await _productService.SearchProductsAsync(query);
        return Ok(products);
    }
    //search products by category
    [HttpGet("search-category")]
    public async Task<IActionResult> SearchProductsByCategory([FromQuery] string category)
    {
        var products = await _productService.SearchProductsByCategoryAsync(category);
        return Ok(products);
    }
    //get product by id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
    //create product
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] AddProductRequest request)
    {
        if (request == null)
        {
            return BadRequest();
        }
        var productModel = await _productService.AddProductAsync(request);
        return CreatedAtAction(nameof(GetProductById), new { id = productModel.Id }, productModel);
    }
    //update product
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductRequest request)
    {
        if (request == null || request.Id != id)
        {
            return BadRequest();
        }
        var existingProduct = await _productService.GetProductByIdAsync(id);
        if (existingProduct == null)
        {
            return NotFound();
        }
        await _productService.UpdateProductAsync(request);
        return NoContent();
    }
}
