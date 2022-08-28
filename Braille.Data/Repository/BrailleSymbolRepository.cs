using Microsoft.EntityFrameworkCore;
using Braille.Data.Data;
using Braille.Data.Models;
using Braille.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Braille.Data.Repository
{
    public class BrailleSymbolRepository : IBrailleSymbolRepository
    {
        private readonly ApplicationDbContext _db;

        public BrailleSymbolRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateBrailleSymbol(BrailleSymbol BrailleSymbol)
        {
            _db.BrailleSymbols.Add(BrailleSymbol);
            return Save();
        }

        public bool DeleteBrailleSymbol(BrailleSymbol BrailleSymbol)
        {
            _db.BrailleSymbols.Remove(BrailleSymbol);
            return Save();
        }

        public BrailleSymbol GetBrailleSymbol(int BrailleSymbolId)
        {
            return _db.BrailleSymbols.Include(c => c.AsciiCharacter).FirstOrDefault(a => a.Id == BrailleSymbolId);
        }

        public ICollection<BrailleSymbol> GetBrailleSymbols()
        {
            return _db.BrailleSymbols.Include(c => c.AsciiCharacter).OrderBy(a => a.Name).ToList();
        }

        public bool BrailleSymbolExists(string name)
        {
            bool value = _db.BrailleSymbols.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool BrailleSymbolExists(int id)
        {
            return _db.BrailleSymbols.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateBrailleSymbol(BrailleSymbol BrailleSymbol)
        {
            _db.BrailleSymbols.Update(BrailleSymbol);
            return Save();
        }

        public ICollection<BrailleSymbol> GetBrailleSymbolsInAsciiCharacter(int npId)
        {
            return _db.BrailleSymbols.Include(c => c.AsciiCharacter).Where(c => c.AsciiCharacterId == npId).ToList();
        }
    }
}
