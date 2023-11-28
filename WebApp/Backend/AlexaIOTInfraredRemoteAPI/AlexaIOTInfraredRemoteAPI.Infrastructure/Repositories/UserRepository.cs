using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository 
    {
        private readonly AiirContext _dbContext;

        public UserRepository(AiirContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Board> GetBoard(string clientId)
        {
            return _dbContext.Boards.FirstAsync(x => x.Name == clientId);
        }
    }
}
