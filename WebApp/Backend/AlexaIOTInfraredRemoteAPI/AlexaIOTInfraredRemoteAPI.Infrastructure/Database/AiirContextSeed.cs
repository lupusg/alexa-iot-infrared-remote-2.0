using AlexaIOTInfraredRemoteAPI.Domain;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Database
{
    public class AiirContextSeed
    {
        public static async Task SeedAsync(AiirContext context)
        {
            if (!context.Boards.Any() && !context.InfraredSignals.Any())
            {
                var boards = new List<Board>()
                {
                    Board.Create("arduino_client", "arduino_client")
                };

                var infraredSignals = new List<InfraredSignal>();
                for (var i = 0; i < 20; ++i)
                {
                    var signal = InfraredSignal.Create($"description{i}", new ushort[] { 1, 2, 3, 4, 5 }, 5, $"output{i}",
                        DateTime.Now.AddHours(i));
                    infraredSignals.Add(signal);
                    boards[0].AddInfraredSignal(signal);
                }

                context.Boards.AddRange(boards);
                context.InfraredSignals.AddRange(infraredSignals);
            }

            await context.SaveChangesAsync();
        }
    }
}
