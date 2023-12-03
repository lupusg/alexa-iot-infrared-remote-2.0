namespace AlexaIOTInfraredRemoteAPI.Domain.Services
{
    public interface IUserService
    {
        Task<InfraredSignal> CreateInfraredSignal(string clientId, string infraredDataRaw);
        Task<IReadOnlyList<InfraredSignal>> GetInfraredSignals(string sort);
    }
}
