using Microsoft.AspNetCore.Identity;
using onsales.Web.Data.Entities;
using onsales.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onsales.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);
        //me devuelve el usuario, ingresando email
        Task<IdentityResult> AddUserAsync(User user, string password);
        //se pudo  no pudo
        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);
        //devuelve u booleano   


        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();

        Task<SignInResult> ValidatePasswordAsync(User user, string password);


    }
}
