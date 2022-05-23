using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Braille.Data.Models.Dtos
{
    public class SpecialSymbolsModelDto
    {
        public int Id { get; set; }
        [Required]
        public string Ascii { get; set; }
        [Required]
        public string SymbolName { get; set; }
        public bool SSPRequired { get; set; }
        public DateTime Added { get; set; }
        public DateTime? Updated { get; set; }

    }
}
