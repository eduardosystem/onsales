using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using onsales.Web.Data;
using onsales.Web.Data.Entities;

namespace onsales.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        //Inyecta el datacontext, para administrar usuarios UserManager, Administrar Roles RoleManager
        public UserHelper(DataContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        //public Task<IdentityResult> AddUserAsync(User user, string password)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        //public Task AddUserToRoleAsync(User user, string roleName)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users
                .Include(u => u.City)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        //public Task<bool> IsUserInRoleAsync(User user, string roleName)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<User> IUserHelper.GetUserAsync(string email)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
