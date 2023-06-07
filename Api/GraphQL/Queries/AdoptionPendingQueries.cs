using Application.Features.AdoptionPending.Queries;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Adoption;
using Domain.Enums.Adoption;
using MediatR;

namespace Api.GraphQL.Queries;

public class AdoptionPendingQueries
{
    private readonly ILogger<AdoptionPendingQueries> _logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    public AdoptionPendingQueries(ILogger<AdoptionPendingQueries> logger)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<AdoptionPending>> GetAllAdoptionPendingByStatus([Service] ISender mediator,
        AdoptionPendingStatuses status, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("AdoptionPendingQueries --> GetAllAdoptionPendingByStatus --> Start");

            var result = await mediator.Send(new GetAllAdoptionPendingsByStatusIdRequest((int)status));

            _logger.LogInformation("AdoptionPendingQueries --> GetAllAdoptionPendingByStatus --> End");

            return result.Data;
        }
        catch (DogiException ex)
        {
            _logger.LogInformation("IndividualProceedingQueries --> GetAllByStatus --> Error");

            throw new DogiException(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogInformation("IndividualProceedingQueries --> GetAllByStatus --> Error");
            throw new DogiException(ex.Message);
        }
    }
}