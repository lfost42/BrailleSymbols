using System;
using System.Collections.Generic;
using System.Linq;
using BrailleSymbols.Data.Data;
using BrailleSymbols.Data.Models;
using BrailleSymbols.Data.Repository.IRepository;

namespace BrailleSymbols.Data.Repository
{
    public class AsciiRepository : IAsciiRepository
    {
        private readonly ApplicationDbContext _db;

        public AsciiRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool AsciiExists(string symbol)
        {
            bool value = _db.Asciis.Any(a => a.Symbol.ToLower().Trim() == symbol.ToLower().Trim());
            return value;
        }

        public bool AsciiModelExists(int id)
        {
            bool value = _db.Asciis.Any(a => a.Id == id);
            return value;
        }

        public bool CreateAsciiModel(AsciiModel ascii)
        {
            _db.Asciis.Add(ascii);
            return Save();
        }

        public bool DeleteAsciiModel(AsciiModel ascii)
        {
            _db.Asciis.Remove(ascii);
            return Save();
        }

        public AsciiModel GetAsciiModel(int id)
        {
            return _db.Asciis.FirstOrDefault(async => async.Id == id);
        }

        public ICollection<AsciiModel> GetAsciis()
        {
            return _db.Asciis.OrderBy(a => a.Symbol).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateAscii(AsciiModel ascii)
        {
            _db.Asciis.Update(ascii);
            return Save();
        }
    }
}
