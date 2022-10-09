using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Braille.Data.Models
{
    public class AsciiCharacter

    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(20, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 1)]
        public string Characters { get; set; }

        public DateTime? Added { get; set; }
        public DateTime? Updated { get; set; }
    }
}
