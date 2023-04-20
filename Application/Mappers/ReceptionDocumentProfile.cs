using Application.DTOs.ReceptionDocument;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    internal class ReceptionDocumentProfile : Profile
    {
        public ReceptionDocumentProfile()
        {
            CreateMap<ReceptionDocument, ReceptionDocumentForGet>();

            CreateMap<ReceptionDocumentForAdd, ReceptionDocument>()
                .ForMember(dest => dest.Id, src 
                                                                                        => src.MapFrom(src => Guid.NewGuid()));
        }
    }
}
