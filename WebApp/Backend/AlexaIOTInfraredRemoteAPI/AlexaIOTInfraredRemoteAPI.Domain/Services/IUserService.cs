namespace AlexaIOTInfraredRemoteAPI.Domain.Services
{
    public interface IUserService
    {
        Task<InfraredSignal> CreateInfraredSignal(Guid userId, int length, int[] infraredData);
        Task<IReadOnlyList<InfraredSignal>> GetInfraredSignals(string sort);
    }
}
