using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Specifications;
using AutoMapper;

namespace AlexaIOTInfraredRemoteAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<InfraredSignal> _signalRepository;

        public UserService(IMapper mapper, IGenericRepository<InfraredSignal> signalRepository)
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
        public async Task<InfraredSignal> CreateInfraredSignal(Guid userId, int length, int[] infraredData)
        {
            var user = await _signalRepository.GetByExternalId(userId);
            var infraredSignalToAdd = InfraredSignal.Create("N/A", infraredData, length, "N/A", DateTime.UtcNow);
            //user.AddInfraredSignal(infraredSignalToAdd);
            _signalRepository.Add(infraredSignalToAdd);
            await _signalRepository.SaveAsync();
            return infraredSignalToAdd;
        }
    }
}
