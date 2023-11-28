namespace AlexaIOTInfraredRemoteAPI.Domain.Services
{
    public interface IUserService
    {
        Task<InfraredSignal> CreateInfraredSignal(string clientId, int length, int[] infraredData);
        Task<IReadOnlyList<InfraredSignal>> GetInfraredSignals(string sort);
    }
}
