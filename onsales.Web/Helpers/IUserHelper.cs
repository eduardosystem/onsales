using Microsoft.AspNetCore.Identity;
using onsales.Common.Enums;
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

        Task<User> AddUserAsync(AddUserViewModel model, Guid imageId, UserType userType);
        
        //Passwords
        Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword);

        Task<IdentityResult> UpdateUserAsync(User user);

        Task<User> GetUserAsync(Guid userId);


        Task<string> GenerateEmailConfirmationTokenAsync(User user);

        Task<IdentityResult> ConfirmEmailAsync(User user, string token);

        Task<string> GeneratePasswordResetTokenAsync(User user);

        Task<IdentityResult> ResetPasswordAsync(User user, string token, string password);


    }
}
