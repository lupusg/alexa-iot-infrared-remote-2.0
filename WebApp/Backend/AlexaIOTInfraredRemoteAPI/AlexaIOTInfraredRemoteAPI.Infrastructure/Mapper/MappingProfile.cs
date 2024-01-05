using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.DTOs;
using AutoMapper;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<InfraredSignal, InfraredSignalDTO>();
        }
    }
}
