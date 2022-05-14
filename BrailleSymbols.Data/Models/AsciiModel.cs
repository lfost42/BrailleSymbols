using System;
using System.ComponentModel.DataAnnotations;

namespace BrailleSymbols.Data.Models
{
    public class AsciiModel
    {
        public int Id { get; set; }
        [Required, StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Symbol { get; set; }
    }
}
