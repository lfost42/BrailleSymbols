using Braille.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Braille.Data.Repository.IRepository
{
    public interface IAsciiCharacterRepository
    {
        ICollection<AsciiCharacter> GetAsciiCharacters();
        AsciiCharacter GetAsciiCharacter(int AsciiCharacterId);
        bool AsciiCharacterExists(string name);
        bool AsciiCharacterExists(int id);
        bool CreateAsciiCharacter(AsciiCharacter AsciiCharacter);
        bool UpdateAsciiCharacter(AsciiCharacter AsciiCharacter);
        bool DeleteAsciiCharacter(AsciiCharacter AsciiCharacter);
        bool Save();

    }
}
