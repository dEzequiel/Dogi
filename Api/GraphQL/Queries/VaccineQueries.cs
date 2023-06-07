using Application.Features.Vaccine.Queries;
using Domain.Entities;
using Domain.Enums.Shelter;
using MediatR;

namespace Api.GraphQL.Queries;

public class VaccineQueries
{
    private readonly ILogger<VaccineQueries> _logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="logger"></param>
    public VaccineQueries(ILogger<VaccineQueries> logger)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<Vaccine>> GetAllByAnimalCategory([Service] ISender mediator,
        AnimalCategories? category,
        CancellationToken ct = default)
    {
        try
        {
            var result = await mediator.Send(new GetAllVaccinesByAnimalCategoryRequest((int)category), ct);

            return result.Data;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}