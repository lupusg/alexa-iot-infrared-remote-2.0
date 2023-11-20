
namespace AlexaIOTInfraredRemoteAPI.Domain.DTOs
{
    public class InsertInfraredSignalRequest
    {
        public int Length { get; set; }
        public int[] InfraredData { get; set; }
    }
}
