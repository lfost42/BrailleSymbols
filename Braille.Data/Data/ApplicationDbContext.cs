using System;
using System.Collections.Generic;
using System.Text;
using Braille.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Braille.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AsciiCharacter> AsciiCharacters { get; set; }
        public DbSet<BrailleSymbol> BrailleSymbols { get; set; }
        public DbSet<UserModel> AppUsers { get; set; }
    }
}
