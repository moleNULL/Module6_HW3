using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesToDocker.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogTypeController : ControllerBase
{
    private readonly ILogger<CatalogTypeController> _logger;

    public CatalogTypeController(ILogger<CatalogTypeController> logger)
    {
        _logger = logger;
    }
}