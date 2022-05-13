using System;
using System.Collections.Generic;

namespace BrailleSymbols.Data.Models
{
    public class SpecialSymbols
    {
        public int Id { get; set; }
        public string SymbolName { get; set; }

        public virtual ICollection<AsciiModel> AsciiModels { get; set; } = new HashSet<AsciiModel>();
    }
}
