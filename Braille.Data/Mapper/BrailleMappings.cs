using System;
using AutoMapper;
using Braille.Data.Models;
using Braille.Data.Models.Dtos;

namespace Braille.Data.Mapper
{
    public class BrailleMappings : Profile
    {
        public BrailleMappings()
        {
            CreateMap<AsciiCharacter, AsciiCharacterDto>().ReverseMap();
            CreateMap<BrailleSymbol, BrailleSymbolDto>().ReverseMap();
            CreateMap<BrailleSymbol, BrailleSymbolCreateDto>().ReverseMap();
            CreateMap<BrailleSymbol, BrailleSymbolUpdateDto>().ReverseMap();
        }
    }
}
