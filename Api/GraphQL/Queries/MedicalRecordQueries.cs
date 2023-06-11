using Application.Features.MedicalRecord.Queries;
using Domain.Entities;
using Domain.Enums.Veterinary;
using MediatR;

namespace Api.GraphQL.Queries;

public class MedicalRecordQueries
{
    private IMediator Mediator { get; set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="mediator"></param>
    public MedicalRecordQueries(IMediator mediator)
    {
        Mediator = mediator;
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    public MedicalRecordQueries()
    {
    }

    /// <summary>
    /// Get all medical records filter by status.
    /// </summary>
    /// <param name="Mediator"></param>
    /// <param name="status"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public async Task<IEnumerable<MedicalRecord>> GetAllByStatus([Service] ISender Mediator,
        MedicalRecordStatuses status,
        CancellationToken ct = default)
    {
        try
        {
            var result = await Mediator.Send(new GetAllMedicalRecordByStatusRequest((int)status), ct);

            return result.Data;
        }
        catch (Exception ex)
        {
            throw new ArgumentException(ex.Message);
        }
    }
}