using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Database;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Repositories
{
    public class InfraredSignalRepository: BaseRepository<InfraredSignal>, IInfraredSignalRepository
    {
        public InfraredSignalRepository(AiirContext context) : base(context)
        {
        }
    }
}
