namespace AlexaIOTInfraredRemoteAPI.Domain.Services
{
    public interface IUserService
    {
        Task<InfraredSignal> CreateInfraredSignal(string clientId, string infraredDataRaw);
        Task<IReadOnlyCollection<InfraredSignal>> GetInfraredSignals(Guid userId);
        Task<InfraredSignal> GetInfraredSignalByOutput(string clientId, string infraredSignalOutput);
    }
}
