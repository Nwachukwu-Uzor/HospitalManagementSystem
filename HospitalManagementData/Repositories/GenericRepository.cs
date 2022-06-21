using HospitalManagementDomain.Contracts;
using HospitalManagementDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementData.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0 ? entity : null;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _dbSet.Where(ent => ent.Id == id).FirstOrDefaultAsync();
            if (entity == null)
            {
                return false;
            }

            _dbSet.Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<IEnumerable<T>> GetAllPaginatedAsync(int pageNumber, int pageSize, List<string> options = null)
        {
            var users = _dbSet.AsQueryable();
               
            if (options != null)
            {
                foreach(var option in options)
                {
                    users = users.Include(option);
                }
            }
                
            return await users.OrderBy(pat => pat.CreatedAt).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.Where(entity => entity.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Update(entity);
            return (await _context.SaveChangesAsync()) > 0 ? entity : null;
        }
    }
}
