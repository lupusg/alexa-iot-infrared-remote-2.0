using AlexaIOTInfraredRemoteAPI.Domain.DTOs;

namespace AlexaIOTInfraredRemoteAPI.Domain.Services
{
    public interface IUserService
    {
        /* Infrared Signals */
        Task<IReadOnlyCollection<InfraredSignalDTO>> GetInfraredSignals(Guid userId);
        Task<InfraredSignal> GetInfraredSignalByOutput(string clientId, string infraredSignalOutput);
        Task<InfraredSignal> CreateInfraredSignal(string clientId, string infraredDataRaw);
        Task UpdateInfraredSignal(Guid userId, InfraredSignalDTO infraredSignalUpdate);
        Task DeleteInfraredSignal(Guid guid, InfraredSignalDTO infraredSignalDelete);

        /* User Boards */
        Task<IReadOnlyCollection<BoardDto>> GetUserBoards(Guid userId);
        Task RegisterBoard(Guid userId, string clientId, string clientSecret);
        Task RemoveBoard(Guid userId, string clientId);
    }
}
