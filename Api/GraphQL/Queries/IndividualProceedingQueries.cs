using Application.Features.IndividualPro.Queries;
using Crosscuting.Base.Exceptions;
using Domain.Entities.Shelter;
using Domain.Enums.Shelter;
using MediatR;

namespace Api.GraphQL.Queries;

public class IndividualProceedingQueries
{
    private readonly ILogger<IndividualProceedingQueries> _logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    public IndividualProceedingQueries(ILogger<IndividualProceedingQueries> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get all individual proceeding filter by status.
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="status"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    /// <exception cref="DogiException"></exception>
    public async Task<IEnumerable<IndividualProceeding>> GetAllByStatus([Service] ISender mediator,
        IndividualProceedingStatuses status, CancellationToken ct = default)
    {
        try
        {
            _logger.LogInformation("IndividualProceedingQueries --> GetAllByStatus --> Start");

            var result = await mediator.Send(new GetIndividualProceedingByStatusRequest((int)status), ct);

            _logger.LogInformation("IndividualProceedingQueries --> GetAllByStatus --> End");

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