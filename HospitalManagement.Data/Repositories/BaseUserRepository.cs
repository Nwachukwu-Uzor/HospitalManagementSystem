using HospitalManagement.BL.Contracts;
using HospitalManagement.Domain.Contracts;
using HospitalManagement.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Repositories
{
    public class BaseUserRepository<T> : IUserRepository<T> where T : AppUser
    {
        private readonly string _userType;
        protected readonly DbSet<T> _dbSet;
        protected readonly AppDbContext _context;
        protected readonly IIdentityNumberGenerator _identityNumberGenerator;
        protected readonly UserManager<AppUser> _userManager;
        public BaseUserRepository(
            AppDbContext context, IIdentityNumberGenerator identityNumberGenerator, 
            string userType, UserManager<AppUser> userManager
        )
        {
            _dbSet = context.Set<T>();
            _context = context;
            _userType = userType;
            _identityNumberGenerator = identityNumberGenerator;
            _userManager = userManager;
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

        public virtual async Task<IEnumerable<T>> GetAllPaginatedAsync(int pageNumber, int pageSize, List<string> options = null)
        {
            var users = _dbSet.Where(entity => entity.IsActive);

            if (options != null)
            {
                foreach(var opt in options)
                {
                    users = users.Include(opt);
                }
            }
              
            return await users.OrderBy(user => user.FirstName).Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize).ToListAsync();
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

        public Task<T> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> SearchForUsers(string name = "", string email = "", int page = 1, int size = 25)
        {
            var users = _dbSet.Where(usr => usr.IsActive).AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                users = users.Where(usr => 
                    usr.FirstName.ToLower().Contains(name.ToLower()) || 
                    usr.MiddleName.ToLower().Contains(name.ToLower()) || 
                    usr.LastName.ToLower().Contains(name.ToLower())
                );
            } 

            if (Regex.IsMatch(email, @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$"))
            {
                users = users.Where(usr => usr.Email.ToLower() == email.ToLower());
            }

            var usersList = await users.OrderBy(usr => usr.FirstName).Skip((page - 1) * size).Take(size).ToListAsync();
            if (!usersList.Any())
            {
                throw new ArgumentException("Unable to find users");
            }

            return usersList;
        }
    }
}
