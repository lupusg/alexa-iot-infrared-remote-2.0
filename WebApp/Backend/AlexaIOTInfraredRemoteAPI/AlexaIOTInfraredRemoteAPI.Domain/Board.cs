using AlexaIOTInfraredRemoteAPI.Domain.Helpers;

namespace AlexaIOTInfraredRemoteAPI.Domain
{
    public class Board : BaseEntity
    {
        public string Name { get; private set; }
        public string Secret { get; private set; }
        public Guid? UserId { get; private set; }
        public User? User { get; private set; }
        private List<InfraredSignal> _infraredSignals = new();
        public IReadOnlyCollection<InfraredSignal> InfraredSignals => _infraredSignals;

        private Board() { }

        public static Board Create(string name, string secret)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("The name can't be empty");

            if (string.IsNullOrEmpty(secret))
                throw new ArgumentException("The secret can't be empty");

            return new Board()
            {
                Name = name,
                Secret = secret,
            };
        }

        public void AddInfraredSignal(InfraredSignal infraredSignal)
        {
            _infraredSignals.Add(infraredSignal);
        }
    }
}
