namespace AlexaIOTInfraredRemoteAPI.Domain.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
        Task<Board> GetBoardByName(string name);
    }
}
