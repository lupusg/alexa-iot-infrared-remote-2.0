using Microsoft.EntityFrameworkCore;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Database
{
    public class AiirContext : DbContext
    {
        public AiirContext(DbContextOptions<AiirContext> options) : base(options)
        {

        }
    }
}
