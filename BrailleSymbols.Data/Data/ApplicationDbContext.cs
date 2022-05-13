using System;
using System.Collections.Generic;
using System.Text;
using BrailleSymbols.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrailleSymbols.Data.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AsciiModel> Asciis { get; set; }
        public DbSet<SpecialSymbolsModel> SpecialSymbols { get; set; }
    }
}
