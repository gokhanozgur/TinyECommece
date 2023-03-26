using System.Net;
using Microsoft.AspNetCore.Mvc;
using TinyECommerce.Application.Repositories;
using TinyECommerce.Application.ViewModels.Products;
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
    
    [HttpGet]
    [ProducesResponseType(typeof(int), (int)(HttpStatusCode.OK))]
    [ProducesResponseType((int)(HttpStatusCode.BadRequest))]
    public async Task<IActionResult> Get()
    {
        return Ok(_productReadRepository.GetAll(false));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(int), (int)(HttpStatusCode.OK))]
    [ProducesResponseType((int)(HttpStatusCode.BadRequest))]
    public async Task<IActionResult> Get(string id)
    {
        Product product = await _productReadRepository.GetByIdAsync(id, false);
        return Ok(product);
    }

    [HttpPost]
    [ProducesResponseType(typeof(int), (int)(HttpStatusCode.OK))]
    [ProducesResponseType((int)(HttpStatusCode.BadRequest))]
    public async Task<IActionResult> Add(VM_Create_Product model)
    {
        await _productWriteRepository.AddAsync(new Product()
        {
            Name = model.Name,
            Stock = model.Stock,
            Price = model.Price
        });
        await _productWriteRepository.SaveAsync();
        return Ok();
    }
    
    [HttpPut]
    [ProducesResponseType(typeof(int), (int)(HttpStatusCode.OK))]
    [ProducesResponseType((int)(HttpStatusCode.BadRequest))]
    public async Task<IActionResult> Put(VM_Update_Product model)
    {
        Product product = await _productReadRepository.GetByIdAsync(model.Id);
        product.Name = model.Name;
        product.Stock = model.Stock;
        product.Price = model.Price;
        await _productWriteRepository.SaveAsync();
        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(int), (int)(HttpStatusCode.OK))]
    [ProducesResponseType((int)(HttpStatusCode.BadRequest))]
    public async Task<IActionResult> Delete(string id)
    {
        await _productWriteRepository.RemoveAsync(id);
        await _productWriteRepository.SaveAsync();
        return Ok();
    }
}