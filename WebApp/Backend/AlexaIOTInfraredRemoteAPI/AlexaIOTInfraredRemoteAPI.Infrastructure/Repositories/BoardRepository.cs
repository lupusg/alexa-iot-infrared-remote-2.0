using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Database;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Repositories
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        public BoardRepository(AiirContext context) : base(context)
        {
        }
    }
}
