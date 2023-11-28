namespace AlexaIOTInfraredRemoteAPI.Domain
{
    public class Board : BaseEntity
    {
        public string Name { get; private set; }
        public Guid? UserId { get; private set; }
        public User? User { get; private set; }
        private List<InfraredSignal> _infraredSignals = new();
        public IReadOnlyCollection<InfraredSignal> InfraredSignals => _infraredSignals;

        private Board() { }

        public static Board Create(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("The name can't be empty");

            return new Board()
            {
                Name = name,
            };
        }

        public void AddInfraredSignal(InfraredSignal infraredSignal)
        {
            _infraredSignals.Add(infraredSignal);
        }
    }
}
