using Microsoft.AspNetCore.Mvc;
using TinyECommerce.Application.Abstractions;

namespace TinyECommerce.API.V1.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class ProductsController: ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _productService.GetProducts();
        return Ok(products);
    }
}