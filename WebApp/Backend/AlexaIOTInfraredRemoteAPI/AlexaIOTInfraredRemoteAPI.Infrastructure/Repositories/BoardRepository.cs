using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Database;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Repositories
{
    public class BoardRepository : BaseRepository<Board>, IBoardRepository
    {
        private readonly AiirContext _context;

        public BoardRepository(AiirContext context) : base(context)
        {
            _context = context;
        }
    }
}
