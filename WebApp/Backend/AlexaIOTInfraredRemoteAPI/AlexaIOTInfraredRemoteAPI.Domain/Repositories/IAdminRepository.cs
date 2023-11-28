namespace AlexaIOTInfraredRemoteAPI.Domain.Repositories
{
    public interface IAdminRepository
    {
        public void RegisterUser(User user);

        Task<bool> SaveChangesAsync();
    }
}
