using System.Collections.Generic;
using BrailleSymbols.Data.Models;

namespace BrailleSymbols.Data.Repository.IRepository
{
    public interface ISpecialSymbolsRepository
    {
        bool CreateSpecialSymbolsModel(SpecialSymbolsModel specialSymbols);
        bool DeleteSpecialSymbolsModel(SpecialSymbolsModel specialSymbols);
        ICollection<SpecialSymbolsModel> GetSpecialSymbolModels();
        SpecialSymbolsModel GetSpecialSymbolsModel(int id);
        bool Save();
        bool SpecialSymbolsModelExists(string name);
        bool SpecialSymbolsModelExists(int id);
        bool UpdateSpecialSymbolsModel(SpecialSymbolsModel specialSymbols);
    }
}