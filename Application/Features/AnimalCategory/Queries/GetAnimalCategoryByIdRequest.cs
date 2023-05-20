﻿using Application.Service.Abstraction.Read;
using Ardalis.GuardClauses;
using Crosscuting.Api.DTOs.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.AnimalCategory.Queries
{
    /// <summary>
    /// Get AnimalCategory by identifier request implementation.
    /// </summary>
    public class GetAnimalCategoryByIdRequest : IRequest<ApiResponse<Domain.Support.AnimalCategory>>
    {
        public int Id { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id"></param>
        public GetAnimalCategoryByIdRequest(int id)
        {
            Id = id;
        }
    }


    /// <summary>
    /// Get AnimalCategory by identifier handler implementation.
    /// </summary>
    public class GetAnimalCategoryByIdRequestHandler : IRequestHandler<GetAnimalCategoryByIdRequest,
        ApiResponse<Domain.Support.AnimalCategory>>
    {
        private readonly ILogger<GetAnimalCategoryByIdRequestHandler> Logger;
        private readonly IAnimalCategoryRead AnimalCategoryRead;
        private const string ANIMAL_CATEGORY_NOT_FOUND = "AnimalCategory with id {0} not found.";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="animalCategoryRead"></param>
        public GetAnimalCategoryByIdRequestHandler(ILogger<GetAnimalCategoryByIdRequestHandler> logger,
            IAnimalCategoryRead animalCategoryRead)
        {
            Logger = logger;
            AnimalCategoryRead = animalCategoryRead;
        }

        ///<inheritdoc/>
        public async Task<ApiResponse<Domain.Support.AnimalCategory>> Handle(GetAnimalCategoryByIdRequest request,
            CancellationToken cancellationToken)
        {
            Logger.LogInformation($"GetAnimalCategoryByIdRequestHandler --> GetByIdAsync({request.Id}) --> Start");

            Guard.Against.Null(request, nameof(request));

            Domain.Support.AnimalCategory? result = await AnimalCategoryRead.GetByIdAsync(request.Id);

            if (result is null)
            {
                Logger.LogInformation($"GetAnimalCategoryByIdRequestHandler --> GetByIdAsync({request.Id}) --> Not Found");

                return new ApiResponse<Domain.Support.AnimalCategory>()
                {
                    Succeeded = false,
                    Message = string.Format(ANIMAL_CATEGORY_NOT_FOUND, request.Id),
                    Data = null
                };
            }

            Logger.LogInformation($"GetAnimalCategoryByIdRequestHandler --> GetByIdAsync --> End");

            return new ApiResponse<Domain.Support.AnimalCategory>(result);
        }
    }
}
