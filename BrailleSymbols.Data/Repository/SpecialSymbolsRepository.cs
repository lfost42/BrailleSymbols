using System;
using System.Collections.Generic;
using System.Linq;
using BrailleSymbols.Data.Data;
using BrailleSymbols.Data.Models;
using BrailleSymbols.Data.Repository.IRepository;

namespace BrailleSymbols.Data.Repository
{
    public class SpecialSymbolsRepository : ISpecialSymbolsRepository
    {
        private readonly ApplicationDbContext _db;

        public SpecialSymbolsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateSpecialSymbolsModel(SpecialSymbolsModel specialSymbols)
        {
            _db.SpecialSymbols.Add(specialSymbols);
            return Save();
        }

        public bool DeleteSpecialSymbolsModel(SpecialSymbolsModel specialSymbols)
        {
            _db.SpecialSymbols.Remove(specialSymbols);
            return Save();
        }

        public ICollection<SpecialSymbolsModel> GetSpecialSymbolModels()
        {
            return _db.SpecialSymbols.OrderBy(a => a.SymbolName).ToList();
        }

        public SpecialSymbolsModel GetSpecialSymbolsModel(int id)
        {
            return _db.SpecialSymbols.FirstOrDefault(async => async.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool SpecialSymbolsModelExists(string name)
        {
            bool value = _db.SpecialSymbols.Any(a => a.SymbolName.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool SpecialSymbolsModelExists(int id)
        {
            bool value = _db.SpecialSymbols.Any(a => a.Id == id);
            return value;
        }

        public bool UpdateSpecialSymbolsModel(SpecialSymbolsModel specialSymbols)
        {
            _db.SpecialSymbols.Update(specialSymbols);
            return Save();
        }
    }
}
