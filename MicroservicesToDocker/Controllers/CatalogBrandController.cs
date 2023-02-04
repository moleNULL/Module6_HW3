using System.Net;
using Infrastructure;
using MicroservicesToDocker.Models.Requests;
using MicroservicesToDocker.Models.Response;
using MicroservicesToDocker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MicroservicesToDocker.Data;

namespace MicroservicesToDocker.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBrandController : ControllerBase
{
    private readonly ILogger<CatalogBrandController> _logger;
    private readonly ICatalogBrandService _catalogBrandService;

    public CatalogBrandController(ILogger<CatalogBrandController> logger, ICatalogBrandService catalogBrandService)
    {
        _logger = logger;
        _catalogBrandService = catalogBrandService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddBrandResponse<int?>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(AddBrandResponse<int?>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Add(CreateBrandRequest request)
    {
        var result = await _catalogBrandService.Add(request.Brand);

        if (result is null)
        {
            return BadRequest(new AddBrandResponse<int?>() { Id = result });
        }

        return Ok(new AddBrandResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(RemoveBrandResponse<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(RemoveBrandResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Remove(RemoveBrandRequest request)
    {
        var result = await _catalogBrandService.Remove(request.Id);

        if (result == Data.EntityModifyState.NotFound)
        {
            return BadRequest(new RemoveBrandResponse<string>() { RemoveState = Enum.GetName(result) });
        }

        return Ok(new RemoveBrandResponse<string>() { RemoveState = Enum.GetName(result) });
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateBrandResponse<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UpdateBrandResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(UpdateBrandRequest request)
    {
        var result = await _catalogBrandService.Update(request.Id, request.Brand);

        if (result == EntityModifyState.NotFound || result == EntityModifyState.NotUpdated)
        {
            return BadRequest(new UpdateBrandResponse<string>() { UpdateState = Enum.GetName(result) });
        }

        return Ok(new UpdateBrandResponse<string>() { UpdateState = Enum.GetName(result) });
    }
}