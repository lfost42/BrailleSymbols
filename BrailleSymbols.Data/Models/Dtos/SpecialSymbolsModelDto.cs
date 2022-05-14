using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrailleSymbols.Data.Models.Dtos
{
    public class SpecialSymbolsModelDto
    {
        public int Id { get; set; }
        public string SymbolName { get; set; }
        public bool NotRequired { get; set; }
        public virtual ICollection<AsciiModel> AsciiModels { get; set; } = new HashSet<AsciiModel>();
    }
}
