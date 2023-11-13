using AlexaIOTInfraredRemoteAPI.Domain;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Database
{
    public class AiirContextSeed
    {
        public static async Task SeedAsync(AiirContext context)
        {
            //seed data logic

            if (!context.InfraredSignals.Any())
            {
                var s1 = InfraredSignal.Create("desc1", "irData1", "irOutput1", DateTime.Now);
                var s2 = InfraredSignal.Create("desc2", "irData2", "irOutput2", DateTime.Now);
                var s3 = InfraredSignal.Create("desc3", "irData3", "irOutput3", DateTime.Now);
                var s4 = InfraredSignal.Create("desc4", "irData4", "irOutput4", DateTime.Now);
                var s5 = InfraredSignal.Create("desc5", "irData5", "irOutput5", DateTime.Now);

                var infraredSignals = new List<InfraredSignal>(){ s1, s2, s3, s4, s5 };
                context.InfraredSignals.AddRange(infraredSignals);
            }

            await context.SaveChangesAsync();
        }
    }
}
