using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Database;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AiirContext _context;

        public UserRepository(AiirContext context)
        {
            _context = context;
        }

        public void RegisterUser(User user)
        {
            _context.Users.Add(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
