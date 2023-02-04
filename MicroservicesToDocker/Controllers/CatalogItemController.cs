using System.Net;
using MicroservicesToDocker.Models.Requests;
using MicroservicesToDocker.Models.Response;
using MicroservicesToDocker.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroservicesToDocker.Data;

namespace MicroservicesToDocker.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogItemController : ControllerBase
{
    private readonly ILogger<CatalogItemController> _logger;
    private readonly ICatalogItemService _catalogItemService;

    public CatalogItemController(
        ILogger<CatalogItemController> logger,
        ICatalogItemService catalogItemService)
    {
        _logger = logger;
        _catalogItemService = catalogItemService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Add(CreateProductRequest request)
    {
        var result = await _catalogItemService.Add(request.Name, request.Description, request.Price, request.AvailableStock, request.CatalogBrandId, request.CatalogTypeId, request.PictureFileName);

        if (result is null)
        {
            return BadRequest(new AddItemResponse<int?>() { Id = result });
        }

        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(RemoveItemResponse<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(RemoveItemResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Remove(RemoveProductRequest request)
    {
        var result = await _catalogItemService.Remove(request.Id);

        if (result == EntityModifyState.NotFound)
        {
            return BadRequest(new RemoveItemResponse<string>() { RemoveState = Enum.GetName(result) });
        }

        return Ok(new RemoveItemResponse<string>() { RemoveState = Enum.GetName(result) });
    }

    [HttpPost]
    [ProducesResponseType(typeof(EntityModifyState), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(UpdateProductRequest request)
    {
        var result = await _catalogItemService.Update(request.Id, request.Name, request.Description, request.Price, request.AvailableStock, request.CatalogBrandId, request.CatalogTypeId, request.PictureFileName);

        if (result == EntityModifyState.NotFound || result == EntityModifyState.NotUpdated)
        {
            return BadRequest(new UpdateItemResponse<string>() { UpdateState = Enum.GetName(result) });
        }

        return Ok(new UpdateItemResponse<string>() { UpdateState = Enum.GetName(result) });
    }
}