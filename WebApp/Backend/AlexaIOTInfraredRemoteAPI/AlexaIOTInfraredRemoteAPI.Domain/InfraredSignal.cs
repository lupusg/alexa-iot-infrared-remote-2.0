
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlexaIOTInfraredRemoteAPI.Domain
{
    public class InfraredSignal : BaseEntity
    {
        public string Description { get; private set; } = string.Empty;
        [NotMapped]
        public int[] InfraredData { get; private set; }
        public int Length { get; private set; }
        public string IrSignalOutput { get; private set; } = string.Empty;
        public Guid ?BoardId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string InfraredDataAsString
        {
            get { return JsonConvert.SerializeObject(InfraredData); }
            set { InfraredData = JsonConvert.DeserializeObject<int[]>(value); }
        }
        //save it to db
        //check length with int[].length
        private InfraredSignal()
        {

        }

        public static InfraredSignal Create(string description, int[] infraredData, int length,
            string irSignalOutput, DateTime createdAt)
        {
            if (string.IsNullOrEmpty(description))
                throw new ArgumentException("The description can't be empty");

            if (string.IsNullOrEmpty(irSignalOutput))
                throw new ArgumentException("The assigned button can't be null");

            InfraredSignal infraredSignal = new()
            {
                Description = description,
                InfraredData = infraredData,
                Length = length,
                IrSignalOutput = irSignalOutput,
                CreatedAt = createdAt,
                Id = Guid.NewGuid()
            };

            return infraredSignal;
        }
    }
}
