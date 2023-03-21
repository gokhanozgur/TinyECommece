using System.Net;
using Microsoft.AspNetCore.Mvc;
using TinyECommerce.Application.Repositories;
using TinyECommerce.Domain.Entities;
using TinyECommerce.Persistence.Repositories;

namespace TinyECommerce.API.V1.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class ProductsController: ControllerBase
{
    readonly private IProductReadRepository _productReadRepository;
    readonly private IProductWriteRepository _productWriteRepository;
    
    public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }
    
    // @todo product operation endpoints here.

    [HttpGet]
    [ProducesResponseType(typeof(int), (int)(HttpStatusCode.OK))]
    [ProducesResponseType((int)(HttpStatusCode.BadRequest))]
    public async Task<IActionResult> Add()
    {
        await _productWriteRepository.AddAsync(new Product()
        {
            Name = "Keyboard",
            Price = 120,
            Stock = 800
        });
        _productWriteRepository.SaveAsync();
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        Product product = await _productReadRepository.GetByIdAsync(id);
        return Ok(product);
    }
}