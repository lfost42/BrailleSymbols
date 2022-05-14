using System;
using System.Collections.Generic;
using System.Linq;
using BrailleSymbols.Data.Data;
using BrailleSymbols.Data.Models;
using BrailleSymbols.Data.Repository.IRepository;

namespace BrailleSymbols.Data.Repository.IRepository
{
    public interface IAsciiRepository
    {
        bool AsciiExists(string symbol);
        bool AsciiModelExists(int id);
        bool CreateAsciiModel(AsciiModel ascii);
        bool DeleteAsciiModel(AsciiModel ascii);
        AsciiModel GetAsciiModel(int id);
        System.Collections.Generic.ICollection<AsciiModel> GetAsciis();
        bool Save();
        bool UpdateAscii(AsciiModel ascii);
    }
}