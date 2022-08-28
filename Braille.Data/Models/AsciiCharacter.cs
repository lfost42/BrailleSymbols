using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Braille.Data.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class AsciiCharacter

    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50, ErrorMessage = "The {0} must be atleast {2} and at most {1} characters.", MinimumLength = 2)]
        public string Characters { get; set; }

        public virtual ICollection<BrailleSymbol> Symbols { get; set; } = new HashSet<BrailleSymbol>();

        public DateTime Added { get; set; }
        public DateTime? Updated { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
