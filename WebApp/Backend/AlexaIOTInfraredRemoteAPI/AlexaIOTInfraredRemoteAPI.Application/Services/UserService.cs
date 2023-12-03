using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Helpers;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using AutoMapper;

namespace AlexaIOTInfraredRemoteAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IInfraredSignalRepository _infraredSignalRepository;

        public UserService(IMapper mapper, IUserRepository userRepository, IInfraredSignalRepository infraredSignalRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _infraredSignalRepository = infraredSignalRepository;
        }
        public async Task<IReadOnlyList<InfraredSignal>> GetInfraredSignals(string sort)
        {
            //var spec = new InfraredSignalsWithBasicInformation(sort);
            //var infraredSignals = await _userRepository.ListAsync(spec);
            //return infraredSignals;
            return null;
        }
        public async Task<InfraredSignal> CreateInfraredSignal(string clientId, string infraredDataRaw)
        {
            var board = await _userRepository.GetBoardByName(clientId);
            var infraredData = InfraredDataExtractor.ExtractRawData(infraredDataRaw);
            var infraredSignal = InfraredSignal.Create("N/A", infraredData, infraredData.Length, "N/A", DateTime.Now);
            
            board.AddInfraredSignal(infraredSignal);
            _infraredSignalRepository.Add(infraredSignal);

            await _infraredSignalRepository.SaveAsync();
            return infraredSignal;
        }
    }
}
