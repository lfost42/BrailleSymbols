using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Braille.Data.Models.Dtos
{
    public class AsciiCharacterDto
    {
        public int Id { get; set; }
        [Required]
        public string Characters { get; set; }

        public virtual ICollection<BrailleSymbol> Symbols { get; set; } = new HashSet<BrailleSymbol>();
    }
}
