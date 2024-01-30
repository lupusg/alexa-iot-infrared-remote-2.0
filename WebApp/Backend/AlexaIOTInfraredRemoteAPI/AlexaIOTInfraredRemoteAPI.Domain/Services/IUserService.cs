using AlexaIOTInfraredRemoteAPI.Domain.DTOs;

namespace AlexaIOTInfraredRemoteAPI.Domain.Services
{
    public interface IUserService
    {
        Task<InfraredSignal> CreateInfraredSignal(string clientId, string infraredDataRaw);
        Task<IReadOnlyCollection<InfraredSignalDTO>> GetInfraredSignals(Guid userId);
        Task<InfraredSignal> GetInfraredSignalByOutput(string clientId, string infraredSignalOutput);
        Task RegisterBoard(Guid userId, string clientId, string clientSecret);
        Task RemoveBoard(Guid userId, string clientId);
        Task<IReadOnlyCollection<BoardDto>> GetUserBoards(Guid userId);
    }
}
