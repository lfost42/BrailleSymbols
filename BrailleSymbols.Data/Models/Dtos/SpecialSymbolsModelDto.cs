using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrailleSymbols.Data.Models.Dtos
{
    public class SpecialSymbolsModelDto
    {
        public int Id { get; set; }
        [Required, StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string SymbolName { get; set; }
        public bool NotRequired { get; set; }
        public int AsciiModelId { get; set; }
        public AsciiModel AsciiModel { get; set; }

    }
}
