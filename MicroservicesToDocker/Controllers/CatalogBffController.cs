using System.Net;
using MicroservicesToDocker.Data.Entities;
using MicroservicesToDocker.Models.Dtos;
using MicroservicesToDocker.Models.Requests;
using MicroservicesToDocker.Models.Response;
using MicroservicesToDocker.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using MicroservicesToDocker.Data;

namespace MicroservicesToDocker.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogService _catalogService;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService)
    {
        _logger = logger;
        _catalogService = catalogService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Items(PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex);

        if (result is null)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetItemByResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(GetItemBadRequestResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetItemById(GetItemByIdRequest request)
    {
        var result = await _catalogService.GetItemById(request.Id);

        if (result is null)
        {
            return BadRequest(new GetItemBadRequestResponse<string>()
            {
                ResponseState = Enum.GetName(EntityModifyState.NotFound) !
            });
        }

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetItemByResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(GetItemBadRequestResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetItemByBrand(GetItemByBrandRequest request)
    {
        var result = await _catalogService.GetItemsByBrand(request.Brand);

        if (result is null)
        {
            return BadRequest(new GetItemBadRequestResponse<string>()
            {
                ResponseState = Enum.GetName(EntityModifyState.NotFound) !
            });
        }

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetItemByResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(GetItemBadRequestResponse<string>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetItemByType(GetItemByTypeRequest request)
    {
        var result = await _catalogService.GetItemsByTypeAsync(request.Type);

        if (result is null)
        {
            return BadRequest(new GetItemBadRequestResponse<string>()
            {
                ResponseState = Enum.GetName(EntityModifyState.NotFound) !
            });
        }

        return Ok(result);
    }
}