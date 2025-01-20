using Microsoft.AspNetCore.Identity;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using LibApp.Data;

namespace LibApp.Services
{
    public class UserService
    {
        private readonly UserManager<Users> _userManager;
        private readonly ILogger<UserService> _logger;
        private readonly AppDbContext _context;
        public UserService(UserManager<Users> userManager, ILogger<UserService> logger, AppDbContext context)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;
        }


        public async Task<List<Users>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            if (users == null || !users.Any())
            {
                _logger.LogInformation("No users found in the database.");
                return new List<Users>();
            }

            var adminRoleName = "Admin";
            var adminRoleUsers = new List<Users>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains(adminRoleName))
                {
                    adminRoleUsers.Add(user);
                }
            }

            var nonAdminUsers = users.Where(user => !adminRoleUsers.Contains(user)).ToList();

            if (nonAdminUsers == null || !nonAdminUsers.Any())
            {
                _logger.LogInformation("No non-admin users found.");
            }
            else
            {
                _logger.LogInformation($"Found {nonAdminUsers.Count} non-admin users.");
            }

            foreach (var user in nonAdminUsers)
            {
                Console.WriteLine($"User ID: {user.Id}, Full Name: {user.FullName}, Email: {user.Email}, UserName: {user.UserName}");
            }

            return nonAdminUsers;
        }


        public async Task<object> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users
                .Where(u => u.NormalizedEmail == email.ToUpper())
                .Select(u => new
                {
                    u.Id,
                    u.Email,
                    u.UserName,
                    u.LockoutEnabled,
                    u.FullName
                })
                .FirstOrDefaultAsync();

            return user;
        }


    }
}
