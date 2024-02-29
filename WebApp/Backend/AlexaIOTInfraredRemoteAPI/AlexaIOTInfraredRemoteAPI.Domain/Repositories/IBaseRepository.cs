using AlexaIOTInfraredRemoteAPI.Domain.Specifications;

namespace AlexaIOTInfraredRemoteAPI.Domain.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Remove(T entity);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task SaveAsync();
    }
}
