using Braille.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Braille.Data.Repository.IRepository
{
    public interface IBrailleSymbolRepository
    {
        ICollection<BrailleSymbol> GetBrailleSymbols();
        ICollection<BrailleSymbol> GetBrailleSymbolsInAsciiCharacter(int npId);
        BrailleSymbol GetBrailleSymbol(int BrailleSymbolId);
        bool BrailleSymbolExists(string name);
        bool BrailleSymbolExists(int id);
        bool CreateBrailleSymbol(BrailleSymbol BrailleSymbol);
        bool UpdateBrailleSymbol(BrailleSymbol BrailleSymbol);
        bool DeleteBrailleSymbol(BrailleSymbol BrailleSymbol);
        bool Save();

    }
}
