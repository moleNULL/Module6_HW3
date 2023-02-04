using System.Net;
using Infrastructure;
using MicroservicesToDocker.Data;
using MicroservicesToDocker.Models.Requests;
using MicroservicesToDocker.Models.Response;
using MicroservicesToDocker.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesToDocker.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogTypeController : ControllerBase
{
    private readonly ILogger<CatalogTypeController> _logger;
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogTypeController(ILogger<CatalogTypeController> logger, ICatalogTypeService catalogTypeService)
    {
        _logger = logger;
        _catalogTypeService = catalogTypeService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddTypeResponse<int?>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(AddTypeResponse<int?>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Add(CreateTypeRequest request)
    {
        var result = await _catalogTypeService.Add(request.Type);

        if (result is null)
        {
            return BadRequest(new AddItemResponse<int?>() { Id = result });
        }

        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(RemoveTypeResponse<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(RemoveTypeResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Remove(RemoveTypeRequest request)
    {
        var result = await _catalogTypeService.Remove(request.Id);

        if (result == EntityModifyState.NotFound)
        {
            return BadRequest(new RemoveTypeResponse<string>() { RemoveState = Enum.GetName(result) });
        }

        return Ok(new RemoveTypeResponse<string>() { RemoveState = Enum.GetName(result) });
    }

    [HttpPost]
    [ProducesResponseType(typeof(UpdateTypeResponse<string>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(UpdateTypeResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Update(UpdateTypeRequest request)
    {
        var result = await _catalogTypeService.Update(request.Id, request.Type);

        if (result == EntityModifyState.NotFound || result == EntityModifyState.NotUpdated)
        {
            return BadRequest(new UpdateTypeResponse<string>() { UpdateState = Enum.GetName(result) });
        }

        return Ok(new UpdateTypeResponse<string>() { UpdateState = Enum.GetName(result) });
    }
}