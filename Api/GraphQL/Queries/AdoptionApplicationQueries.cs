using Application.Features.AdoptionApplication.Queries;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Adoption;
using MediatR;

namespace Api.GraphQL.Queries;

public class AdoptionApplicationQueries
{
    private readonly ILogger<AdoptionApplicationQueries> _logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    public AdoptionApplicationQueries(ILogger<AdoptionApplicationQueries> logger)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<AdoptionApplication>> GetAllAdoptionApplicationsByAdoptionPendingId(
        [Service] ISender mediator,
        Guid adoptionPendingId, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("AdoptionPendingQueries --> GetAllAdoptionPendingByStatus --> Start");

            var result = await mediator.Send(new GetAllAdoptionApplicationByAdoptionPendingIdRequest(adoptionPendingId),
                ct);

            _logger.LogInformation(
                "AdoptionApplicationQueries --> GetAllAdoptionApplicationsByAdoptionPendingId --> End");

            return result.Data;
        }
        catch (DogiException ex)
        {
            _logger.LogInformation(
                "AdoptionApplicationQueries --> GetAllAdoptionApplicationsByAdoptionPendingId --> Error");

            throw new DogiException(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(
                "AdoptionApplicationQueries --> GetAllAdoptionApplicationsByAdoptionPendingId --> Error");
            throw new DogiException(ex.Message);
        }
    }
}