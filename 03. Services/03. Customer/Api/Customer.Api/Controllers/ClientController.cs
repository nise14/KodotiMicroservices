using Customer.Service.EventHandlers.Commands;
using Customer.Service.Queries;
using Customer.Service.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;

namespace Customer.Api.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("v1/clients")]
public class ClientController : ControllerBase
{
    private readonly IClientQueryService _clientQueryService;
    private readonly ILogger<ClientController> _logger;
    private readonly IMediator _mediator;

    public ClientController(ILogger<ClientController> logger,
        IMediator mediator,
        IClientQueryService clientQueryService)
    {
        _logger = logger;
        _clientQueryService = clientQueryService;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<DataCollection<ClientDto>> GetAll(
            int page = 1, int take = 10, string? ids = null)
    {
        IEnumerable<int> clients = null;
        if (!string.IsNullOrWhiteSpace(ids))
        {
            clients = ids.Split(',').Select(x => Convert.ToInt32(x));
        }

        return await _clientQueryService.GetAllAsync(page, take, clients);
    }

    [HttpGet("{id}")]
    public async Task<ClientDto> Get(int id)
    {
        return await _clientQueryService.GetAsync(id);
    }

    public async Task<IActionResult> Create(ClientCreateCommand notification)
    {
        await _mediator.Publish(notification);
        return Ok();
    }
}
