using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrailleSymbols.Data.Models.Dtos
{
    public class AsciiModelDto
    {
        public int Id { get; set; }
        public string AsciiSymbol { get; set; }
        public virtual ICollection<SpecialSymbolsModel> SpecialSymbolsModel { get; set; } = new HashSet<SpecialSymbolsModel>();

    }
}
