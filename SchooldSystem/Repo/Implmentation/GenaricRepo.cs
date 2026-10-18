using Microsoft.EntityFrameworkCore;
using SchooldSystem.App_context;
using SchooldSystem.Repo.Interface;

namespace SchooldSystem.Repo.Implmentation
{
    public class GenaricRepo<T> : IGenariceRepo<T> where T : class
    {
        public AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenaricRepo(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

       
        async void AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IGenariceRepo<T>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<T> IGenariceRepo<T>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        void IGenariceRepo<T>.Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
