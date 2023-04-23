using Application.DTOs.ReceptionDocument;
using Application.Features.ReceptionDocument.Queries;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1.0/receptionDocument")]
public class ReceptionDocumentController : ControllerBase
{
    private readonly ILogger<ReceptionDocumentController> _logger;
    private readonly IMediator _mediator;
    
    public ReceptionDocumentController(ILogger<ReceptionDocumentController> logger, IMediator mediator)
    {
        _logger = Guard.Against.Null(logger, nameof(logger));
        _mediator = Guard.Against.Null(mediator, nameof(mediator));
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponse<ReceptionDocumentForGet>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken ct)
    {
        var result = await _mediator.Send(new GetReceptionDocumentByIdRequest(id), ct);

        if (!result.Succeeded)
        {
            return NotFound(new ApiResponse<ReceptionDocumentForGet>("not found"));
        }

        return Ok(result);
    }
}