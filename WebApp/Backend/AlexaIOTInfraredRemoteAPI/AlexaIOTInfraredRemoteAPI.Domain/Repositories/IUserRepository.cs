namespace AlexaIOTInfraredRemoteAPI.Domain.Repositories
{
    public interface IUserRepository
    {
        public void RegisterUser(User user);

        Task<bool> SaveChangesAsync();
    }
}
