using System;
using System.ComponentModel.DataAnnotations;

namespace BrailleSymbols.Data.Models.Dtos
{
    public class AsciiModelDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
    }
}
