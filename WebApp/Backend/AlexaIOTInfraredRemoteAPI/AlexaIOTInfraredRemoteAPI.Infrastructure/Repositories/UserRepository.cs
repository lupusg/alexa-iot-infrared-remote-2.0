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

        public Task<Board> GetBoardByName(string name)
        {
            return _dbContext.Boards.FirstAsync(x => x.Name == name);
        }

        public async Task<User> GetByExternalId(Guid userId)
        {
            return await _dbContext.Users.Include(b  => b.Boards).ThenInclude(b => b.InfraredSignals).FirstAsync(user => user.ExternalId == userId);
        }
    }
}
