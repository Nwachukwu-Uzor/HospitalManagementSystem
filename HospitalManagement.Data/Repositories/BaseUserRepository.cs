using HospitalManagement.BL.Contracts;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Repositories
{
    public class BaseUserRepository<T> : IUserRepository<T> where T : AppUser
    {
        private readonly string _userType;
        protected readonly DbSet<T> _dbSet;
        protected readonly AppDbContext _context;
        protected readonly IIdentityNumberGenerator _identityNumberGenerator;
        public BaseUserRepository(AppDbContext context, IIdentityNumberGenerator identityNumberGenerator, string userType)
        {
            _dbSet = context.Set<T>();
            _context = context;
            _userType = userType;
            _identityNumberGenerator = identityNumberGenerator;
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            var randomId = _identityNumberGenerator.GenerateIdNumber(_userType);

            var userExist = await GetUserByIdentityNumber(randomId);


            // Develop a more efficient way to ensure the identity number is unique
            if (userExist != null)
            {
                return await AddAsync(entity);
            }

            var userByEmail = await GetUserByEmail(entity.Email);

            if (userByEmail != null)
            {
                throw new ArgumentException("A doctor exists with the email provided");
            }

            entity.IdentificationNumber = randomId;

            await _dbSet.AddAsync(entity);

            return await _context.SaveChangesAsync() > 0 ? entity : null;
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _dbSet.Where(ent => Guid.Parse(ent.Id) == id && ent.IsActive).FirstOrDefaultAsync();
            if (entity == null)
            {
                return false;
            }

            entity.IsActive = false;

            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<IEnumerable<T>> GetAllPaginatedAsync(int pageNumber, int pageSize)
        {
            return await _dbSet.Where(entity => entity.IsActive)
                        .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .OrderBy(user => user.FirstName)
                        .ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.Where(user => Guid.Parse(user.Id) == id && user.IsActive)
                                .FirstOrDefaultAsync();
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return (await _context.SaveChangesAsync()) > 0 ? entity : null;
        }

        public virtual async Task<T> GetUserByIdentityNumber(string identityNumber)
        {
            return await _dbSet.Where(user => user.IdentificationNumber == identityNumber).FirstOrDefaultAsync();
        }

        public virtual async Task<T> GetUserByEmail(string email)
        {
           return await _dbSet.Where(user => user.Email == email).FirstOrDefaultAsync();
        }
    }
}
