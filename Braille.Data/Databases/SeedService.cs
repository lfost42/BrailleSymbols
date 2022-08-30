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

        public SeedService(ApplicationDbContext dbContext,
            IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        public async Task ManageDataAsnc()
        {
            await _dbContext.Database.MigrateAsync();
        }

        // lhttps://www.c-sharpcorner.com/article/import-excel-data-to-database-using-Asp-Net-mvc-entity-frame/


    }
}