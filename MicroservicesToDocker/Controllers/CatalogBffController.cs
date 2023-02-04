using System.Net;
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
    private readonly ICatalogService _catalogService;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> ItemsAsync(PaginatedItemsRequest request)
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
    public async Task<IActionResult> GetItemByIdAsync(GetItemByIdRequest request)
    {
        var result = await _catalogService.GetItemByIdAsync(request.Id);

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
    public async Task<IActionResult> GetItemByBrandAsync(GetItemByBrandRequest request)
    {
        var result = await _catalogService.GetItemsByBrandAsync(request.Brand);

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
    public async Task<IActionResult> GetItemByTypeAsync(GetItemByTypeRequest request)
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

    [HttpPost]
    [ProducesResponseType(typeof(GetBrandsResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBrandsAsync()
    {
        var result = await _catalogService.GetBrandsAsync();

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetTypesResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetTypesAsync()
    {
        var result = await _catalogService.GetTypesAsync();

        return Ok(result);
    }
}