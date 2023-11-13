using AlexaIOTInfraredRemoteAPI.Domain.Specifications;

namespace AlexaIOTInfraredRemoteAPI.Domain.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    }
}
