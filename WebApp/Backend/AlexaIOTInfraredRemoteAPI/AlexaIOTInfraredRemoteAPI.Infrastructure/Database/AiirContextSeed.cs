namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Database
{
    public class AiirContextSeed
    {
        public static async Task SeedAsync(AiirContext context)
        {
            //seed data logic

            await context.SaveChangesAsync();
        }
    }
}
