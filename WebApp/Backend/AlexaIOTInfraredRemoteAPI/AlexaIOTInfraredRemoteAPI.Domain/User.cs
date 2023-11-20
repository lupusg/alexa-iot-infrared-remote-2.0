﻿
namespace AlexaIOTInfraredRemoteAPI.Domain
{
    public class User : BaseEntity
    {
        public Guid ExternalId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;

        private List<InfraredSignal> _infraredSignals = new();
        public IReadOnlyCollection<InfraredSignal> InfraredSignals => _infraredSignals;

        private User()
        {

        }

        public static User Create(Guid externalId, string name, string email)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name can't be empty");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email can't be empty");

            if (externalId == Guid.Empty)
                throw new ArgumentException("External Id can't be empty");

            User user = new()
            {
                Id = Guid.NewGuid(),
                ExternalId = externalId,
                Name = name,
                Email = email
            };

            return user;
        }

        public void AddInfraredSignal(InfraredSignal infraredSignal)
        {
            _infraredSignals.Add(infraredSignal);
        }
    }
}
