using System;
using System.Threading.Tasks;
using Braille.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Braille.Data
{
    public class SeedService
    {
        private readonly ApplicationDbContext _dbContext;

        public SeedService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ManageDataAsnc()
        {
            await _dbContext.Database.MigrateAsync();
        }

    }

}