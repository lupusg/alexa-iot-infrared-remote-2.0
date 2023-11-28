using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using AutoMapper;

namespace AlexaIOTInfraredRemoteAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<IReadOnlyList<InfraredSignal>> GetInfraredSignals(string sort)
        {
            //var spec = new InfraredSignalsWithBasicInformation(sort);
            //var infraredSignals = await _userRepository.ListAsync(spec);
            //return infraredSignals;
            return null;
        }
        public async Task<InfraredSignal> CreateInfraredSignal(string clientId, int length, int[] infraredData)
        {
            var board = await _userRepository.GetBoard(clientId);

            //var user = await _userRepository.GetByExternalId(userId);
            //var infraredSignalToAdd = InfraredSignal.Create("N/A", infraredData, length, "N/A", DateTime.UtcNow);
            ////user.AddInfraredSignal(infraredSignalToAdd);
            //_userRepository.Add(infraredSignalToAdd);
            //await _userRepository.SaveAsync();
            //return infraredSignalToAdd;
            return null;
        }
    }
}
