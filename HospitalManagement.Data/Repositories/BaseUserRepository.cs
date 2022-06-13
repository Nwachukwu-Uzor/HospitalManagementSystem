﻿using HospitalManagement.BL.Contracts;
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
        protected readonly List<string> _roles;
        public BaseUserRepository(
            AppDbContext context, IIdentityNumberGenerator identityNumberGenerator, 
            string userType, UserManager<AppUser> userManager, List<string> roles
        )
        {
            _dbSet = context.Set<T>();
            _context = context;
            _userType = userType;
            _identityNumberGenerator = identityNumberGenerator;
            _userManager = userManager;
            _roles = roles;
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

        public async Task<T> CreateAsync(T entity, string password, List<string> roles)
        {
            var randomId = _identityNumberGenerator.GenerateIdNumber(_userType);

            var userExist = await GetUserByIdentityNumber(randomId);


            // Develop a more efficient way to ensure the identity number is unique
            if (userExist != null)
            {
                return await CreateAsync(entity, password, _roles);
            }

            var userByEmail = await GetUserByEmail(entity.Email);

            if (userByEmail != null)
            {
                throw new ArgumentException($"A {nameof(AppUser)} exists with the email provided");
            }

            entity.IdentificationNumber = randomId;

            var isCreated = await _userManager.CreateAsync(entity, password);

            if (!isCreated.Succeeded)
            {
                var errorMessage = new StringBuilder();
                foreach (var error in isCreated.Errors)
                {
                    errorMessage.AppendLine($" {error.Description}");
                }
                throw new ArgumentException($"Unable to create a user with the provided credentials {errorMessage.ToString().Trim()}");
            }

            await _userManager.AddToRolesAsync(entity, _roles);

            return entity;
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
