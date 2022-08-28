using Braille.Data.Data;
using Braille.Data.Models;
using Braille.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Braille.Data.Repository
{
    public class AsciiCharacterRepository : IAsciiCharacterRepository
    {
        private readonly ApplicationDbContext _db;

        public AsciiCharacterRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateAsciiCharacter(AsciiCharacter AsciiCharacter)
        {
            _db.AsciiCharacters.Add(AsciiCharacter);
            return Save();
        }

        public bool DeleteAsciiCharacter(AsciiCharacter AsciiCharacter)
        {
            _db.AsciiCharacters.Remove(AsciiCharacter);
            return Save();
        }

        public AsciiCharacter GetAsciiCharacter(int AsciiCharacterId)
        {
            return _db.AsciiCharacters.FirstOrDefault(a => a.Id == AsciiCharacterId);
        }

        public ICollection<AsciiCharacter> GetAsciiCharacters()
        {
            return _db.AsciiCharacters.OrderBy(a => a.Characters).ToList();
        }

        public bool AsciiCharacterExists(string characters)
        {
            bool value = _db.AsciiCharacters.Any(a => a.Characters.Trim() == characters.Trim());
            return value;
        }

        public bool AsciiCharacterExists(int id)
        {
            return _db.AsciiCharacters.Any(a => a.Id == id);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }

        public bool UpdateAsciiCharacter(AsciiCharacter AsciiCharacter)
        {
            _db.AsciiCharacters.Update(AsciiCharacter);
            return Save();
        }
    }
}
