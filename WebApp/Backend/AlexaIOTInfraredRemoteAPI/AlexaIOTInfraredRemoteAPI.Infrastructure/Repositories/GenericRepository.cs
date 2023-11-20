using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Domain.Specifications;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Database;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Repositories
{
    public class GenericRepository<T>: IGenericRepository<T> where T : BaseEntity
    {
        private readonly AiirContext _context;
        public GenericRepository(AiirContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<User> GetByExternalId(Guid userId)
        {
            var result = await _context.Users
                .FirstAsync(s => s.ExternalId != null && s.ExternalId.Equals(userId));

            return result;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}
