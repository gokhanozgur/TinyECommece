using System.Net;
using Microsoft.AspNetCore.Mvc;
using TinyECommerce.Application.Repositories;
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
    public async Task<IActionResult> Get()
    {
        try
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() {Id = Guid.NewGuid(), Name = "Product 1", Price = 100, Stock = 10, CreatedAt = DateTime.UtcNow},
                new() {Id = Guid.NewGuid(), Name = "Product 2", Price = 200, Stock = 20, CreatedAt = DateTime.UtcNow},
                new() {Id = Guid.NewGuid(), Name = "Product 3", Price = 300, Stock = 30, CreatedAt = DateTime.UtcNow},
            });
            var count = await _productWriteRepository.SaveAsync();
            if (count > 0)
            {
                return Ok(count);
            }
            return BadRequest();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}