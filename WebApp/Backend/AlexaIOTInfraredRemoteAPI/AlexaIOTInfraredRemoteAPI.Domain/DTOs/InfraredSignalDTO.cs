namespace AlexaIOTInfraredRemoteAPI.Domain.DTOs
{
    public class InfraredSignalDTO
    {
        public string Description { get; set; }
        public ushort[] InfraredData { get; set; }
        public int Length { get; set; }
        public string IrSignalOutput { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
