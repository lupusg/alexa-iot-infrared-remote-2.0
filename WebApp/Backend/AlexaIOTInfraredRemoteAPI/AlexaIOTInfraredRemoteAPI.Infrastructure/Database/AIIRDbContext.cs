using Microsoft.EntityFrameworkCore;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Database
{
    public class AIIRDbContext : DbContext
    {
        public AIIRDbContext(DbContextOptions<AIIRDbContext> options) : base(options)
        {

        }
    }
}
