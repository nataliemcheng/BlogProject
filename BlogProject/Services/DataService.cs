using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Data;
using BlogProject.Enums;
using BlogProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Services
{
	public class DataService
	{
        private readonly ApplicationDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<BlogUser> _userManager;

        public DataService(ApplicationDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync()
        {
            // Task: Create the DB from the Migrations
            await _dbContext.Database.MigrateAsync();

            // Task 1: Seed a few Roles into the system
            await SeedRolesAsync();

            // Task 2: Seed a few Users into the system
            await SeedUsersAsync();

        }

        private async Task SeedRolesAsync()
        {
            // if there are already Roles in the system, do nothing
            if (_dbContext != null && _dbContext.Roles.Any())
            {
                return;
            }
            // otherwise, create a few roles
            foreach(var role in Enum.GetNames(typeof(BlogRole)))
            {
                // use the Role Manager to create roles
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private async Task SeedUsersAsync()
        {
            // if there are already Users in the system, do nothing
            if (_dbContext != null && _dbContext.Users.Any())
            {
                return;
            }
            // Step 1: otherwise, create a new instance of BlogUser
            var adminUser = new BlogUser()
            {
                Email = "natcheng@bu.edu",
                UserName = "natcheng@bu.edu",
                FirstName = "Natalie",
                LastName = "Cheng",
                DisplayName = "Natalie Cheng",
                PhoneNumber = "(909) 895-9450",
                EmailConfirmed = true,
            };

            // Step 2: use the UserManager to create a new user that is defined by adminUser
            await _userManager.CreateAsync(adminUser, "Abc&123!");

            // Step 3: add this new user to the Administrator role
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            // -----REPEAT FOR MODERATOR----- // 

            // Step 1: create the moderator user
            var modUser = new BlogUser()
            {
                Email = "nataliemcheng1@gmail.com",
                UserName = "nataliemcheng1@gmail.com",
                FirstName = "Natalie",
                LastName = "Cheng",
                DisplayName = "Natalie Cheng",
                PhoneNumber = "(909) 895-9450",
                EmailConfirmed = true,
            };

            // Step 2: use the UserManager to create a new user that is defined by modUser
            await _userManager.CreateAsync(modUser, "Abc&123!");

            // Step 3: add this new user to the Moderator role
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());

        }
    }
}

