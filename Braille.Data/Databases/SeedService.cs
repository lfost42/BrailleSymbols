using System;
using System.Threading.Tasks;
using Braille.Data.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Braille.Data.Models;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Braille.Data.Databases
{
    public class SeedService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _config;
        private readonly UserManager<UserModel> _userManager;

        public SeedService(ApplicationDbContext dbContext,
            IConfiguration config,
            UserManager<UserModel> userManager)
        {
            _dbContext = dbContext;
            _config = config;
            _userManager = userManager;
        }

        public async Task ManageDataAsnc()
        {
            await _dbContext.Database.MigrateAsync();
            await SeedUsersAsync();
        }

        private async Task SeedUsersAsync()
        {
            if (_dbContext.AppUsers.Any()) return;

            string defaultPassword = _config["DefaultPassword"];
            string ownerPassword = _config["OwnerPassword"];

            var ownerUser = new UserModel()
            {
                Email = "owner@brailleapi.com",
                UserName = "owner@brailleapi.com",
                EmailConfirmed = true,
            };
            await _userManager.CreateAsync(ownerUser, ownerPassword);

            var visitorUser = new UserModel()
            {
                Email = "visitor@brailleapi.com",
                UserName = "visitor@brailleapi.com",
                EmailConfirmed = true,
            };
            await _userManager.CreateAsync(visitorUser, defaultPassword);
        }

        // lhttps://www.c-sharpcorner.com/article/import-excel-data-to-database-using-Asp-Net-mvc-entity-frame/


    }
}