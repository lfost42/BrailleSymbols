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

namespace Braille.Data
{
    public class SeedService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<UserModel> _userManager;
        private readonly IConfiguration _config;

        public SeedService(ApplicationDbContext dbContext,
            UserManager<UserModel> userManager,
            IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
            _userManager = userManager;
        }

        public async Task ManageDataAsnc()
        {
            await _dbContext.Database.MigrateAsync();
        }

    }
}