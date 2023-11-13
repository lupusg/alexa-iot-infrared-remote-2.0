using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Specifications;
using AutoMapper;

namespace AlexaIOTInfraredRemoteAPI.Application.Services
{
    public class InfraredSignalService : IInfraredSignalService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<InfraredSignal> _signalRepository;

        public InfraredSignalService(IMapper mapper, IGenericRepository<InfraredSignal> signalRepository)
        {
            _mapper = mapper;
            _signalRepository = signalRepository;
        }
        public async Task<IReadOnlyList<InfraredSignal>> GetInfraredSignals(string sort)
        {
            var spec = new InfraredSignalsWithBasicInformation(sort);
            var infraredSignals = await _signalRepository.ListAsync(spec);
            return infraredSignals;
        }
    }
}
