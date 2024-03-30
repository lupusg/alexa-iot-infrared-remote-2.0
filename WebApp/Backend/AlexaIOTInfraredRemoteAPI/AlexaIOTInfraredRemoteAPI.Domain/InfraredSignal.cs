
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlexaIOTInfraredRemoteAPI.Domain
{
    public class InfraredSignal : BaseEntity
    {
        public string Description { get; private set; } = string.Empty;
        [NotMapped]
        public ushort[] InfraredData { get; private set; } = Array.Empty<ushort>();
        public int Length { get; private set; }
        public string IrSignalOutput { get; private set; } = string.Empty;
        public Guid? BoardId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool State { get; private set; }

        public string InfraredDataString
        {
            get => JsonConvert.SerializeObject(InfraredData);
            set => InfraredData = JsonConvert.DeserializeObject<ushort[]>(value) ?? Array.Empty<ushort>();
        }

        private InfraredSignal()
        {

        }

        public static InfraredSignal Create(string description, ushort[] infraredData, int length,
            string irSignalOutput, DateTime createdAt, bool state)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("The description can't be empty");

            if (string.IsNullOrEmpty(irSignalOutput))
                throw new ArgumentException("The assigned button can't be null");

            if (length <= 0)
                throw new ArgumentException("The length must be greater than zero.");

            InfraredSignal infraredSignal = new()
            {
                Description = description,
                InfraredData = infraredData,
                Length = length,
                IrSignalOutput = irSignalOutput,
                CreatedAt = createdAt,
                State = state,
                Id = Guid.NewGuid(),
            };

            return infraredSignal;
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("The description can't be empty");

            this.Description = description;
        }

        public void ChangeIrSignalOutput(string irSignalOutput)
        {
            if (string.IsNullOrEmpty(irSignalOutput))
                throw new ArgumentException("The irSignalOutput can't be null");

            if (irSignalOutput != "N/A" && !int.TryParse(irSignalOutput, out int value))
                throw new ArgumentException("The irSignalOutput must be a number");


            this.IrSignalOutput = irSignalOutput;
        }

        public void ChangeState(bool state)
        {
            this.State = state;
        }
    }
}
