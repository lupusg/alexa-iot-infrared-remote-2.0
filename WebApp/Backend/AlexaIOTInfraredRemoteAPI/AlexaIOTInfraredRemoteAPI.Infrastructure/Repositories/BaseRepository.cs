using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Repositories;
using AlexaIOTInfraredRemoteAPI.Domain.Specifications;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Database;
using AlexaIOTInfraredRemoteAPI.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace AlexaIOTInfraredRemoteAPI.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AiirContext _context;
        public BaseRepository(AiirContext context)
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
