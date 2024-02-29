namespace AlexaIOTInfraredRemoteAPI.Domain.Exceptions
{
    public class InfraredOutputAlreadyExistsException : Exception
    {
        public InfraredOutputAlreadyExistsException(): base("Infrared Output already exists.")
        {
            
        }
    }
}
