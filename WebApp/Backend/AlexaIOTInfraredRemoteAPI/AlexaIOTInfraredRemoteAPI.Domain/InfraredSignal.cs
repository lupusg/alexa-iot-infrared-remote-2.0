
namespace AlexaIOTInfraredRemoteAPI.Domain
{
    public class InfraredSignal : BaseEntity
    {
        public string Description { get; private set; } = string.Empty;
        public string InfraredData { get; private set; } = string.Empty;
        public string IrSignalOutput { get; private set; } = string.Empty;
        public Guid UserId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private InfraredSignal()
        {

        }

        public static InfraredSignal Create(string description, string infraredData,
            string irSignalOutput, DateTime createdAt)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("The description can't be empty");

            if (string.IsNullOrEmpty(infraredData))
                throw new ArgumentException("The infrared data can't be empty");

            if (string.IsNullOrEmpty(irSignalOutput))
                throw new ArgumentException("The assigned button can't be null");

            InfraredSignal infraredSignal = new()
            {
                Description = description,
                InfraredData = infraredData,
                IrSignalOutput = irSignalOutput,
                CreatedAt = createdAt
            };

            return infraredSignal;
        }
    }
}
