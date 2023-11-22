using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Database;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Repositories
{
    public class AdminRepository: IAdminRepository
    {
        private readonly AiirContext _context;

        public AdminRepository(AiirContext context)
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
