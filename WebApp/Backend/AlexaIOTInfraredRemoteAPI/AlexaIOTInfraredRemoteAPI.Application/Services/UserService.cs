using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.DTOs;
using AlexaIOTInfraredRemoteAPI.Domain.Exceptions;
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
        private readonly IBoardRepository _boardRepository;

        public UserService(
            IMapper mapper,
            IUserRepository userRepository,
            IInfraredSignalRepository infraredSignalRepository,
            IBoardRepository boardRepository
            )
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _infraredSignalRepository = infraredSignalRepository;
            _boardRepository = boardRepository;
        }
        public async Task<IReadOnlyCollection<InfraredSignalDTO>> GetInfraredSignals(Guid userId)
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

            var result = _mapper.Map<List<InfraredSignal>, IReadOnlyCollection<InfraredSignalDTO>>(infraredSignals);
            return result;
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

        public async Task UpdateInfraredSignal(Guid userId, InfraredSignalDTO infraredSignalUpdate)
        {
            var user = await _userRepository.GetByExternalId(userId);
            var infraredSignal = user.Boards
                .SelectMany(board => board.InfraredSignals)
                .First(signal => signal.Id == infraredSignalUpdate.Id);

            var infraredSignalWithSameOutput = user.Boards
                .SelectMany(board => board.InfraredSignals)
                .FirstOrDefault(signal => signal.IrSignalOutput == infraredSignalUpdate.IrSignalOutput);

            if (infraredSignalWithSameOutput != null)
            {
                throw new InfraredOutputAlreadyExistsException();
            }

            infraredSignal.ChangeDescription(infraredSignalUpdate.Description);
            infraredSignal.ChangeIrSignalOutput(infraredSignalUpdate.IrSignalOutput);

            await _userRepository.SaveAsync();
        }

        public async Task DeleteInfraredSignal(Guid userId, InfraredSignalDTO infraredSignalDelete)
        {
            var user = await _userRepository.GetByExternalId(userId);
            var infraredSignal = user.Boards
                .SelectMany(board => board.InfraredSignals)
                .First(signal => signal.Id == infraredSignalDelete.Id);

            _infraredSignalRepository.Remove(infraredSignal);

            await _infraredSignalRepository.SaveAsync();
        }

        public async Task RegisterBoard(Guid userId, string clientId, string clientSecret)
        {
            var user = await _userRepository.GetByExternalId(userId);
            var board = Board.Create(clientId, clientSecret);

            user.AddBoard(board);

            _boardRepository.Add(board);
            await _boardRepository.SaveAsync();
        }

        public async Task RemoveBoard(Guid userId, string clientId)
        {
            var user = await _userRepository.GetByExternalId(userId);
            var board = user.Boards.First(board => board.Name == clientId);

            _boardRepository.Remove(board);
            await _boardRepository.SaveAsync();
        }

        public async Task<IReadOnlyCollection<BoardDto>> GetUserBoards(Guid userId)
        {
            var user = await _userRepository.GetByExternalId(userId);
            var boards = user.Boards;

            return _mapper.Map<IReadOnlyCollection<Board>, IReadOnlyCollection<BoardDto>>(boards);
        }


    }
}
