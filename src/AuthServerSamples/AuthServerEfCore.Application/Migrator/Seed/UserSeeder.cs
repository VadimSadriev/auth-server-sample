using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServerEfCore.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace AuthServerEfCore.Application.Migrator.Seed
{
    /// <summary>
    /// Service for seeding db with users
    /// </summary>
    public class UserSeeder : ISeeder
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        /// <summary>
        /// <inheritdoc cref="UserSeeder"/>
        /// </summary>
        public UserSeeder(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public async Task SeedAsync()
        {
            var usersData = GetUsersData();

            foreach (var userData in usersData)
            {
                var user = userData.User;

                // User creation
                var userCreateResult = await _userManager.CreateAsync(user, userData.Password);

                if (!userCreateResult.Succeeded)
                {
                    var userCreateErrors = userCreateResult.Errors
                        .Select(error => new ValidationFailure(error.Code, error.Description));

                    throw new ValidationException(userCreateErrors);
                }

                // Create role if not exist and add user to role if not in
                // TODO: Probably seprate role seeding to another seeder. Add posobility to remove role if not present in data
                foreach (var role in userData.Roles)
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                        await _roleManager.CreateAsync(new Role { Name = role });

                    if (!await _userManager.IsInRoleAsync(user, role))
                        await _userManager.AddToRoleAsync(user, role);
                }
            }
        }

        /// <summary>
        /// Returns list of users to seed
        /// </summary>
        private IList<UserData> GetUsersData()
        {
            return new List<UserData>
            {
                new UserData
                {
                    User = new User
                    {
                        Email = "Admin@NoReply.com",
                        UserName = "Admin"
                    },
                    Password = "Admin",
                    Roles = new List<string>
                    {
                        "Admin"
                    }
                }
            };
        }
    }

    /// <summary>
    /// User data for seeding
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// Actual user
        /// </summary>
        public User User { get; init; }

        /// <summary>
        /// User password
        /// </summary>
        public string Password { get; init; }

        /// <summary>
        /// User roles
        /// </summary>
        public IList<string> Roles { get; init; } = new List<string>();
    }
}