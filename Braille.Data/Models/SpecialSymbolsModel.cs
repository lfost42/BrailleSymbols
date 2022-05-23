using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Braille.Data.Models
{
    public class SpecialSymbolsModel
    {
        public int Id { get; set; }
        [Required, StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 1)]
        public string Ascii { get; set; }
        [Required, StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 1)]
        public string SymbolName { get; set; }
        public bool SSPRequired { get; set; }

        public DateTime Added { get; set; }
        public DateTime? Updated { get; set; }
    }
}