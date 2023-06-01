using Application.Features.MedicalRecord.Queries;
using Domain.Entities;
using HotChocolate.Authorization;
using MediatR;

namespace Api.GraphQL.GraphQLQueries;

public class VeterinaryManagerQueries
{
    public IMediator Mediator { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="mediator"></param>
    public VeterinaryManagerQueries(IMediator mediator)
    {
        Mediator = mediator;
    }
    /// <summary>
    /// Constructor
    /// </summary>
    public VeterinaryManagerQueries()
    {
    }

    /// <summary>
    /// Get all Medical records filtered by status.
    /// </summary>
    /// <param name="Mediator"></param>
    /// <param name="status"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [Authorize]
    public async Task<IEnumerable<MedicalRecord>> GetAllByStatus([Service] ISender Mediator, int status,
        CancellationToken ct = default)
    {
        try
        {
            var result = await Mediator.Send(new GetAllMedicalRecordByStatusRequest(status), ct);

            return result.Data;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }

    /// <summary>
    /// Get all Medical records.
    /// </summary>
    /// <param name="Mediator"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public async Task<IEnumerable<MedicalRecord>> GetAllAsync([Service] ISender Mediator, CancellationToken ct = default)
    {
        try
        {
            var result = await Mediator.Send(new GetAllMedicalRecordRequest(), ct);

            return result.Data;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}