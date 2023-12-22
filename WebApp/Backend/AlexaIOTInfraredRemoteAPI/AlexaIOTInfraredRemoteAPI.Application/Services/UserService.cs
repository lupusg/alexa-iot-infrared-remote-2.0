using System.Collections.ObjectModel;
using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Helpers;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Specifications;
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
        public async Task<IReadOnlyCollection<InfraredSignal>> GetInfraredSignals(Guid userId)
        {
            var user = await _userRepository.GetByExternalId(userId);
            var boards = user.Boards;
            var infraredSignals = new List<InfraredSignal>();
            foreach (var board in boards)
            {
                foreach (var infraredSignal in board.InfraredSignals)
                {
                    infraredSignals.Add(infraredSignal);
                }
            }
            return infraredSignals;
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

        public async Task<InfraredSignal> GetInfraredSignalByOutput(string clientId, string infraredSignalOutput)
        {
            var board = await _userRepository.GetBoardByName(clientId);
            var infraredSignal =
                board.InfraredSignals.First(signal => signal.IrSignalOutput.Equals(infraredSignalOutput));

            return infraredSignal;
        }
    }
}
