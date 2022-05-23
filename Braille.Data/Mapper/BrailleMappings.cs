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
            CreateMap<SpecialSymbolsModel, SpecialSymbolsModelDto>().ReverseMap();
        }
    }
}
