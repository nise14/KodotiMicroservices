using Catalog.Service.EventHandler.Commands;
using Catalog.Services.Queries;
using Catalog.Services.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;

namespace Catalog.Api.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("v1/products")]
public class ProductController : ControllerBase
{
    private readonly ILogger<DefaultController> _logger;
    private readonly IProductQueryService _productQueryService;
    private readonly IMediator _mediator;

    public ProductController(ILogger<DefaultController> logger,
        IProductQueryService productQueryService,
        IMediator mediator)
    {
        _logger = logger;
        _productQueryService = productQueryService;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<DataCollection<ProductDto>> GetAll(int page = 1, int take = 10, string? ids = null)
    {
        IEnumerable<int> products = null;

        if (!string.IsNullOrWhiteSpace(ids))
        {
            products = ids.Split(',').Select(x => Convert.ToInt32(x));
        }

        return await _productQueryService.GetAllAsync(page, take, products);
    }

    [HttpGet("{id}")]
    public async Task<ProductDto> Get(int id)
    {
        return await _productQueryService.GetAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateCommand command)
    {
        await _mediator.Publish(command);
        return Ok();
    }
}
