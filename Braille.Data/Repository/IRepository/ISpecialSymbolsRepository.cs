using System.Collections.Generic;
using Braille.Data.Models;

namespace Braille.Data.Repository.IRepository
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